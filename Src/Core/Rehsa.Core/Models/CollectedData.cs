namespace Rehsa.Core.Models;

public class CollectedData<TData> : ICollectedData<TData>
{
    public CollectedData(TData data)
    {
        _data = data;
    }

    public CollectedData(object data)
    {
        _data = (TData)data;
    }

    private readonly TData _data;
    public TData GetData()
    {
        return _data;
    }

    object ICollectedData.GetData()
    {
        return GetData();
    }
}

public class CollectedData : ICollectedData
{
    public CollectedData(object data)
    {
        _data = data;
    }

    private readonly object _data;
    public object GetData()
    {
        return _data;
    }
}