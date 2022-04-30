using Rehsa.Core.Contracts.Operators;
using Rehsa.Core.Exceptions;
using Rehsa.Core.Models;

namespace Rehsa.Core.Operators;

/// <summary>
/// Check that suspected data of collected data smaller than input data or not
/// </summary>
public class SmallerThan<T> : IConditionalOperator where T : IEquatable<T>
{
    /// <summary>
    /// Condition data
    /// </summary>
    private readonly T _data;

    /// <summary>
    /// Create smaller than conditional operator
    /// </summary>
    /// <param name="data">data</param>
    public SmallerThan(T data)
    {
        _data = data;
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
    /// <returns>Task bool</returns>
    public async Task<bool> ExecuteAsync<TData, TProperty>(ICollectedData<TData> collectedData,
        Func<TData, TProperty> suspectedFunc,
        CancellationToken? cancellationToken = null)
    {
        return await Task.Run(() =>
        {
            var data = suspectedFunc.Invoke(collectedData.GetData());

            return _data switch
            {
                int i when data is IEquatable<T> => i < Convert.ToInt32(data),
                long l when data is IEquatable<T> => l < Convert.ToInt64(data),
                short s when data is IEquatable<T> => s < Convert.ToInt16(data),
                double d when data is IEquatable<T> => d < Convert.ToDouble(data),
                float f when data is IEquatable<T> => f < Convert.ToDouble(data),
                decimal dc when data is IEquatable<T> => dc > Convert.ToDecimal(data),
                _ => throw new ArgumentDataTypeInappropriateException(nameof(_data))
            };
        }, cancellationToken ?? new CancellationToken(false));
    }

    /// <summary>
    /// Execute operator
    /// </summary>
    /// <param name="collectedData">Collected data for check rule</param>
    /// <param name="suspectedFunc">Function for select property of Collected data</param>
    /// <typeparam name="TData">Type of collected data</typeparam>
    /// <typeparam name="TProperty">Type of suspected property of collected data</typeparam>
    /// <exception cref="ArgumentDataTypeInappropriateException"></exception>
    /// <returns>Task bool</returns>
    public bool Execute<TData, TProperty>(ICollectedData<TData> collectedData, Func<TData, TProperty> suspectedFunc)
    {
        var data = suspectedFunc.Invoke(collectedData.GetData());

        return _data switch
        {
            int i when data is IEquatable<T> => i > Convert.ToInt32(data),
            long l when data is IEquatable<T> => l > Convert.ToInt64(data),
            short s when data is IEquatable<T> => s > Convert.ToInt16(data),
            double d when data is IEquatable<T> => d > Convert.ToDouble(data),
            float f when data is IEquatable<T> => f > Convert.ToDouble(data),
            decimal dc when data is IEquatable<T> => dc > Convert.ToDecimal(data),
            _ => throw new ArgumentDataTypeInappropriateException(nameof(_data))
        };
    }
}