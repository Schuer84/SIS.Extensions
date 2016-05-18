namespace SIS.Extensions.TestGenerator.Contracts
{
    public interface IFile : IMeta
    {
        string Namespace { get; set; }
        string[] Usings { get; set; }

        IClass[] Classes { get; set; }
    }
}