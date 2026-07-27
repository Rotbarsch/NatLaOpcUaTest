using NatLaOpcUaTest.Core.Contracts;
using NatLaOpcUaTest.Services.Interfaces;
using Opc.Ua;
using Opc.Ua.Client;
using System.Text;

#pragma warning disable CS0618 // Type or member is obsolete

namespace NatLaOpcUaTest.Services;

internal partial class OpcUaConnectionService : IOpcUaConnectionService, IDisposable
{
    private readonly IConnectionConfigurationService _connectionConfigurationService;
    private OpcUaConnectionSettings ConnectionSettings => _connectionConfigurationService.ConnectionSettings;
    private Session? _session;


    public OpcUaConnectionService(IConnectionConfigurationService connectionConfigurationService)
    {
        _connectionConfigurationService = connectionConfigurationService;
        ConnectionSettings.OnChanged += OnConnectionSettingsChanged;
    }

    private void OnConnectionSettingsChanged(object sender, OnChangedEventArgs args)
    {
        DisposeSession();
    }

    public void DisposeSession()
    {
        if (_session is not null && _session.Connected) _session.CloseAsync().GetAwaiter().GetResult();
        _session?.Dispose();
        _session = null;
    }

    private async Task<Session> GetSession()
    {
        if (_session is not null)
        {
            return _session;
        }

        if (string.IsNullOrEmpty(ConnectionSettings.Endpoint))
        {
            throw new InvalidOperationException($"Cannot create OPC/UA session without configured endpoint uri.");
        }

        var config = new ApplicationConfiguration
        {
            ApplicationName = ConnectionSettings.ApplicationName,
            ApplicationType = ApplicationType.Client,
            SecurityConfiguration = new SecurityConfiguration
            {
                ApplicationCertificate = new CertificateIdentifier
                {
                    StoreType = @"Directory",
                    StorePath = @"%CommonApplicationData%\OPC Foundation\CertificateStores\MachineDefault",
                    SubjectName = Utils.Format(@"CN={0}, DC={1}", ConnectionSettings.ApplicationName, System.Net.Dns.GetHostName())
                },
                TrustedIssuerCertificates = new CertificateTrustList
                {
                    StoreType = @"Directory",
                    StorePath = @"%CommonApplicationData%\OPC Foundation\CertificateStores\UA Certificate Authorities"
                },
                TrustedPeerCertificates = new CertificateTrustList
                {
                    StoreType = @"Directory",
                    StorePath = @"%CommonApplicationData%\OPC Foundation\CertificateStores\UA Applications"
                },
                AutoAcceptUntrustedCertificates = true
            },
            TransportConfigurations = new TransportConfigurationCollection(),
            TransportQuotas = new TransportQuotas(),
            ClientConfiguration = new ClientConfiguration()
        };

        await config.ValidateAsync(ApplicationType.Client);

        var telemetry = DefaultTelemetry.Create(_ => { });

        var endpointDescription =
            await CoreClientUtils.SelectEndpointAsync(
                config,
                ConnectionSettings.Endpoint!,
                false,
                telemetry);

        var endpoint =
            new ConfiguredEndpoint(
                null,
                endpointDescription,
                EndpointConfiguration.Create(config));

        IUserIdentity identity =
            ConnectionSettings.Username == null
                ? new UserIdentity()
                : new UserIdentity(ConnectionSettings.Username, ConnectionSettings.Password is not null ? Encoding.UTF8.GetBytes(ConnectionSettings.Password) : null);

        _session = await Session.Create(
            config,
            endpoint,
            false,
            "NatLaOpcUaTestClient",
            (uint)ConnectionSettings.DefaultSessionTimeout,
            identity,
            null);

        return _session;
    }

    private async Task<IList<(Node node, string statusCode)>> GetChildrenAsync(NodeId nodeId)
    {
        var session = await GetSession();

        var browser = new Browser(session)
        {
            BrowseDirection = BrowseDirection.Forward,
            ReferenceTypeId = ReferenceTypeIds.HierarchicalReferences,
            IncludeSubtypes = true
        };

        var references = await browser.BrowseAsync(nodeId);

        var nodeIds = new NodeIdCollection(references.Select(r => ExpandedNodeId.ToNodeId(r.NodeId, session.NamespaceUris)));
        var (nodes, statusCodes) = await session.ReadNodesAsync(nodeIds);

        return nodes
            .Zip(statusCodes, (node, status) => (node, status.StatusCode.ToString()))
            .ToList();
    }

    public void Dispose()
    {
        _session?.Dispose();
    }

    private async Task<NodeId?> GetNodeIdentifierFromPath(string nodePath, bool throwIfNotFound=true)
    {
        var segments = nodePath.Split(
            '/',
            StringSplitOptions.RemoveEmptyEntries);

        NodeId current = ObjectIds.RootFolder;

        foreach (var segment in segments)
        {
            var children = await GetChildrenAsync(current);

            var match = children.SingleOrDefault(c => c.node.BrowseName?.Name == segment);

            if (match.node is null)
            {
                if(throwIfNotFound) throw new InvalidOperationException($"Path segment '{segment}' not found.");
                return null;
            }

            current = match.node.NodeId;
        }

        return current;
    }
}