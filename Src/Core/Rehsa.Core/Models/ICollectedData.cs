namespace Rehsa.Core.Models;

public interface ICollectedData<out TData> : ICollectedData
{
    public new TData GetData();
}

public interface ICollectedData
{
    public object GetData();
}