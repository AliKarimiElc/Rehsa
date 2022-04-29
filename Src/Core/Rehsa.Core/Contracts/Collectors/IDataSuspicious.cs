namespace Rehsa.Core.Contracts.Collectors;

public interface IDataSuspicious<TData>
{
    Rehsa<TData> Suspect(Func<TData, object> func);
}