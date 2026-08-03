using NatLaOpcUaTest.Drivers.Interfaces;
using Reqnroll;

namespace NatLaOpcUaTest.Bindings.Actions;

[Binding]
public class NodeReadActions(INodeReadDriver nodeReadDriver)
{
    /// <summary>
    /// Reads the OPC UA node identified by its node ID and stores a <see cref="NatLaOpcUaTest.Core.Contracts.NodeInfo"/> record in a named variable.
    /// </summary>
    /// <remarks>
    /// The stored <c>NodeInfo</c> contains: <c>BrowseName</c>, <c>DisplayName</c>, <c>NodeClass</c>, <c>TypeId</c>,
    /// <c>NodeId</c>, <c>Description</c>, and <c>StatusCode</c>.
    /// </remarks>
    /// <param name="nodeIdentifier">The OPC UA node ID (e.g. <c>ns=2;s=MyObject.MyNode</c>).</param>
    /// <param name="targetVariableName">The name of the variable in which the <c>NodeInfo</c> is stored.</param>
    [When("the node with id '(.*)' is stored in variable '(.*)'")]
    public async Task GetNodeById(string nodeIdentifier, string targetVariableName)
    {
        await nodeReadDriver.GetNodeInfoById(nodeIdentifier, targetVariableName);
    }

    /// <summary>
    /// Reads the OPC UA node identified by its browse path and stores a <see cref="NatLaOpcUaTest.Core.Contracts.NodeInfo"/> record in a named variable.
    /// </summary>
    /// <remarks>
    /// The stored <c>NodeInfo</c> contains: <c>BrowseName</c>, <c>DisplayName</c>, <c>NodeClass</c>, <c>TypeId</c>,
    /// <c>NodeId</c>, <c>Description</c>, and <c>StatusCode</c>.
    /// </remarks>
    /// <param name="path">The browse path to the node (e.g. <c>/Objects/MyObject/MyNode</c>).</param>
    /// <param name="targetVariableName">The name of the variable in which the <c>NodeInfo</c> is stored.</param>
    [When("the node with path '(.*)' is stored in variable '(.*)'")]
    public async Task GetNodeByPath(string path, string targetVariableName)
    {
        await nodeReadDriver.GetNodeInfoByPath(path,targetVariableName);
    }

    /// <summary>
    /// Reads the child nodes of the OPC UA node identified by its node ID and stores a collection of
    /// <see cref="NatLaOpcUaTest.Core.Contracts.NodeInfo"/> records in a named variable.
    /// </summary>
    /// <remarks>
    /// Each <c>NodeInfo</c> in the collection contains: <c>BrowseName</c>, <c>DisplayName</c>, <c>NodeClass</c>,
    /// <c>TypeId</c>, <c>NodeId</c>, <c>Description</c>, and <c>StatusCode</c>.
    /// </remarks>
    /// <param name="nodeIdentifier">The OPC UA node ID of the parent node (e.g. <c>ns=2;s=MyObject</c>).</param>
    /// <param name="targetVariableName">The name of the variable in which the child <c>NodeInfo</c> collection is stored.</param>
    [When("the children of node with id '(.*)' are stored in variable '(.*)'")]
    public async Task GetNodeChildrenById(string nodeIdentifier, string targetVariableName)
    {
        await nodeReadDriver.GetChildrenOfNodeById(nodeIdentifier, targetVariableName);
    }

    /// <summary>
    /// Reads the child nodes of the OPC UA node identified by its browse path and stores a collection of
    /// <see cref="NatLaOpcUaTest.Core.Contracts.NodeInfo"/> records in a named variable.
    /// </summary>
    /// <remarks>
    /// Each <c>NodeInfo</c> in the collection contains: <c>BrowseName</c>, <c>DisplayName</c>, <c>NodeClass</c>,
    /// <c>TypeId</c>, <c>NodeId</c>, <c>Description</c>, and <c>StatusCode</c>.
    /// </remarks>
    /// <param name="path">The browse path to the parent node (e.g. <c>/Objects/MyObject</c>).</param>
    /// <param name="targetVariableName">The name of the variable in which the child <c>NodeInfo</c> collection is stored.</param>
    [When("the children of node with path '(.*)' are stored in variable '(.*)'")]
    public async Task GetNodeChildrenByPath(string path, string targetVariableName)
    {
        await nodeReadDriver.GetChildrenOfNodeByPath(path, targetVariableName);
    }
}