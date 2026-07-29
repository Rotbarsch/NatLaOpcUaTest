using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatLaOpcUaTest.Core.Contracts;

public record MethodInvocationParameter
{
    public required string Value { get; set; }
    public required string DataType { get; set; }
}