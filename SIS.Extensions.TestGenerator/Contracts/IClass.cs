using SIS.Extensions.TestGenerator.Models;

namespace SIS.Extensions.TestGenerator.Contracts
{
    public interface IClass : IAccessible
    {
        IConstructor[] Constructors { get; }
        IMethod[] Methods { get; set; }
        IProperty[] Properties { get; set; }
        Variable[] GetMethodVariables();
    }
}