﻿namespace Rehsa.Core.Models;

/// <summary>
/// Collected data container for check rules
/// </summary>
/// <typeparam name="TData"></typeparam>
public partial class CollectedData<TData> : ICollectedData<TData>
{
    /// <summary>
    /// Create new instance of collected data
    /// </summary>
    /// <param name="data"></param>
    public CollectedData(TData data)
    {
        _data = data;
    }

    // /// <summary>
    // /// Create new instance of collectedData
    // /// </summary>
    // /// <param name="data"></param>
    // public CollectedData(object data)
    // {
    //     _data = (TData)data;
    // }

    private readonly TData _data;

    /// <summary>
    /// Get collected data
    /// </summary>
    /// <returns></returns>
    public TData GetData()
    {
        return _data;
    }

}

public partial class EnumerableCollectedData<TData> : ICollectedData<IEnumerable<TData>>
{
    /// <summary>
    /// Create new instance of collected data
    /// </summary>
    /// <param name="data"></param>
    public EnumerableCollectedData(IEnumerable<TData> data)
    {
        _data = data;
    }

    /// <summary>
    /// Create new instance of collectedData
    /// </summary>
    /// <param name="data"></param>
    public EnumerableCollectedData(object data)
    {
        _data = (IEnumerable<TData>)data;
    }

    private readonly IEnumerable<TData> _data;

    /// <summary>
    /// Get collected data
    /// </summary>
    /// <returns></returns>
    public IEnumerable<TData> GetData()
    {
        return _data;
    }

}