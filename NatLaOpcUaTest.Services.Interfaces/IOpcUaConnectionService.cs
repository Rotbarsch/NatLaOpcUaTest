namespace NatLaOpcUaTest.Services.Interfaces;

public interface IOpcUaConnectionService
{
    Task<string?> ReadNodeById(string nodeIdentifier);
    Task<string?> ReadNodeByPath(string nodePath);
}