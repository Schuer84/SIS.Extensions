using SIS.Extensions.TestGenerator.Contracts;

namespace SIS.Extensions.TestGenerator.Managers
{
    public interface IFileTemplateProvider
    {
        IFileTemplate GetFileTemplate(IFile file);
    }
}