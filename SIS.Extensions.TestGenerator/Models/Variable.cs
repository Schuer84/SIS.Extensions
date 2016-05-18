using Microsoft.CodeAnalysis.CSharp;
using SIS.Extensions.TestGenerator.Contracts;

namespace SIS.Extensions.TestGenerator.Models
{
    public class Variable : IVariable
    {
        public SyntaxKind[] Modifiers { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}