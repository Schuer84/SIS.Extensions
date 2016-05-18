using SIS.Extensions.TestGenerator.Contracts;

namespace SIS.Extensions.TestGenerator.Models
{
    public class Creation : ICreation
    {
        public string Name { get; set; }
        public IAssignment[] Assignments { get; set; }
    }
}