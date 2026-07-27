using NatLaOpcUaTest.Core.Contracts.Extensions;
using Opc.Ua;

namespace NatLaOpcUaTest.Core.Contracts;

public record NodeInfo
{
    public required string? BrowseName { get; set; }
    public required string? DisplayName { get; set; }
    public required string NodeClass { get; set; }
    public required string TypeId { get; set; }
    public required string NodeId { get; set; }
    public required string? Description { get; set; }
    public required string StatusCode { get; set; }

    public static NodeInfo FromNode(Node node, string statusCode)
    {
        return new NodeInfo
        {
            BrowseName = node!.BrowseName?.Name,
            DisplayName = node!.DisplayName?.Text,
            NodeClass = node!.NodeClass.ToString(),
            TypeId = node!.TypeId.ToAddressableString(),
            NodeId = node!.NodeId.ToAddressableString(),
            Description = node.Description?.Text,
            StatusCode = statusCode
        };
    }
}