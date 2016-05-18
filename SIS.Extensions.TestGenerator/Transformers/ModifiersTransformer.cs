using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using SIS.Extensions.TestGenerator.Contracts;

namespace SIS.Extensions.TestGenerator.Transformers
{
    public class ModifiersTransformer : ITransform<SyntaxTokenList, SyntaxKind[]>
    {
        public SyntaxKind[] Transform(SyntaxTokenList input)
        {
            return input.OfType<SyntaxToken>()
                .Select(y => y.Kind())
                .ToArray();
        }
    }
}