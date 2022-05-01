using Rehsa.Core.Operators;

namespace Rehsa.Core;

public static partial class OperatorDefiner
{
    public static Rehsa<IEnumerable<TData>> Any<TData>(this Rehsa<IEnumerable<TData>> rehsa,TData data)
    {
        rehsa.Operator = new Contains<TData>(data);
        return rehsa;
    }


    public static Rehsa<TData> EqualWith<TData,TSuspectedProperty>(this Rehsa<TData> rehsa, TSuspectedProperty data)
    {
        rehsa.Operator = new EqualWith(data);
        return rehsa;
    }
    
    public static Rehsa<TData> NotEqualWith<TData, TSuspectedProperty>(this Rehsa<TData> rehsa, TSuspectedProperty data)
    {
         rehsa.Operator = new NotEqualWith(data);
         return rehsa;
    }
    
    public static Rehsa<TData> True<TData>(this Rehsa<TData> rehsa)
    {
        rehsa.Operator = new True();
        return rehsa;
    }

    public static Rehsa<TData> False<TData>(this Rehsa<TData> rehsa)
    {
        rehsa.Operator = new False();
        return rehsa;
    }

    public static Rehsa<TData> Contains<TData>(this Rehsa<TData> rehsa,string data)
    {
        rehsa.Operator = new Contains<string>(data);
        return rehsa;
    }
}