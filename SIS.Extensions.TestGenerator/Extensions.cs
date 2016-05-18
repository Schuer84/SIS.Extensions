using System;
using System.Linq.Expressions;

namespace SIS.Extensions.TestGenerator
{
    public static class Extensions
    {
        public static string Capitalize(this string src)
        {
            return src != null && src.Length > 1
                ? $"{src.Substring(0, 1).ToUpper()}{src.Substring(1)}"
                : src;
        }

        public static string GetName<TModel, TProp>(this Expression<Func<TModel, TProp>> expr)
        {
            var me = expr.Body as MemberExpression;
            if( me != null)
            {
                return me.Member.Name;
            }

            var ue = expr.Body as UnaryExpression;
            if (ue != null)
            {
                return ((MemberExpression)ue.Operand).Member.Name;
            }

            throw new InvalidOperationException();
        }
    }
}