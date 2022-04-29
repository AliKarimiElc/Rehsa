using Rehsa.Core.Contracts.Operators;
using Rehsa.Core.Contracts.Rule;
using Rehsa.Core.Models;

namespace Rehsa.Core.Rule;

public class Rule<TData>:IRule
{
    public Rule(ICollectedData<TData> collectedData, Func<TData,object> suspectedFunc, IOperator @operator)
    {
        CollectedData = collectedData;
        SuspectedFunc = suspectedFunc;
        Operator = @operator;
    }

    public ICollectedData<TData> CollectedData { get; set; }
    public Func<TData,object> SuspectedFunc { get; set; }
    public IOperator Operator { get; set; }

    public bool Check()
    {
        return Operator.Execute(CollectedData, SuspectedFunc);
    }

    public async Task<bool> CheckAsync(CancellationToken cancellationToken)
    {
        return await Operator.ExecuteAsync(CollectedData, SuspectedFunc,cancellationToken);
    }
}