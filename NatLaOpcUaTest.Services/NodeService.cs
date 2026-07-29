using NatLaOpcUaTest.Core.Contracts;
using NatLaOpcUaTest.Services.Interfaces;

namespace NatLaOpcUaTest.Services;

internal class NodeService(IOpcUaConnectionService opcUaConnectionService) : INodeService
{
    public async Task<string?> ReadNodeById(string nodeIdentifier)
    {
        return await opcUaConnectionService.ReadNodeById(nodeIdentifier);
    }

    public async Task<string?> ReadNodeByPath(string nodePath)
    {
        return await opcUaConnectionService.ReadNodeByPath(nodePath);
    }

    public async Task<bool> NodeExistsById(string nodeIdentifier)
    {
        return await opcUaConnectionService.NodeExistsById(nodeIdentifier);
    }

    public async Task<bool> NodeExistsByPath(string path)
    {
        return await opcUaConnectionService.NodeExistsByPath(path);
    }

    public async Task<NodeInfo> GetNodeInfoById(string nodeIdentifier)
    {
        return await opcUaConnectionService.GetNodeInfoById(nodeIdentifier);
    }

    public async Task<NodeInfo> GetNodeInfoByPath(string path)
    {
        return await opcUaConnectionService.GetNodeInfoByPath(path);
    }

    public async Task<IEnumerable<NodeInfo>> GetChildrenOfNodeById(string nodeIdentifier)
    {
        return await opcUaConnectionService.GetChildrenOfNodeById(nodeIdentifier);
    }

    public async Task<IEnumerable<NodeInfo>> GetChildrenOfNodeByPath(string path)
    {
        return await opcUaConnectionService.GetChildrenOfNodeByPath(path);
    }

    public async Task WriteNodeById(string nodeIdentifier, string newValue)
    {
        await opcUaConnectionService.WriteNodeValueById(nodeIdentifier, newValue);
    }

    public async Task WriteNodeByPath(string nodePath, string newValue)
    {
        await opcUaConnectionService.WriteNodeValueByPath(nodePath, newValue);
    }
}