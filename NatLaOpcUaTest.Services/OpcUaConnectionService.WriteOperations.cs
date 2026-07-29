using System.Text;
using System.Text.Json;
using NatLaOpcUaTest.Core.Contracts;
using Newtonsoft.Json.Linq;
using Opc.Ua;
using Opc.Ua.Client;
using Reqnroll;

namespace NatLaOpcUaTest.Services;

internal partial class OpcUaConnectionService
{
    public async Task WriteNodeValueById(string nodeIdentifier, string newValue)
    {
        await WriteNodeValue(NodeId.Parse(nodeIdentifier), newValue);

    }

    public async Task WriteNodeValueByPath(string nodePath, string newValue)
    {
        var nodeId = await GetNodeIdentifierFromPath(nodePath);
        await WriteNodeValue(nodeId!, newValue);
    }

    private async Task WriteNodeValue(NodeId nodeId, string newValue)
    {
        var session = await GetSession();

        var (targetNode, _) = await GetNodeById(nodeId);
        if (targetNode is not VariableNode variableNode)
            throw new InvalidOperationException($"Node {nodeId} is not a VariableNode and cannot be written.");

        var writeValue = new WriteValueCollection
        {
            new WriteValue
            {
                NodeId = nodeId,
                AttributeId = Attributes.Value,
                Value = EncodeNodeValue(newValue, variableNode),
            }
        };

        var resp = await session.WriteAsync(null, writeValue, CancellationToken.None);
        var result = resp.Results.Single();
        if (result.SymbolicId != "Good")
        {
            throw new InvalidOperationException($"Error while writing node value: {JsonSerializer.Serialize(result)}");
        }
    }

    private DataValue EncodeNodeValue(string newValue, VariableNode variableNode)
    {
        var isArray = variableNode.ValueRank >= ValueRanks.OneDimension;
        object typedValue = isArray
            ? EncodeNodeArrayValue(newValue, variableNode.DataType)
            : EncodeNodeScalarValue(newValue, variableNode.DataType);
        return new DataValue { Value = typedValue };
    }

    private static object EncodeNodeScalarValue(string newValue, NodeId dataTypeId)
    {
        return dataTypeId.Identifier switch
        {
            (uint)BuiltInType.Boolean => bool.Parse(newValue),
            (uint)BuiltInType.SByte => sbyte.Parse(newValue),
            (uint)BuiltInType.Byte => byte.Parse(newValue),
            (uint)BuiltInType.Int16 => short.Parse(newValue),
            (uint)BuiltInType.UInt16 => ushort.Parse(newValue),
            (uint)BuiltInType.Int32 => int.Parse(newValue),
            (uint)BuiltInType.UInt32 => uint.Parse(newValue),
            (uint)BuiltInType.Int64 => long.Parse(newValue),
            (uint)BuiltInType.UInt64 => ulong.Parse(newValue),
            (uint)BuiltInType.Float => float.Parse(newValue),
            (uint)BuiltInType.Double => double.Parse(newValue),
            (uint)BuiltInType.String => newValue,
            (uint)BuiltInType.ExtensionObject => new ExtensionObject(
                dataTypeId,
                Encoding.UTF8.GetBytes(newValue)
                ),
            _ => newValue
        };
    }

    private static object EncodeNodeArrayValue(string newValue, NodeId dataTypeId)
    {
        return dataTypeId.Identifier switch
        {
            (uint)BuiltInType.Boolean => JsonSerializer.Deserialize<bool[]>(newValue)!,
            (uint)BuiltInType.SByte => JsonSerializer.Deserialize<sbyte[]>(newValue)!,
            (uint)BuiltInType.Byte => JsonSerializer.Deserialize<byte[]>(newValue)!,
            (uint)BuiltInType.Int16 => JsonSerializer.Deserialize<short[]>(newValue)!,
            (uint)BuiltInType.UInt16 => JsonSerializer.Deserialize<ushort[]>(newValue)!,
            (uint)BuiltInType.Int32 => JsonSerializer.Deserialize<int[]>(newValue)!,
            (uint)BuiltInType.UInt32 => JsonSerializer.Deserialize<uint[]>(newValue)!,
            (uint)BuiltInType.Int64 => JsonSerializer.Deserialize<long[]>(newValue)!,
            (uint)BuiltInType.UInt64 => JsonSerializer.Deserialize<ulong[]>(newValue)!,
            (uint)BuiltInType.Float => JsonSerializer.Deserialize<float[]>(newValue)!,
            (uint)BuiltInType.Double => JsonSerializer.Deserialize<double[]>(newValue)!,
            (uint)BuiltInType.String => JsonSerializer.Deserialize<string[]>(newValue)!,
            _ => JsonSerializer.Deserialize<string[]>(newValue)!
        };
    }
}