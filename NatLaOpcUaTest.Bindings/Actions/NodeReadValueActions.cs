using NatLaOpcUaTest.Drivers.Interfaces;
using Reqnroll;

namespace NatLaOpcUaTest.Bindings.Actions;

[Binding]
public class NodeReadValueActions(INodeReadDriver nodeReadDriver)
{
    [When("the value of node with id '(.*)' is stored in variable '(.*)'")]
    public async Task ReadNodeById(string nodeIdentifier, string targetVariableName)
    {
        await nodeReadDriver.ReadNodeById(nodeIdentifier, targetVariableName);
    }

    [When("the value of node with path '(.*)' is stored in variable '(.*)'")]
    public async Task ReadNodeByPath(string nodePath, string targetVariableName)
    {
        await nodeReadDriver.ReadNodeByPath(nodePath, targetVariableName);
    }

}