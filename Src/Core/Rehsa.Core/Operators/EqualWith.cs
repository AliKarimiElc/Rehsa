using Rehsa.Core.Contracts.Operators;
using Rehsa.Core.Exceptions;
using Rehsa.Core.Models;

namespace Rehsa.Core.Operators;

/// <summary>
/// Check that suspected data of collected data equal with input data or not
/// </summary>
public class EqualWith : IConditionalOperator
{
    /// <summary>
    /// Condition data
    /// </summary>
    public object? Data { get; set; }

    /// <summary>
    /// Create EqualWith conditional operator
    /// </summary>
    /// <param name="data">data</param>
    public EqualWith(object? data)
    {
        Data = data;
    }

    /// <summary>
    /// Execute operator async
    /// </summary>
    /// <param name="collectedData">Collected data for check rule</param>
    /// <param name="suspectedFunc">Function for select property of Collected data</param>
    /// <param name="cancellationToken">Cancellation token for cancel execution</param>
    /// <typeparam name="TData">Type of collected data</typeparam>
    /// <typeparam name="TProperty">Type of suspected property of collected data</typeparam>
    /// <exception cref="RehsaArgumentNullException"></exception>
    /// <returns>Task bool</returns>
    public async Task<bool> ExecuteAsync<TData, TProperty>(ICollectedData<TData> collectedData,
        Func<TData, TProperty> suspectedFunc,
        CancellationToken? cancellationToken = null)
    {
        return await Task.Run(() =>
        {
            var data = suspectedFunc(collectedData.GetData());
            if (data == null && Data == null)
                return true;
            if (data == null) throw new RehsaArgumentNullException(nameof(data));
            return data.Equals(Data);
        }, cancellationToken ?? new CancellationToken(false));
    }

    /// <summary>
    /// Execute operator
    /// </summary>
    /// <param name="collectedData">Collected data for check rule</param>
    /// <param name="suspectedFunc">Function for select property of Collected data</param>
    /// <typeparam name="TData">Type of collected data</typeparam>
    /// <typeparam name="TProperty">Type of suspected property of collected data</typeparam>
    /// <exception cref="RehsaArgumentNullException"></exception>
    /// <returns>Task bool</returns>
    public bool Execute<TData, TProperty>(ICollectedData<TData> collectedData, Func<TData, TProperty> suspectedFunc)
    {
        var data = suspectedFunc(collectedData.GetData());
        if (data == null && Data == null)
            return true;
        if (data == null) throw new RehsaArgumentNullException(nameof(data));
        return data.Equals(Data);
    }
}