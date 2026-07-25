namespace NatLaOpcUaTest.Services.Interfaces;

public interface INodeService
{
    Task<string?> ReadNodeById(string nodeIdentifier);
    Task<string?> ReadNodeByPath(string nodePath);
}