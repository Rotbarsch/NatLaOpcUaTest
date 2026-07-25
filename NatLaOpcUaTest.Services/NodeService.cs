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
}