namespace SIS.Extensions.TestGenerator.Contracts
{
    public interface IFileTemplate : ITemplate
    {
        IFile File { get; set; }
    }
}