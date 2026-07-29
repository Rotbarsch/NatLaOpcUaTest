using NatLaOpcUaTest.Core.Contracts;
using Opc.Ua;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NatLaOpcUaTest.Services
{
    internal partial class OpcUaConnectionService
    {
        public async Task<string?> InvokeMethodById(string nodeIdentifier, IEnumerable<MethodInvocationParameter>? parameters)
        {
            return await ExecuteMethodById(NodeId.Parse(nodeIdentifier!), parameters);
        }

        public async Task<string?> InvokeMethodByPath(string nodePath, IEnumerable<MethodInvocationParameter>? parameters)
        {
            var nodeId = await GetNodeIdentifierFromPath(nodePath);

            return await ExecuteMethodById(nodeId!, parameters);
        }

        private async Task<string?> ExecuteMethodById(NodeId nodeId, IEnumerable<MethodInvocationParameter>? parameters=null)
        {
            var session = await GetSession();

            var (targetNode, _) = await GetNodeById(nodeId);

            if (targetNode is not MethodNode mn) throw new InvalidOperationException($"Node {nodeId} is not a MethodNode and cannot be invoked.");
            
            var call = new CallMethodRequestCollection
            {
                new CallMethodRequest
                {
                    MethodId = nodeId,
                    InputArguments = parameters is not null ? new VariantCollection(parameters.Select(GetVariant)) : null
                }
            };

            var response = await session.CallAsync(null, call, CancellationToken.None);

            throw new NotImplementedException();
        }

        private Variant GetVariant(MethodInvocationParameter methodInvocationParameter)
        {
            return new Variant();
        }
    }
}
