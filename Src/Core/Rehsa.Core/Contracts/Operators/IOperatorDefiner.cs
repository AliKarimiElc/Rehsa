using Rehsa.Core.Contracts.Rule;

namespace Rehsa.Core.Contracts.Operators;

public interface IOperatorDefiner
{
    public IRuleBuilder EqualWith<TData>(TData data);
    public IRuleBuilder NotEqualWith<TData>(TData data);
    public IRuleBuilder True();
    public IRuleBuilder False();
}