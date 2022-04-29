using System.Linq.Expressions;
using System.Reflection;

namespace Rehsa.Core
{
    public static class ExpressionExtensions
    {
        public static MemberInfo? GetMember<TData, TProperty>(this Expression<Func<TData, TProperty>> expression)
        {
            if (RemoveUnary(expression.Body) is not MemberExpression memberExp)
            {
                return null;
            }

            var currentExpr = memberExp.Expression;

            while (true)
            {
                currentExpr = RemoveUnary(currentExpr);

                if (currentExpr is { NodeType: ExpressionType.MemberAccess })
                {
                    currentExpr = ((MemberExpression)currentExpr).Expression;
                }
                else
                {
                    break;
                }
            }

            return currentExpr is not { NodeType: ExpressionType.Parameter } ? null : memberExp.Member;
        }

        private static Expression? RemoveUnary(Expression? toUnwrap)
        {
            if (toUnwrap is UnaryExpression expression)
            {
                return expression.Operand;
            }

            return toUnwrap;
        }

    }
}
