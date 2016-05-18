using Microsoft.CodeAnalysis.CSharp.Syntax;
using SIS.Extensions.TestGenerator.Contracts;
using SIS.Extensions.TestGenerator.Models;

namespace SIS.Extensions.TestGenerator.Transformers
{
    public class ConstructorTransformer : ITransform<ConstructorDeclarationSyntax, IConstructor>
    {
        ITransform<ParameterListSyntax, IVariable[]> _parameterTransformer = new ParameterTransformer();
        public IConstructor Transform(ConstructorDeclarationSyntax input)
        {
            return new Constructor()
            {
                Name = input.Identifier.ValueText,
                Parameters = _parameterTransformer.Transform(input.ParameterList)
            };
        }
    }
}