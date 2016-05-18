namespace SIS.Extensions.TestGenerator.Contracts
{
    public interface IVisualStudioManager
    {
        string GenerateUnitTest(IFileTemplate template);
    }
}