using Newtonsoft.Json;
using Opc.Ua;
using Opc.Ua.Client;

namespace NatLaOpcUaTest.Services;

internal partial class OpcUaConnectionService
{
    public async Task<string?> ReadNodeById(string nodeIdentifier)
    {
        return await ReadNodeById(NodeId.Parse(nodeIdentifier));
    }

    public async Task<string?> ReadNodeByPath(string nodePath)
    {
        var segments = nodePath.Split(
            '/',
            StringSplitOptions.RemoveEmptyEntries);

        NodeId current = ObjectIds.RootFolder;

        foreach (var segment in segments)
        {
            var children = await GetChildrenAsync(current.ToString());

            var match = children.SingleOrDefault(c => c.BrowseName.Name == segment);

            if (match is null)
            {
                throw new InvalidOperationException(
                    $"Path segment '{segment}' not found.");
            }

            current = match.NodeId.InnerNodeId;
        }

        return await ReadNodeById(current);
    }

    private async Task<string?> ReadNodeById(NodeId nodeId)
    {
        var session = await GetSession();

        var nodeValue = await session.ReadValueAsync(nodeId);
        return DecodeNodeValue(nodeValue);
    }

    private string? DecodeNodeValue(DataValue nodeValue)
    {
        if (nodeValue.Value is null) return null;

        object? toSerialize = nodeValue.Value;

        if (nodeValue.Value is ExtensionObject eo)
        {
            toSerialize = eo.Body;
        }

        if (nodeValue.Value is ExtensionObject[] eoa)
        {
            toSerialize = eoa.Select(x => x.Body);
        }

        return JsonConvert.SerializeObject(toSerialize);
    }
}