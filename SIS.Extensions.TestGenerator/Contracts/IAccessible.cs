using Microsoft.CodeAnalysis.CSharp;

namespace SIS.Extensions.TestGenerator.Contracts
{
    public interface IAccessible : IMeta
    {
        SyntaxKind[] Modifiers { get; set; }
    }
}