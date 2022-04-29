using Rehsa.Core.Contracts.Collectors;
using Rehsa.Core.Contracts.Operators;
using Rehsa.Core.Contracts.Rehsa;
using Rehsa.Core.Contracts.Rule;
using Rehsa.Core.Models;
using Rehsa.Core.Rule;

namespace Rehsa.Core;

public class Rehsa<TData> : IRehsa, IDataCollector<TData>, IDataSuspicious<TData>, IRuleBuilder
{
    public Rehsa()
    {
    }

    public ICollectedData<TData>? CollectedData { get; private set; }
    public Func<TData?,object> SuspectedFunc { get; private set; }
    public IOperator? Operator { get; set; }

    public IDataSuspicious<TData> Collect(object data)
    {
        CollectedData = new CollectedData<TData>(data);
        return this;
    }

    public IDataSuspicious<TData> Collect(TData data)
    {
        CollectedData = new CollectedData<TData>(data);
        return this;
    }

    public Rehsa<TData> Suspect(Func<TData, object> func)
    {
        SuspectedFunc = func;
        return this;
    }

    public IRule Build()
    {
        Validate();
        return new Rule<TData?>(CollectedData, SuspectedFunc, Operator);
    }

    private void Validate()
    {
        if (CollectedData is null)
            throw new ArgumentNullException(nameof(CollectedData), $"{CollectedData} is null");
        if (SuspectedFunc is null)
            throw new ArgumentNullException(nameof(SuspectedFunc), $"{SuspectedFunc} is null");
        if (Operator is null)
            throw new ArgumentNullException(nameof(Operator), $"{Operator} is null");
    }
}