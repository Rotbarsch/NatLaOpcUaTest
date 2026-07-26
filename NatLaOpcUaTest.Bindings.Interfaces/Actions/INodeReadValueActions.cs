namespace NatLaOpcUaTest.Bindings.Interfaces.Actions;

public interface INodeReadValueActions
{
    Task ReadNodeById(string nodeIdentifier, string targetVariableName);
}