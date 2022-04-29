namespace Rehsa.Core.Models;

public class SuspectedData : ISuspectedData
{
    private readonly object _data;

    public SuspectedData(object data)
    {
        _data = data;
    }

    public TData GetData<TData>()
    {
        return (TData)_data;
    }
}