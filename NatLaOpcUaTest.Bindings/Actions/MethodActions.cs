using NatLaOpcUaTest.Core.Contracts;
using NatLaOpcUaTest.Drivers.Interfaces;
using Reqnroll;
using Reqnroll.Assist;

namespace NatLaOpcUaTest.Bindings.Actions;

[Binding]
public class MethodActions(INodeMethodDriver nodeMethodDriver)
{
    [When("the method on node with id '(.*)' is invoked and the result is stored in variable '(.*)'")]
    public async Task InvokeMethodById(string nodeIdentifier, string targetVariableName)
    {
        await nodeMethodDriver.InvokeMethodById(nodeIdentifier, targetVariableName);
    }

    [When("the method on node with id '(.*)' is invoked and the result is stored in variable '(.*)' using the following parameters:")]
    public async Task InvokeMethodById(string nodeIdentifier, string targetVariableName, DataTable parameters)
    {
        await nodeMethodDriver.InvokeMethodById(nodeIdentifier, targetVariableName, parameters.CreateSet<MethodInvocationParameter>());
    }

    [When("the method on node with id '(.*)' is invoked")]
    public async Task InvokeMethodById(string nodeIdentifier)
    {
        await nodeMethodDriver.InvokeMethodById(nodeIdentifier);
    }

    [When("the method on node with id '(.*)' is invoked using the following parameters:")]
    public async Task InvokeMethodById(string nodeIdentifier, DataTable parameters)
    {
        await nodeMethodDriver.InvokeMethodById(nodeIdentifier, parameters: parameters.CreateSet<MethodInvocationParameter>());
    }

    [When("the method on node with path '(.*)' is invoked and the result is stored in variable '(.*)'")]
    public async Task InvokeMethodByPath(string nodePath, string targetVariableName)
    {
        await nodeMethodDriver.InvokeMethodByPath(nodePath, targetVariableName);
    }

    [When("the method on node with path '(.*)' is invoked and the result is stored in variable '(.*)' using the following parameters:")]
    public async Task InvokeMethodByPath(string nodePath, string targetVariableName, DataTable parameters)
    {
        await nodeMethodDriver.InvokeMethodByPath(nodePath, targetVariableName, parameters.CreateSet<MethodInvocationParameter>());
    }

    [When("the method on node with id '(.*)' is invoked")]
    public async Task InvokeMethodByPath(string nodePath)
    {
        await nodeMethodDriver.InvokeMethodByPath(nodePath);
    }

    [When("the method on node with id '(.*)' is invoked using the following parameters:")]
    public async Task InvokeMethodByPath(string nodePath, DataTable parameters)
    {
        await nodeMethodDriver.InvokeMethodByPath(nodePath, parameters: parameters.CreateSet<MethodInvocationParameter>());
    }


}