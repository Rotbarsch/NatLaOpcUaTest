using NatLaOpcUaTest.Drivers.Interfaces;
using NatLaOpcUaTest.Services.Interfaces;
using Rotbarsch.Reqnroll.Services.Interfaces;

namespace NatLaOpcUaTest.Drivers;

internal class NodeReadDriver(INodeService nodeService, IVariableService variableService) : INodeReadDriver
{
    public async Task ReadNodeById(string nodeIdentifier, string targetVariableName)
    {
        var nodeValue = await nodeService.ReadNodeById(nodeIdentifier);
        variableService.SetVariable(targetVariableName, nodeValue);
    }

    public async Task ReadNodeByPath(string nodePath, string targetVariableName)
    {
        var nodeValue = await nodeService.ReadNodeByPath(nodePath);
        variableService.SetVariable(targetVariableName,nodeValue);
    }
}