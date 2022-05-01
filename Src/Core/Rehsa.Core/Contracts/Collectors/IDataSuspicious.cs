using System.Collections;

namespace Rehsa.Core.Contracts.Collectors;

/// <summary>
/// This is a interface that define suspect behavior
/// </summary>
/// <typeparam name="TData"></typeparam>
public interface IDataSuspicious<TData>
{
    /// <summary>
    /// Add a function for suspect on property of Collected data
    /// </summary>
    /// <param name="func"></param>
    /// <returns></returns>
    Rehsa<TData> Suspect(Func<TData, object> func);
}

/// <summary>
/// This is a interface that define suspect behavior on the Enumerable data
/// </summary>
/// <typeparam name="TData"></typeparam>
public interface IEnumerableDataSuspicious<TData>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="func"></param>
    /// <returns></returns>
    Rehsa<TData> Suspects(Func<IEnumerable<TData>, TData> func)}