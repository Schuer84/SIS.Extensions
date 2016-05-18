using SIS.Extensions.TestGenerator.Contracts;

namespace SIS.Extensions.TestGenerator.Templates
{
    public partial class Template : IFileTemplate
    {
        public IFile File { get; set; }
    }
}
