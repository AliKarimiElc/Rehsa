using System.Linq.Expressions;
using System.Reflection;

namespace Rehsa.Core
{
    internal class SuspectedProperty<TData, TProperty>
    {
        public SuspectedProperty(MemberInfo member, Func<TData, TProperty> suspectedPropertyFunc,
            LambdaExpression expression, Type propertyType)
        {
            Member = member;
            SuspectedPropertyFunc = suspectedPropertyFunc;
            Expression = expression;
            PropertyType = propertyType;

            var collectedDataType = typeof(TData);
        }

        public LambdaExpression Expression { get; set; }

        public Type PropertyType { get; set; }

        public Func<TData, TProperty> SuspectedPropertyFunc { get; set; }

        public MemberInfo Member { get; set; }

        public static SuspectedProperty<TData, TProperty> Create(Expression<Func<TData, TProperty>> expression)
        {
            var member = expression.GetMember();
            var compiled = expression.Compile();
            return new SuspectedProperty<TData, TProperty>(member, x => compiled(x), expression, typeof(TProperty));
        }
    }
}
