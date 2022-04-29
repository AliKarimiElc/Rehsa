using Rehsa.Core.Contracts.Operators;
using Rehsa.Core.Models;

namespace Rehsa.Core.Operators;

public class False : IConditionalOperator
{
    public async Task<bool> ExecuteAsync<TData>(ICollectedData<TData> collectedData, Func<TData, object> suspectedFunc,
        CancellationToken? cancellationToken = null)
    {
        return await Task.Run(() =>
        {
            var data = suspectedFunc.Invoke(collectedData.GetData());
            return !(bool)data;
        }, cancellationToken ?? new CancellationToken(false));
    }

    public bool Execute<TData>(ICollectedData<TData> collectedData, Func<TData, object> suspectedFunc)
    {
        var data = suspectedFunc.Invoke(collectedData.GetData());
        return !(bool)data;
    }
}