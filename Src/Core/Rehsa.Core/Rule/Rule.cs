using Rehsa.Core.Contracts.Operators;
using Rehsa.Core.Contracts.Rule;

namespace Rehsa.Core.Rule;

/// <summary>
/// Implementation for simple rules
/// </summary>
/// <typeparam name="TData"></typeparam>
public class Rule<TData>:IRule
{
    /// <summary>
    /// Create instance of rule
    /// </summary>
    /// <param name="collectedData"></param>
    /// <param name="suspectedFunc"></param>
    /// <param name="operator"></param>
    public Rule(TData collectedData, Func<TData,object> suspectedFunc, IOperator @operator)
    {
        CollectedData = collectedData;
        SuspectedFunc = suspectedFunc;
        Operator = @operator;
    }

    /// <summary>
    /// Simple collected data
    /// </summary>
    public TData CollectedData { get; set; }
    /// <summary>
    /// function for suspect data
    /// </summary>
    public Func<TData,object> SuspectedFunc { get; set; }
    /// <summary>
    /// one instance of operator to execute on suspectedData
    /// </summary>
    public IOperator Operator { get; set; }

    /// <summary>
    /// Check rule on suspected data
    /// </summary>
    /// <returns></returns>
    public bool Check()
    {
        return Operator.Execute(CollectedData, SuspectedFunc);
    }

    /// <summary>
    /// Async Check rule on suspected data
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<bool> CheckAsync(CancellationToken cancellationToken)
    {
        return await Operator.ExecuteAsync(CollectedData, SuspectedFunc,cancellationToken);
    }
}

public class Rule<TEnumerable,TData> : IRule where TEnumerable : IEnumerable<TData>
{
    public Rule(TData collectedData, Func<IEnumerable<TData>, object> suspectedFunc, IOperator @operator)
    {
        CollectedData = collectedData;
        SuspectedFunc = suspectedFunc;
        Operator = @operator;
    }

    public TData CollectedData { get; set; }
    public Func<IEnumerable<TData>, object> SuspectedFunc { get; set; }
    public IOperator Operator { get; set; }

    public bool Check()
    {
        return Operator.Execute(CollectedData, SuspectedFunc);
    }

    public async Task<bool> CheckAsync(CancellationToken cancellationToken)
    {
        return await Operator.ExecuteAsync(CollectedData, SuspectedFunc, cancellationToken);
    }
}