using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SIS.Extensions.TestGenerator.Contracts;
using SIS.Extensions.TestGenerator.Models;

namespace SIS.Extensions.TestGenerator.Transformers
{
    public class MethodTransformer : ITransform<MethodDeclarationSyntax, IMethod>
    {
        ITransform<SyntaxTokenList, SyntaxKind[]> _modifierTransformer = new ModifiersTransformer();
        ITransform<ParameterListSyntax, IVariable[]> _parameterTransformer = new ParameterTransformer();
        public IMethod Transform(MethodDeclarationSyntax input)
        {
            return new Method()
            {
                Modifiers = _modifierTransformer.Transform(input.Modifiers),
                Name = input.Identifier.ValueText,
                Parameters = _parameterTransformer.Transform(input.ParameterList)
            };
        }
    }
}