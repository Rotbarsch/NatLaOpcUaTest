using NatLaOpcUaTest.Core.Contracts;
using NatLaOpcUaTest.Services.Interfaces;

namespace NatLaOpcUaTest.Services;

internal class NodeService(IOpcUaConnectionService opcUaConectConnectionService) : INodeService
{
    public async Task<string?> ReadNodeById(string nodeIdentifier)
    {
        return await opcUaConectConnectionService.ReadNodeById(nodeIdentifier);
    }

    public async Task<string?> ReadNodeByPath(string nodePath)
    {
        return await opcUaConectConnectionService.ReadNodeByPath(nodePath);
    }

    public async Task<bool> NodeExistsById(string nodeIdentifier)
    {
        return await opcUaConectConnectionService.NodeExistsById(nodeIdentifier);
    }

    public async Task<bool> NodeExistsByPath(string path)
    {
        return await opcUaConectConnectionService.NodeExistsByPath(path);
    }

    public async Task<NodeInfo> GetNodeInfoById(string nodeIdentifier)
    {
        return await opcUaConectConnectionService.GetNodeInfoById(nodeIdentifier);
    }

    public async Task<NodeInfo> GetNodeInfoByPath(string path)
    {
        return await opcUaConectConnectionService.GetNodeInfoByPath(path);
    }

    public async Task<IEnumerable<NodeInfo>> GetChildrenOfNodeById(string nodeIdentifier)
    {
        return await opcUaConectConnectionService.GetChildrenOfNodeById(nodeIdentifier);
    }

    public async Task<IEnumerable<NodeInfo>> GetChildrenOfNodeByPath(string path)
    {
        return await opcUaConectConnectionService.GetChildrenOfNodeByPath(path);
    }
}