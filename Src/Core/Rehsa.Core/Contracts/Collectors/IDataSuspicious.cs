using Rehsa.Core.Contracts.Operators;

namespace Rehsa.Core.Contracts.Collectors;

public interface IDataSuspicious<out TData>
{
    IOperatorDefiner Suspect(Func<TData, object> func);
}