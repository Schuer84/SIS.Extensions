using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SIS.Extensions.TestGenerator.Contracts;
using SIS.Extensions.TestGenerator.Models;

namespace SIS.Extensions.TestGenerator.Transformers
{
    public class PropertyTransformer : ITransform<PropertyDeclarationSyntax, IProperty>
    {
        ITransform<SyntaxTokenList, SyntaxKind[]> _modifierTransformer = new ModifiersTransformer();
        public IProperty Transform(PropertyDeclarationSyntax input)
        {
            return new Property()
            {
                Modifiers = _modifierTransformer.Transform(input.Modifiers),
                Name = input.Identifier.ValueText,
                Type = input.Type
                    .GetText()
                    .ToString()
            };
        }
    }
}