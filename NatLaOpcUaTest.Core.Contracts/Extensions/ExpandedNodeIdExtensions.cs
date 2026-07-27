using Opc.Ua;

namespace NatLaOpcUaTest.Core.Contracts.Extensions;

internal static class ExpandedNodeIdExtensions
{
    public static string ToAddressableString(this ExpandedNodeId nodeId)
    {
        return $"ns={nodeId.NamespaceIndex};{nodeId.ToString()}";
    }
}