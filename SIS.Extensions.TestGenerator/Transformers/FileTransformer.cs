using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SIS.Extensions.TestGenerator.Contracts;
using SIS.Extensions.TestGenerator.Models;

namespace SIS.Extensions.TestGenerator.Transformers
{
    public class FileTransformer : ITransform<string, IFile>
    {
        private readonly ITransform<ClassDeclarationSyntax, IClass> _classTransformer = new ClassTransformer();

        public IFile Transform(string input)
        {
            if (string.IsNullOrEmpty(input)) return null;

            var tree = CSharpSyntaxTree.ParseText(input);
            var root = (CompilationUnitSyntax)tree.GetRoot();
            var descendants = root.DescendantNodes();
            return new File()
            {
                Namespace = descendants.OfType<NamespaceDeclarationSyntax>()
                    .Select(x => x.Name
                        .GetText()
                        .ToString().TrimEnd('\r', '\n'))
                    .FirstOrDefault(),

                Usings = descendants.OfType<UsingDirectiveSyntax>()
                    .Select(x => x.Name
                        .GetText()
                        .ToString())
                    .ToArray(),

                Classes = descendants.OfType<ClassDeclarationSyntax>()
                    .Select(_classTransformer.Transform)
                    .ToArray()
            };

        }
    }
}