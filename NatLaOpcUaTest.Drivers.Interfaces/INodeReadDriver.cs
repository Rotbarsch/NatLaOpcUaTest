namespace NatLaOpcUaTest.Drivers.Interfaces;

public interface INodeReadDriver
{
    Task ReadNodeById(string nodeIdentifier, string targetVariableName);

    Task ReadNodeByPath(string nodePath, string targetVariableName);
}