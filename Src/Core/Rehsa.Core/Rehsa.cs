#nullable enable
using System.Collections;
using Rehsa.Core.Contracts.Collectors;
using Rehsa.Core.Contracts.Operators;
using Rehsa.Core.Contracts.Rehsa;
using Rehsa.Core.Contracts.Rule;
using Rehsa.Core.Rule;

namespace Rehsa.Core;


// /// <summary>
// ///  Rehsa is a start point of rule definition , you can create and apply or check rules in enumerable CollectedData by rehsa
// /// </summary>
// /// <typeparam name="TEnumerable">Enumerable of TData for Collecting data</typeparam>
// /// <typeparam name="TData"></typeparam>
// public class Rehsa<TEnumerable, TData> : IRehsa, IDataCollector<TEnumerable,TData>,
//     IEnumerableDataSuspicious<TEnumerable,TData>, IRuleBuilder where TEnumerable : IEnumerable<TData>
// {
//     /// <summary>
//     /// Collected data , all rule execute on properties of this object
//     /// </summary>
//     public ICollectedData<TData>? CollectedData { get; private set; }
//
//     /// <summary>
//     /// this is a function
//     /// </summary>
//     public Func<IEnumerable<TData>, object>? SuspectedFunc { get; private set; }
//
//     /// <summary>
//     /// This a rule operator
//     /// </summary>
//     public IOperator? Operator { get; set; }
//
//     /// <summary>
//     /// Get collected data
//     /// </summary>
//     /// <param name="data"></param>
//     /// <returns></returns>
//     public IDataSuspicious<TData> Collect(object data)
//     {
//         CollectedData = new CollectedData<TData>(data);
//         return this;
//     }
//
//     /// <summary>
//     /// 
//     /// </summary>
//     /// <param name="func"></param>
//     /// <returns></returns>
//     public Rehsa<TEnumerable, TData> Suspect(Func<IEnumerable<TData>, object> func)
//     {
//         SuspectedFunc = func;
//         return this;
//     }
//
//     /// <summary>
//     /// Build instance of IRule
//     /// </summary>
//     /// <returns></returns>
//     public IRule Build()
//     {
//         Validate();
//         return new Rule<TEnumerable,TData>(CollectedData, SuspectedFunc, Operator);
//     }
//
//     private void Validate()
//     {
//         if (CollectedData is null)
//             throw new ArgumentNullException(nameof(CollectedData), $"{CollectedData} is null");
//         if (SuspectedFunc is null)
//             throw new ArgumentNullException(nameof(SuspectedFunc), $"{SuspectedFunc} is null");
//         if (Operator is null)
//             throw new ArgumentNullException(nameof(Operator), $"{Operator} is null");
//     }
// }

/// <summary>
///  Rehsa is a start point of rule definition , you can create and apply or check rules in CollectedData by rehsa
/// </summary>
/// <typeparam name="TData">Collected data type</typeparam>
public class Rehsa<TData> : IRehsa, IDataCollector<TData>, IDataSuspicious<TData>, IEnumerableDataSuspicious<TData>, IRuleBuilder
{
    /// <summary>
    /// Collected data , all rule execute on properties of this object
    /// </summary>
    public TData? CollectedData { get; private set; }

    /// <summary>
    /// this is a function
    /// </summary>
    public Func<TData, object>? SuspectedFunc { get; private set; }

    /// <summary>
    /// This a rule operator
    /// </summary>
    public IOperator? Operator { get; set; }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="func"></param>
    /// <returns></returns>
    public Rehsa<TData> Suspect(Func<TData, object> func)
    {
        SuspectedFunc = func;
        return this;
    }

    public Rehsa<TData> Suspects(Func<IEnumerable<TData>, TData> func)
    {
        SuspectedFunc = func;
        return this ;
    }

    /// <summary>
    /// Build instance of IRule
    /// </summary>
    /// <returns></returns>
    public IRule Build()
    {
        Validate();
        return new Rule<TData>(CollectedData, SuspectedFunc, Operator);
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

    // Rehsa<IEnumerable<TData>> IEnumerableDataSuspicious<TData>.Suspect(Func<TData, object> func)
    // {
    //     throw new NotImplementedException();
    // }

    public IDataSuspicious<TData> Collect(TData data)
    {
        CollectedData = data;
        return this;
    }
}