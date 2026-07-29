namespace NatLaOpcUaTest.Drivers.Interfaces;

public interface INodeReadDriver
{
    Task ReadNodeById(string nodeIdentifier, string targetVariableName);
    Task ReadNodeByPath(string nodePath, string targetVariableName);
    Task<bool> CheckNodeExistsById(string nodeIdentifier);
    Task<bool> CheckNodeExistsByPath(string path);
    Task GetNodeInfoById(string nodeIdentifier, string targetVariableName);
    Task GetNodeInfoByPath(string path, string targetVariableName);
    Task GetChildrenOfNodeById(string nodeIdentifier, string targetVariableName);
    Task GetChildrenOfNodeByPath(string path, string targetVariableName);
}