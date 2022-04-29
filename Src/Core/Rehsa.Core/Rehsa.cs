using Rehsa.Core.Contracts.Collectors;
using Rehsa.Core.Contracts.Operators;
using Rehsa.Core.Contracts.Rule;
using Rehsa.Core.Models;
using Rehsa.Core.Operators;
using Rehsa.Core.Rule;

namespace Rehsa.Core;

public interface IRehsa
{

}

public class Rehsa<TData> : IRehsa, IDataCollector<TData>, IDataSuspicious<TData>, IOperatorDefiner, IRuleBuilder
{
    public Rehsa(IServiceProvider serviceProvider)
    {
        var t = serviceProvider.GetService(typeof(IServiceProvider)) as IOperatorDefiner;
    }

    public ICollectedData<TData>? CollectedData { get; private set; }
    public Func<TData?, object>? SuspectedFunc { get; private set; }

    public IOperator? Operator { get; private set; }

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

    public IOperatorDefiner Suspect(Func<TData, object> func)
    {
        SuspectedFunc = func;
        return this;
    }

    public IRuleBuilder EqualWith<TSData>(TSData data)
    {
        Operator = new EqualWith(data);
        return this;
    }

    public IRuleBuilder NotEqualWith<TSData>(TSData data)
    {
        Operator = new NotEqualWith(data);
        return this;
    }

    public IRuleBuilder True()
    {
        Operator = new True();
        return this;
    }

    public IRuleBuilder False()
    {
        Operator = new False();
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