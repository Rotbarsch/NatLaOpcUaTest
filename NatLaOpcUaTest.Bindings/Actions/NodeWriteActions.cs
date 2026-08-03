using NatLaOpcUaTest.Drivers.Interfaces;
using Reqnroll;

namespace NatLaOpcUaTest.Bindings.Actions;

[Binding]
public class NodeWriteActions(INodeWriteDriver nodeWriteDriver)
{
    /// <summary>
    /// Writes a value to the OPC UA node identified by its node ID.
    /// </summary>
    /// <param name="newValue">The value to write, as a string. The driver is responsible for type conversion.</param>
    /// <param name="nodeIdentifier">The OPC UA node ID of the target variable node (e.g. <c>ns=2;s=MyObject.MyVariable</c>).</param>
    [When("the value '(.*)' is written to node with id '(.*)'")]
    public async Task WriteNodeById(string newValue, string nodeIdentifier)
    {
        await nodeWriteDriver.WriteNodeValueById(nodeIdentifier, newValue);
    }

    /// <summary>
    /// Writes a value to the OPC UA node identified by its browse path.
    /// </summary>
    /// <param name="newValue">The value to write, as a string. The driver is responsible for type conversion.</param>
    /// <param name="nodePath">The browse path to the target variable node (e.g. <c>/Objects/MyObject/MyVariable</c>).</param>
    [When("the value '(.*)' is written to node with path '(.*)'")]
    public async Task WriteNodeByPath(string newValue, string nodePath)
    {
        await nodeWriteDriver.WriteNodeValueByPath(nodePath, newValue);
    }

    /// <summary>
    /// Writes a multi-line value to the OPC UA node identified by its node ID.
    /// </summary>
    /// <param name="nodeIdentifier">The OPC UA node ID of the target variable node (e.g. <c>ns=2;s=MyObject.MyVariable</c>).</param>
    /// <param name="newValue">The value to write, supplied as a multi-line doc-string in the Gherkin step. The driver is responsible for type conversion.</param>

    [When("the following value is written to node with id '(.*)':")]
    public async Task WriteNodeByIdMultiline(string nodeIdentifier, string newValue)
    {
        await nodeWriteDriver.WriteNodeValueById(nodeIdentifier, newValue);
    }

    /// <summary>
    /// Writes a multi-line value to the OPC UA node identified by its browse path.
    /// </summary>
    /// <param name="nodePath">The browse path to the target variable node (e.g. <c>/Objects/MyObject/MyVariable</c>).</param>
    /// <param name="newValue">The value to write, supplied as a multi-line doc-string in the Gherkin step. The driver is responsible for type conversion.</param>

    [When("the following value is written to node with path '(.*)':")]
    public async Task WriteNodeByPathMultiline(string nodePath, string newValue)
    {
        await nodeWriteDriver.WriteNodeValueByPath(nodePath, newValue);
    }
}