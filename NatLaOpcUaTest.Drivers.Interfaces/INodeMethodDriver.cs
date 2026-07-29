using NatLaOpcUaTest.Core.Contracts;

namespace NatLaOpcUaTest.Drivers.Interfaces;

public interface INodeMethodDriver
{
    Task InvokeMethodById(string nodeIdentifier, string? targetVariableName = null, IEnumerable<MethodInvocationParameter>? parameters = null);
    Task InvokeMethodByPath(string nodePath, string? targetVariableName = null, IEnumerable<MethodInvocationParameter>? parameters = null);
}