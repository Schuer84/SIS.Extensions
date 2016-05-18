using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using SIS.Extensions.TestGenerator.Comparers;
using SIS.Extensions.TestGenerator.Contracts;

namespace SIS.Extensions.TestGenerator.Models
{
    public class Class : IClass
    {
        public string Name { get; set; }
        public string Namespace { get; set; }
        public string[] Usings { get; set; }
        public SyntaxKind[] Modifiers { get; set; }
        public IConstructor[] Constructors { get; set; }
        public IMethod[] Methods { get; set; }
        public IProperty[] Properties { get; set; }
        //public IField[] Fields { get; set; }

        public Variable[] GetMethodVariables()
        {
            return Methods.SelectMany(x => x.Parameters)
                        .Distinct(new VariableEqualityComparer())
                        .GroupBy(x => x.Name)
                        .SelectMany(x => {
                                                return (x.Count() > 1)
                                                    ? x.Select(y => new Variable() { Name = $"{y.Type}{y.Name}", Type = y.Type })
                                                    : x.Select(y => new Variable() { Name = y.Name, Type = y.Type });
                        })
                        .ToArray();
        }
    }
}