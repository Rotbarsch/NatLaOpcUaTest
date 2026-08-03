using NatLaOpcUaTest.Drivers.Interfaces;
using Reqnroll;

namespace NatLaOpcUaTest.Bindings.Actions;

[Binding]
public class NodeReadValueActions(INodeReadDriver nodeReadDriver)
{
    /// <summary>
    /// Reads the value of the OPC UA node identified by its node ID and stores it in a named variable.
    /// </summary>
    /// <param name="nodeIdentifier">The OPC UA node ID of the variable node (e.g. <c>ns=2;s=MyObject.MyVariable</c>).</param>
    /// <param name="targetVariableName">The name of the variable in which the node's value is stored.</param>
    [When("the value of node with id '(.*)' is stored in variable '(.*)'")]
    public async Task ReadNodeById(string nodeIdentifier, string targetVariableName)
    {
        await nodeReadDriver.ReadNodeById(nodeIdentifier, targetVariableName);
    }

    /// <summary>
    /// Reads the value of the OPC UA node identified by its browse path and stores it in a named variable.
    /// </summary>
    /// <param name="nodePath">The browse path to the variable node (e.g. <c>/Objects/MyObject/MyVariable</c>).</param>
    /// <param name="targetVariableName">The name of the variable in which the node's value is stored.</param>
    [When("the value of node with path '(.*)' is stored in variable '(.*)'")]
    public async Task ReadNodeByPath(string nodePath, string targetVariableName)
    {
        await nodeReadDriver.ReadNodeByPath(nodePath, targetVariableName);
    }

}