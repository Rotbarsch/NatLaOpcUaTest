using NatLaOpcUaTest.Core.Contracts;
using NatLaOpcUaTest.Drivers.Interfaces;
using NatLaOpcUaTest.Services.Interfaces;
using Rotbarsch.Reqnroll.Services.Interfaces;

namespace NatLaOpcUaTest.Drivers;

internal class NodeMethodDriver(INodeService nodeService, IVariableService variableService) : INodeMethodDriver
{
    public async Task InvokeMethodById(string nodeIdentifier, string? targetVariableName = null, IEnumerable<MethodInvocationParameter>? parameters = null)
    {
        var result = await nodeService.InvokeMethodById(nodeIdentifier, parameters);
        if (targetVariableName is not null)
        {
            variableService.SetVariable(targetVariableName,result);
        }
    }

    public async Task InvokeMethodByPath(string nodePath, string? targetVariableName = null, IEnumerable<MethodInvocationParameter>? parameters = null)
    {
        var result = await nodeService.InvokeMethodByPath(nodePath, parameters);
        if (targetVariableName is not null)
        {
            variableService.SetVariable(targetVariableName, result);
        }
    }
}