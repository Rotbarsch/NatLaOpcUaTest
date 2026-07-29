namespace NatLaOpcUaTest.Drivers.Interfaces;

public interface INodeWriteDriver
{
    Task WriteNodeValueById(string nodeIdentifier, string newValue);
    Task WriteNodeValueByPath(string nodePath, string newValue);
}