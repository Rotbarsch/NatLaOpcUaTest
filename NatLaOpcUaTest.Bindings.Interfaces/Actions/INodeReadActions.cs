namespace NatLaOpcUaTest.Bindings.Interfaces.Actions;

public interface INodeReadActions
{
    Task ReadNodeById(string nodeIdentifier, string targetVariableName);
}