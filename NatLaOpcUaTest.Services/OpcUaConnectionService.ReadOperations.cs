using NatLaOpcUaTest.Core.Contracts;
using Newtonsoft.Json;
using NUnit.Framework;
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
        var nodeId = await GetNodeIdentifierFromPath(nodePath);

        return await ReadNodeById(nodeId!);
    }

    public async Task<bool> NodeExistsById(string nodeIdentifier)
    {
        var (node, _) = await GetNodeById(NodeId.Parse(nodeIdentifier));
        return node is not null;
    }

    public async Task<bool> NodeExistsByPath(string path)
    {
        var nodeId = await GetNodeIdentifierFromPath(path, false);

        if (nodeId is null) return false;

        var (node, _) = await GetNodeById(nodeId);
        return node is not null;
    }

    public async Task<NodeInfo> GetNodeInfoById(string nodeIdentifier)
    {
        return await ReadNodeInfoById(NodeId.Parse(nodeIdentifier));
    }

    public async Task<NodeInfo> GetNodeInfoByPath(string path)
    {
        var nodeId = await GetNodeIdentifierFromPath(path);

        if(nodeId is null) Assert.Fail($"No node with path '{path}' found.");

        return await ReadNodeInfoById(nodeId!);
    }

    public async Task<IEnumerable<NodeInfo>> GetChildrenOfNodeById(string nodeIdentifier)
    {
        return await ReadChildrenNodeInfosById(nodeIdentifier);
    }

    private async Task<IEnumerable<NodeInfo>> ReadChildrenNodeInfosById(NodeId nodeId)
    {
        var nodes = await GetChildrenAsync(nodeId);

        var result = new List<NodeInfo>();

        foreach (var (node, statusCode) in nodes)
        {
            result.Add(NodeInfo.FromNode(node, statusCode));
        }

        return result;
    }

    public async Task<IEnumerable<NodeInfo>> GetChildrenOfNodeByPath(string path)
    {
        var nodeId = await GetNodeIdentifierFromPath(path);

        if (nodeId is null) Assert.Fail($"No node with path '{path}' found.");

        return await ReadChildrenNodeInfosById(nodeId!);
    }

    private async Task<(Node? node, string statusCode)> GetNodeById(NodeId nodeId)
    {
        var session = await GetSession();

        var (nodes, statusCodes) = await session.ReadNodesAsync(new NodeIdCollection { nodeId });
        var status = statusCodes[0];

        if (ServiceResult.IsGood(status))
            return (nodes[0], status.StatusCode.ToString());

        if (status.StatusCode == StatusCodes.BadNodeIdUnknown)
            return (null, status.StatusCode.ToString());

        throw new ServiceResultException(status);
    }

    private async Task<string?> ReadNodeById(NodeId nodeId)
    {
        var session = await GetSession();

        var nodeValue = await session.ReadValueAsync(nodeId);
        return DecodeNodeValue(nodeValue);
    }

    private async Task<NodeInfo> ReadNodeInfoById(NodeId nodeId)
    {
        var (node, statusCode) = await GetNodeById(nodeId);
        if(node is null) Assert.Fail($"No node with id {nodeId.ToString()} found.");

        return NodeInfo.FromNode(node!, statusCode);
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