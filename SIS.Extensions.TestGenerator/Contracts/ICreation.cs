namespace SIS.Extensions.TestGenerator.Contracts
{
    public interface ICreation : IMeta
    {
        IAssignment[] Assignments { get; }
    }
}