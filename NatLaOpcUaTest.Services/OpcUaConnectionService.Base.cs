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

    private async Task<ReferenceDescriptionCollection> GetChildrenAsync(string nodeId)
    {
        var browser = new Browser(await GetSession())
        {
            BrowseDirection = BrowseDirection.Forward,
            ReferenceTypeId = ReferenceTypeIds.HierarchicalReferences,
            IncludeSubtypes = true
        };

        return await browser.BrowseAsync(NodeId.Parse(nodeId));
    }

    public void Dispose()
    {
        _session?.Dispose();
    }
}