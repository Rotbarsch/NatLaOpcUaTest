using NatLaOpcUaTest.Core.Contracts;
using NatLaOpcUaTest.Drivers.Interfaces;
using Reqnroll;
using Reqnroll.Assist;

namespace NatLaOpcUaTest.Bindings.Actions;

[Binding]
public class MethodActions(INodeMethodDriver nodeMethodDriver)
{
    /// <summary>
    /// Invokes an OPC UA method node identified by its node ID and stores the result in a named variable.
    /// </summary>
    /// <param name="nodeIdentifier">The OPC UA node ID of the method node (e.g. <c>ns=2;s=MyObject.MyMethod</c>).</param>
    /// <param name="targetVariableName">The name of the variable in which the method's return value is stored.</param>
    [When("the method on node with id '(.*)' is invoked and the result is stored in variable '(.*)'")]
    public async Task InvokeMethodById(string nodeIdentifier, string targetVariableName)
    {
        await nodeMethodDriver.InvokeMethodById(nodeIdentifier, targetVariableName);
    }

    /// <summary>
    /// Invokes an OPC UA method node identified by its node ID with the given input parameters and stores the result in a named variable.
    /// </summary>
    /// <param name="nodeIdentifier">The OPC UA node ID of the method node (e.g. <c>ns=2;s=MyObject.MyMethod</c>).</param>
    /// <param name="targetVariableName">The name of the variable in which the method's return value is stored.</param>
    /// <param name="parameters">
    /// A Reqnroll <see cref="DataTable"/> whose rows are mapped to <see cref="NatLaOpcUaTest.Core.Contracts.MethodInvocationParameter"/> records.
    /// Each row must contain the columns <c>Value</c> (string) and <c>DataType</c> (string).
    /// </param>
    [When("the method on node with id '(.*)' is invoked and the result is stored in variable '(.*)' using the following parameters:")]
    public async Task InvokeMethodById(string nodeIdentifier, string targetVariableName, DataTable parameters)
    {
        await nodeMethodDriver.InvokeMethodById(nodeIdentifier, targetVariableName, parameters.CreateSet<MethodInvocationParameter>());
    }

    /// <summary>
    /// Invokes an OPC UA method node identified by its node ID without capturing a return value.
    /// </summary>
    /// <param name="nodeIdentifier">The OPC UA node ID of the method node (e.g. <c>ns=2;s=MyObject.MyMethod</c>).</param>
    [When("the method on node with id '(.*)' is invoked")]
    public async Task InvokeMethodById(string nodeIdentifier)
    {
        await nodeMethodDriver.InvokeMethodById(nodeIdentifier);
    }

    /// <summary>
    /// Invokes an OPC UA method node identified by its node ID with the given input parameters without capturing a return value.
    /// </summary>
    /// <param name="nodeIdentifier">The OPC UA node ID of the method node (e.g. <c>ns=2;s=MyObject.MyMethod</c>).</param>
    /// <param name="parameters">
    /// A Reqnroll <see cref="DataTable"/> whose rows are mapped to <see cref="NatLaOpcUaTest.Core.Contracts.MethodInvocationParameter"/> records.
    /// Each row must contain the columns <c>Value</c> (string) and <c>DataType</c> (string).
    /// </param>
    [When("the method on node with id '(.*)' is invoked using the following parameters:")]
    public async Task InvokeMethodById(string nodeIdentifier, DataTable parameters)
    {
        await nodeMethodDriver.InvokeMethodById(nodeIdentifier, parameters: parameters.CreateSet<MethodInvocationParameter>());
    }

    /// <summary>
    /// Invokes an OPC UA method node identified by its browse path and stores the result in a named variable.
    /// </summary>
    /// <param name="nodePath">The browse path to the method node (e.g. <c>/Objects/MyObject/MyMethod</c>).</param>
    /// <param name="targetVariableName">The name of the variable in which the method's return value is stored.</param>
    [When("the method on node with path '(.*)' is invoked and the result is stored in variable '(.*)'")]
    public async Task InvokeMethodByPath(string nodePath, string targetVariableName)
    {
        await nodeMethodDriver.InvokeMethodByPath(nodePath, targetVariableName);
    }

    /// <summary>
    /// Invokes an OPC UA method node identified by its browse path with the given input parameters and stores the result in a named variable.
    /// </summary>
    /// <param name="nodePath">The browse path to the method node (e.g. <c>/Objects/MyObject/MyMethod</c>).</param>
    /// <param name="targetVariableName">The name of the variable in which the method's return value is stored.</param>
    /// <param name="parameters">
    /// A Reqnroll <see cref="DataTable"/> whose rows are mapped to <see cref="NatLaOpcUaTest.Core.Contracts.MethodInvocationParameter"/> records.
    /// Each row must contain the columns <c>Value</c> (string) and <c>DataType</c> (string).
    /// </param>
    [When("the method on node with path '(.*)' is invoked and the result is stored in variable '(.*)' using the following parameters:")]
    public async Task InvokeMethodByPath(string nodePath, string targetVariableName, DataTable parameters)
    {
        await nodeMethodDriver.InvokeMethodByPath(nodePath, targetVariableName, parameters.CreateSet<MethodInvocationParameter>());
    }

    /// <summary>
    /// Invokes an OPC UA method node identified by its browse path without capturing a return value.
    /// </summary>
    /// <param name="nodePath">The browse path to the method node (e.g. <c>/Objects/MyObject/MyMethod</c>).</param>
    [When("the method on node with id '(.*)' is invoked")]
    public async Task InvokeMethodByPath(string nodePath)
    {
        await nodeMethodDriver.InvokeMethodByPath(nodePath);
    }

    /// <summary>
    /// Invokes an OPC UA method node identified by its browse path with the given input parameters without capturing a return value.
    /// </summary>
    /// <param name="nodePath">The browse path to the method node (e.g. <c>/Objects/MyObject/MyMethod</c>).</param>
    /// <param name="parameters">
    /// A Reqnroll <see cref="DataTable"/> whose rows are mapped to <see cref="NatLaOpcUaTest.Core.Contracts.MethodInvocationParameter"/> records.
    /// Each row must contain the columns <c>Value</c> (string) and <c>DataType</c> (string).
    /// </param>
    [When("the method on node with id '(.*)' is invoked using the following parameters:")]
    public async Task InvokeMethodByPath(string nodePath, DataTable parameters)
    {
        await nodeMethodDriver.InvokeMethodByPath(nodePath, parameters: parameters.CreateSet<MethodInvocationParameter>());
    }


}