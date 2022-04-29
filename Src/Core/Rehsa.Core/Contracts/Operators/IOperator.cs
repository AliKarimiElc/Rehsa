using Rehsa.Core.Models;

namespace Rehsa.Core.Contracts.Operators;

public interface IOperator
{
    Task<bool> ExecuteAsync<TData>(ICollectedData<TData> collectedData, Func<TData, object> suspectedFunc,
        CancellationToken? cancellationToken = null);

    bool Execute<TData>(ICollectedData<TData> collectedData, Func<TData, object> suspectedFunc);
}