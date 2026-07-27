using NatLaOpcUaTest.Drivers.Interfaces;
using Reqnroll;

namespace NatLaOpcUaTest.Bindings.Actions;

[Binding]
public class NodeReadActions(INodeReadDriver nodeReadDriver)
{
    [When("the node with id '(.*)' is stored in variable '(.*)'")]
    public async Task GetNodeById(string nodeIdentifier, string targetVariableName)
    {
        await nodeReadDriver.GetNodeInfoById(nodeIdentifier, targetVariableName);
    }

    [When("the node with path '(.*)' is stored in variable '(.*)'")]
    public async Task GetNodeByPath(string path, string targetVariableName)
    {
        await nodeReadDriver.GetNodeInfoByPath(path,targetVariableName);
    }

    [When("the children of node with id '(.*)' are stored in variable '(.*)'")]
    public async Task GetNodeChildrenById(string nodeIdentifier, string targetVariableName)
    {
        await nodeReadDriver.GetChildrenOfNodeById(nodeIdentifier, targetVariableName);
    }

    [When("the children of node with path '(.*)' are stored in variable '(.*)'")]
    public async Task GetNodeChildrenByPath(string path, string targetVariableName)
    {
        await nodeReadDriver.GetChildrenOfNodeByPath(path, targetVariableName);
    }
}