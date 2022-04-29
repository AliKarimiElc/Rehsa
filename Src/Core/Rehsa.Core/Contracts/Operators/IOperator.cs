using Rehsa.Core.Models;

namespace Rehsa.Core.Contracts.Operators;

public interface IOperator
{
    Task<bool> ExecuteAsync<TData,TProperty>(ICollectedData<TData> collectedData, Func<TData, TProperty> suspectedFunc,
        CancellationToken? cancellationToken = null);

    bool Execute<TData,TProperty>(ICollectedData<TData> collectedData, Func<TData, TProperty> suspectedFunc);
}