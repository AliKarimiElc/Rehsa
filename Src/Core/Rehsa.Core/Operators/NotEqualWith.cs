using Rehsa.Core.Contracts.Operators;
using Rehsa.Core.Models;

namespace Rehsa.Core.Operators;

public class NotEqualWith : IConditionalOperator
{
    private object? Data { get; set; }

    public NotEqualWith(object? data)
    {
        Data = data;
    }

    public async Task<bool> ExecuteAsync<TData,TProperty>(ICollectedData<TData> collectedData, Func<TData, TProperty> suspectedFunc,
        CancellationToken? cancellationToken = null)
    {
        return await Task.Run(() =>
        {
            var data = suspectedFunc.Invoke(collectedData.GetData());
            return !data.Equals(Data);
        }, cancellationToken ?? new CancellationToken(false));
    }

    public bool Execute<TData,TProperty>(ICollectedData<TData> collectedData, Func<TData, TProperty> suspectedFunc)
    {
        var data = suspectedFunc.Invoke(collectedData.GetData());
        return !data.Equals(Data);
    }
}