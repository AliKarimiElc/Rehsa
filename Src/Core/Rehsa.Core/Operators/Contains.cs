using Rehsa.Core.Contracts.Operators;
using Rehsa.Core.Exceptions;
using Rehsa.Core.Models;

namespace Rehsa.Core.Operators;

/// <summary>
/// Check that suspected data of collected data contains input data or not
/// </summary>
/// <typeparam name="TProperty"></typeparam>
public class Contains<TProperty> : IConditionalOperator
{
    /// <summary>
    /// Condition data
    /// </summary>
    public TProperty Data { get; set; }

    /// <summary>
    /// Create Contains conditional operator
    /// </summary>
    /// <param name="data">data</param>
    public Contains(TProperty data)
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
    /// <exception cref="ArgumentDataTypeInappropriateException"></exception>
    /// <exception cref="RehsaArgumentNullException"></exception>
    /// <returns>Task bool</returns>
    public async Task<bool> ExecuteAsync<TData, TProperty>(ICollectedData<TData> collectedData,
        Func<TData, TProperty> suspectedFunc,
        CancellationToken? cancellationToken = null)
    {
        return await Task.Run(() =>
        {
            var data = suspectedFunc.Invoke(collectedData.GetData());
            if (data is string)
            {
                if (Data is null)
                    throw new RehsaArgumentNullException(nameof(Data));
                return data.ToString().Contains(Data.ToString());
            }
            else
            {
                throw new ArgumentDataTypeInappropriateException(nameof(Data));
            }
        },cancellationToken??new CancellationToken(false));
    }

    /// <summary>
    /// Execute operator
    /// </summary>
    /// <param name="collectedData">Collected data for check rule</param>
    /// <param name="suspectedFunc">Function for select property of Collected data</param>
    /// <typeparam name="TData">Type of collected data</typeparam>
    /// <typeparam name="TProperty">Type of suspected property of collected data</typeparam>
    /// <exception cref="ArgumentDataTypeInappropriateException"></exception>
    /// <exception cref="RehsaArgumentNullException"></exception>
    /// <returns>Task bool</returns>
    public bool Execute<TData, TProperty>(ICollectedData<TData> collectedData, Func<TData, TProperty> suspectedFunc)
    {
        var data = suspectedFunc.Invoke(collectedData.GetData());

        if (data is null)
        {
            throw new RehsaArgumentNullException(nameof(data));
        }

        if (data is string)
        {
            if (Data is null)
                throw new RehsaArgumentNullException(nameof(Data));
            return data.ToString().Contains(Data.ToString());
        }
        else
        {
            throw new ArgumentDataTypeInappropriateException(nameof(data));
        }
    }
}