using System.Collections.Generic;
using SIS.Extensions.TestGenerator.Contracts;

namespace SIS.Extensions.TestGenerator.Comparers
{
    internal class VariableEqualityComparer : IEqualityComparer<IVariable>
    {
        public bool Equals(IVariable x, IVariable y)
        {
            return x.Name.Equals(y.Name) && x.Type.Equals(y.Type);
        }

        public int GetHashCode(IVariable obj)
        {
            return obj.Name.GetHashCode() * obj.Type.GetHashCode();
        }
    }
}