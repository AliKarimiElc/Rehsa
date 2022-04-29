namespace Rehsa.Core.Contracts.Rehsa;

public interface IRehsaFactory
{
    Rehsa<TData> CreateDefault<TData>();
}