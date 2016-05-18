using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SIS.Extensions.TestGenerator.Contracts;

namespace SIS.Extensions.TestGenerator.Transformers
{
    public class ParameterTransformer : ITransform<ParameterListSyntax, IVariable[]>
    {
        ITransform<ParameterSyntax, IVariable> _variableTransformer = new VariableTransformer();
        public IVariable[] Transform(ParameterListSyntax input)
        {
            return input
                .DescendantNodes()
                .OfType<ParameterSyntax>()
                .Select(_variableTransformer.Transform)
                .ToArray();
        }
    }
}