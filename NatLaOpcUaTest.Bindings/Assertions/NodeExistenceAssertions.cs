using NatLaOpcUaTest.Drivers.Interfaces;
using NUnit.Framework;
using Reqnroll;

namespace NatLaOpcUaTest.Bindings.Assertions;

[Binding]
public class NodeExistenceAssertions(INodeReadDriver nodeReadDriver)
{
    /// <summary>
    /// Asserts that an OPC UA node with the given node ID exists on the server.
    /// </summary>
    /// <param name="nodeIdentifier">The OPC UA node ID to check (e.g. <c>ns=2;s=MyObject.MyNode</c>).</param>
    [Then("a node with id '(.*)' exists")]
    public async Task NodeExistsById(string nodeIdentifier)
    {
        var exists = await nodeReadDriver.CheckNodeExistsById(nodeIdentifier);
        Assert.IsTrue(exists, $"Node with nodeIdentifier '{nodeIdentifier}' does not exist.");
    }

    /// <summary>
    /// Asserts that an OPC UA node reachable via the given browse path exists on the server.
    /// </summary>
    /// <param name="path">The browse path to the node (e.g. <c>/Objects/MyObject/MyNode</c>).</param>
    [Then("a node with path '(.*)' exists")]
    public async Task NodeExistsbyPath(string path)
    {
        var exists = await nodeReadDriver.CheckNodeExistsByPath(path);
        Assert.IsTrue(exists, $"Node with path '{path}' does not exist.");
    }

    /// <summary>
    /// Asserts that an OPC UA node with the given node ID does not exist on the server.
    /// </summary>
    /// <param name="nodeIdentifier">The OPC UA node ID to check (e.g. <c>ns=2;s=MyObject.MyNode</c>).</param>
    [Then("a node with id '(.*)' does not exist")]
    public async Task NodeNotExistsById(string nodeIdentifier)
    {
        var exists = await nodeReadDriver.CheckNodeExistsById(nodeIdentifier);
        Assert.IsFalse(exists, $"Node with nodeIdentifier '{nodeIdentifier}' exists.");
    }

    /// <summary>
    /// Asserts that an OPC UA node reachable via the given browse path does not exist on the server.
    /// </summary>
    /// <param name="path">The browse path to the node (e.g. <c>/Objects/MyObject/MyNode</c>).</param>
    [Then("a node with path '(.*)' does not exist")]
    public async Task NodeNotExistsByPath(string path)
    {
        var exists = await nodeReadDriver.CheckNodeExistsByPath(path);
        Assert.IsFalse(exists, $"Node with path '{path}' exists.");
    }
}