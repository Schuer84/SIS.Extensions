using SIS.Extensions.TestGenerator.Contracts;
using SIS.Extensions.TestGenerator.Templates;

namespace SIS.Extensions.TestGenerator.Managers
{
    public class FileTemplateProvider : IFileTemplateProvider
    {
        public IFileTemplate GetFileTemplate(IFile file)
        {
            return new Template()
            {
                File = file
            };
        }
    }
}