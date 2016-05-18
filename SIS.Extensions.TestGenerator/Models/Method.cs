using Microsoft.CodeAnalysis.CSharp;
using SIS.Extensions.TestGenerator.Contracts;

namespace SIS.Extensions.TestGenerator.Models
{
    public class Method : IMethod
    {
        public SyntaxKind[] Modifiers { get; set; }
        public string Name { get; set; }
        public IVariable[] Parameters { get; set; }
    }
}