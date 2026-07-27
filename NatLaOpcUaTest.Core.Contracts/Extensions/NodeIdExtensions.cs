using Opc.Ua;

namespace NatLaOpcUaTest.Core.Contracts.Extensions;

internal static class NodeIdExtensions
{
    public static string ToAddressableString(this NodeId nodeId)
    {
        return $"ns={nodeId.NamespaceIndex};{nodeId.ToString()}";
    }
}