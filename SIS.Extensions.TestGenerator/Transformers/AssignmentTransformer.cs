using Microsoft.CodeAnalysis.CSharp.Syntax;
using SIS.Extensions.TestGenerator.Contracts;
using SIS.Extensions.TestGenerator.Models;

namespace SIS.Extensions.TestGenerator.Transformers
{
    public class AssignmentTransformer : ITransform<AssignmentExpressionSyntax, IAssignment>
    {
        public IAssignment Transform(AssignmentExpressionSyntax input)
        {
            var obj = new Assignment();

           

            var left = input.Left;
            var right = input.Right;


            return obj;
        }
    }
}