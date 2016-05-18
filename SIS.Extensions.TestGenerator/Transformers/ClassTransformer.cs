using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SIS.Extensions.TestGenerator.Contracts;
using SIS.Extensions.TestGenerator.Models;

namespace SIS.Extensions.TestGenerator.Transformers
{
    public class ClassTransformer : ITransform<ClassDeclarationSyntax, IClass>
    {
        private readonly ITransform<ConstructorDeclarationSyntax, IConstructor> _constructorTransformer = new ConstructorTransformer();
        private readonly ITransform<MethodDeclarationSyntax, IMethod> _methodTransformer = new MethodTransformer();
        private readonly ITransform<PropertyDeclarationSyntax, IProperty> _propertyTransformer = new PropertyTransformer();

        public IClass Transform(ClassDeclarationSyntax input)
        {
            var classDescendants = input.DescendantNodes();

            return new Class()
            {
                Name = input.Identifier.ValueText,
                Constructors = classDescendants
                    .OfType<ConstructorDeclarationSyntax>()
                    .Select(_constructorTransformer.Transform)
                    .ToArray(),
                Methods = classDescendants.OfType<MethodDeclarationSyntax>()
                    .Select(_methodTransformer.Transform)
                    .ToArray(),
                Properties = classDescendants.OfType<PropertyDeclarationSyntax>()
                    .Select(_propertyTransformer.Transform)
                    .ToArray()
            };
        }
    }
}