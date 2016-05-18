namespace SIS.Extensions.TestGenerator.Contracts
{
    public interface IMethod : IAccessible
    {
        IVariable[] Parameters { get; set; }
    }
}