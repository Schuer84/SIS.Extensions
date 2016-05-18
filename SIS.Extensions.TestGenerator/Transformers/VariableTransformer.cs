using Microsoft.CodeAnalysis.CSharp.Syntax;
using SIS.Extensions.TestGenerator.Contracts;
using SIS.Extensions.TestGenerator.Models;

namespace SIS.Extensions.TestGenerator.Transformers
{
    public class VariableTransformer : ITransform<ParameterSyntax, IVariable>
    {
        public IVariable Transform(ParameterSyntax input)
        {
            return new Variable()
            {
                Name = input.Identifier
                    .ValueText
                    .Capitalize(),
                Type = input.Type
                    .GetText()
                    .ToString()
            };
        }
    }
}