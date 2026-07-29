using NatLaOpcUaTest.Drivers.Interfaces;
using Reqnroll;

namespace NatLaOpcUaTest.Bindings.Actions;

[Binding]
public class NodeWriteActions(INodeWriteDriver nodeWriteDriver)
{
    [When("the value '(.*)' is written to node with id '(.*)'")]
    public async Task WriteNodeById(string newValue, string nodeIdentifier)
    {
        await nodeWriteDriver.WriteNodeValueById(nodeIdentifier, newValue);
    }

    [When("the value '(.*)' is written to node with path '(.*)'")]
    public async Task WriteNodeByPath(string newValue, string nodePath)
    {
        await nodeWriteDriver.WriteNodeValueByPath(nodePath, newValue);
    }

    [When("the following value is written to node with id '(.*)':")]
    public async Task WriteNodeByIdMultiline(string nodeIdentifier, string newValue)
    {
        await nodeWriteDriver.WriteNodeValueById(nodeIdentifier, newValue);
    }

    [When("the following value is written to node with path '(.*)':")]
    public async Task WriteNodeByPathMultiline(string nodePath, string newValue)
    {
        await nodeWriteDriver.WriteNodeValueByPath(nodePath, newValue);
    }
}