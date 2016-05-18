using SIS.Extensions.TestGenerator.Contracts;

namespace SIS.Extensions.TestGenerator.Models
{
    public class File : IFile
    {
        public IClass[] Classes { get; set; }
        public string Name { get; set; }
        public string Namespace { get; set; }
        public string[] Usings { get; set; }
    }
}