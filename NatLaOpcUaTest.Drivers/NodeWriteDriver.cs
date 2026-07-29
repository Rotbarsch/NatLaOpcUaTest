using NatLaOpcUaTest.Drivers.Interfaces;
using NatLaOpcUaTest.Services.Interfaces;

namespace NatLaOpcUaTest.Drivers;

internal class NodeWriteDriver(INodeService nodeService) : INodeWriteDriver
{
    public async Task WriteNodeValueById(string nodeIdentifier, string newValue)
    {
        await nodeService.WriteNodeById(nodeIdentifier, newValue);
    }

    public async Task WriteNodeValueByPath(string nodePath, string newValue)
    {
        await nodeService.WriteNodeByPath(nodePath, newValue);
    }
}