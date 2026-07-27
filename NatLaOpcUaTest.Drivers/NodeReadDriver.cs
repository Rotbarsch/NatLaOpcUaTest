using NatLaOpcUaTest.Drivers.Interfaces;
using NatLaOpcUaTest.Services.Interfaces;
using Newtonsoft.Json;
using Rotbarsch.Reqnroll.Services.Interfaces;

namespace NatLaOpcUaTest.Drivers;

internal class NodeReadDriver(INodeService nodeService, IVariableService variableService) : INodeReadDriver
{
    public async Task ReadNodeById(string nodeIdentifier, string targetVariableName)
    {
        var nodeValue = await nodeService.ReadNodeById(nodeIdentifier);
        variableService.SetVariable(targetVariableName, nodeValue);
    }

    public async Task ReadNodeByPath(string nodePath, string targetVariableName)
    {
        var nodeValue = await nodeService.ReadNodeByPath(nodePath);
        variableService.SetVariable(targetVariableName,nodeValue);
    }

    public async Task<bool> CheckNodeExistsById(string nodeIdentifier)
    {
        return await nodeService.NodeExistsById(nodeIdentifier);
    }

    public async Task<bool> CheckNodeExistsByPath(string path)
    {
        return await nodeService.NodeExistsByPath(path);
    }

    public async Task GetNodeInfoById(string nodeIdentifier, string targetVariableName)
    {
        var node = await nodeService.GetNodeInfoById(nodeIdentifier);
        variableService.SetVariable(targetVariableName,JsonConvert.SerializeObject(node));
    }

    public async Task GetNodeInfoByPath(string path, string targetVariableName)
    {
        var node = await nodeService.GetNodeInfoByPath(path);
        variableService.SetVariable(targetVariableName, JsonConvert.SerializeObject(node));
    }

    public async Task GetChildrenOfNodeById(string nodeIdentifier, string targetVariableName)
    {
        var nodes = await nodeService.GetChildrenOfNodeById(nodeIdentifier);
        variableService.SetVariable(targetVariableName, JsonConvert.SerializeObject(nodes));
    }

    public async Task GetChildrenOfNodeByPath(string path, string targetVariableName)
    {
        var nodes = await nodeService.GetChildrenOfNodeByPath(path);
        variableService.SetVariable(targetVariableName, JsonConvert.SerializeObject(nodes));
    }
}