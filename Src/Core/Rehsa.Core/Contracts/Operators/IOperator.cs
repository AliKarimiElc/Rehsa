using Rehsa.Core.Models;

namespace Rehsa.Core.Contracts.Operators;

/// <summary>
/// the Interface for all types of operators
/// </summary>
public interface IOperator
{
    /// <summary>
    /// Execute operators async
    /// </summary>
    /// <param name="collectedData">Collected data for check rule</param>
    /// <param name="suspectedFunc">Function for select property of Collected data</param>
    /// <param name="cancellationToken">Cancellation token for cancel execution</param>
    /// <typeparam name="TData">Type of collected data</typeparam>
    /// <typeparam name="TProperty">Type of suspected property of collected data</typeparam>
    /// <returns></returns>
    Task<bool> ExecuteAsync<TData,TProperty>(ICollectedData<TData> collectedData, Func<TData, TProperty> suspectedFunc,
        CancellationToken? cancellationToken = null);

    /// <summary>
    /// Execute operator
    /// </summary>
    /// <param name="collectedData">Collected data for check rule</param>
    /// <param name="suspectedFunc">Function for select property of Collected data</param>
    /// <typeparam name="TData">Type of collected data</typeparam>
    /// <typeparam name="TProperty">Type of suspected property of collected data</typeparam>
    /// <returns></returns>
    bool Execute<TData,TProperty>(ICollectedData<TData> collectedData, Func<TData, TProperty> suspectedFunc);

    /// <summary>
    /// Execute operators async
    /// </summary>
    /// <param name="collectedData">Collected data for check rule</param>
    /// <param name="suspectedFunc">Function for select property of Collected data</param>
    /// <param name="cancellationToken">Cancellation token for cancel execution</param>
    /// <typeparam name="TData">Type of collected data</typeparam>
    /// <typeparam name="TProperty">Type of suspected property of collected data</typeparam>
    /// <returns></returns>
    Task<bool> ExecuteAsync<TData, TProperty>(ICollectedData<TData> collectedData, Func<IEnumerable<TData>, TProperty> suspectedFunc,
        CancellationToken? cancellationToken = null);


    /// <summary>
    /// Execute operator
    /// </summary>
    /// <param name="collectedData">Collected data for check rule</param>
    /// <param name="suspectedFunc">Function for select property of Collected data</param>
    /// <typeparam name="TData">Type of collected data</typeparam>
    /// <typeparam name="TProperty">Type of suspected property of collected data</typeparam>
    /// <returns></returns>
    bool Execute<TData,TProperty>(ICollectedData<TData> collectedData, Func<IEnumerable<TData>, TProperty> suspectedFunc);
}