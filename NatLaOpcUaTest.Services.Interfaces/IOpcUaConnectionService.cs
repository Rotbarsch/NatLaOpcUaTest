using NatLaOpcUaTest.Core.Contracts;

namespace NatLaOpcUaTest.Services.Interfaces;

public interface IOpcUaConnectionService
{
    Task<string?> ReadNodeById(string nodeIdentifier);
    Task<string?> ReadNodeByPath(string nodePath);
    Task<bool> NodeExistsById(string nodeIdentifier);
    Task<bool> NodeExistsByPath(string path);
    Task<NodeInfo> GetNodeInfoById(string nodeIdentifier);
    Task<NodeInfo> GetNodeInfoByPath(string path);
    Task<IEnumerable<NodeInfo>> GetChildrenOfNodeById(string nodeIdentifier);
    Task<IEnumerable<NodeInfo>> GetChildrenOfNodeByPath(string path);
    Task WriteNodeValueById(string nodeIdentifier, string newValue);
    Task WriteNodeValueByPath(string nodePath, string newValue);
}