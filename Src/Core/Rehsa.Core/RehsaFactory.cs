using Rehsa.Core.Contracts.Rehsa;

namespace Rehsa.Core;

public class RehsaFactory:IRehsaFactory
{
    public Rehsa<TData> CreateDefault<TData>()
    {
        return new Rehsa<TData>();
    }
}