using Microsoft.CodeAnalysis.CSharp.Syntax;
using SIS.Extensions.TestGenerator.Contracts;

namespace SIS.Extensions.TestGenerator.Transformers
{
    public class TypeSyntaxTransformer : ITransform<TypeSyntax, string>
    {
        public string Transform(TypeSyntax input)
        {
            return input.GetText()
                .ToString();
        }
    }
}