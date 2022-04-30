namespace Rehsa.Core.Contracts.Collectors;

/// <summary>
/// Interface for data collector that define collect behaviors
/// </summary>
/// <typeparam name="TData"></typeparam>
public interface IDataCollector<TData>
{
    /// <summary>
    /// Collect data
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    IDataSuspicious<TData> Collect(object data);
}

/// <summary>
/// Interface for data collector that define collect behaviors
/// </summary>
/// <typeparam name="TData"></typeparam>
/// <typeparam name="TEnumerable"></typeparam>
public interface IDataCollector<TEnumerable, TData> where TEnumerable : IEnumerable<TData>
{
    /// <summary>
    /// Collect data
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    IEnumerableDataSuspicious<TEnumerable, TData> Collect(object data);
}