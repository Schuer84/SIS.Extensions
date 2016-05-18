using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SIS.Extensions.TestGenerator.Contracts;
using SIS.Extensions.TestGenerator.Models;

namespace SIS.Extensions.TestGenerator.Transformers
{
    public class ObjectCreationTransformer : ITransform<InitializerExpressionSyntax, ICreation>
    {
        ITransform<AssignmentExpressionSyntax, IAssignment> _transformer;
        public ICreation Transform(InitializerExpressionSyntax input)
        {

            var descendants = input.Expressions;

            return new Creation()
            {
                Assignments = descendants.OfType<AssignmentExpressionSyntax>()
                    .Select(_transformer.Transform)
                    .ToArray()
            };
        }
    }
}