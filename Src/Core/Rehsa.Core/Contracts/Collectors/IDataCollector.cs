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
    IDataSuspicious<TData> Collect(TData data);
}

/// <summary>
/// Interface for data collector that define collect behaviors
/// </summary>
/// <typeparam name="TData"></typeparam>
/// <typeparam name="TEnumerable"></typeparam>
public interface IEnumerableDataCollector<TData>
{
    /// <summary>
    /// Collect data
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    IEnumerableDataSuspicious<TData> Collect(IEnumerable<TData> data);
}