namespace Rehsa.Core.Contracts.Collectors;

public interface IDataCollector<TData>
{
    IDataSuspicious<TData> Collect(object data);
    IDataSuspicious<TData> Collect(TData data);
}