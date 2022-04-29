using Rehsa.Core.Models;

namespace Rehsa.Core.Operators;


public class GreaterThan<T> where T : IEquatable<T>
{
    private readonly T _data;


    public GreaterThan(T data)
    {
        _data = data;
    }

    public async Task<bool> ExecuteAsync<TData, TProperty>(ICollectedData<TData> collectedData,
        Func<TData, TProperty> suspectedFunc,
        CancellationToken? cancellationToken = null) where TProperty : IEquatable<TProperty>
    {
        return await Task.Run(() =>
        {
            var data = suspectedFunc.Invoke(collectedData.GetData());

            if (_data is int i)
            {
                if (data is IEquatable<T>)
                    return i > Convert.ToInt32(data);
            }

            if (_data is long l)
            {
                if (data is IEquatable<T>)
                    return l > Convert.ToInt64(data);
            }

            if (_data is short s)
            {
                if (data is IEquatable<T>)
                    return s > Convert.ToInt16(data);
            }

            if (_data is double d)
            {
                if (data is IEquatable<T>)
                    return d > Convert.ToDouble(data);
            }

            if (_data is float f)
            {
                if (data is IEquatable<T>)
                    return f > Convert.ToDouble(data);
            }

            if (_data is decimal dc)
            {
                if (data is IEquatable<T>)
                    return dc > Convert.ToDecimal(data);
            }

            throw new ArgumentException();
        });
    }

    public bool Execute<TData, TProperty>(ICollectedData<TData> collectedData, Func<TData, TProperty> suspectedFunc)
        where TProperty : IEquatable<TProperty>
    {
        var data = suspectedFunc.Invoke(collectedData.GetData());

        if (_data is int i)
        {
            if (data is IEquatable<T>)
                return i > Convert.ToInt32(data);
        }

        if (_data is long l)
        {
            if (data is IEquatable<T>)
                return l > Convert.ToInt64(data);
        }

        if (_data is short s)
        {
            if (data is IEquatable<T>)
                return s > Convert.ToInt16(data);
        }

        if (_data is double d)
        {
            if (data is IEquatable<T>)
                return d > Convert.ToDouble(data);
        }

        if (_data is float f)
        {
            if (data is IEquatable<T>)
                return f > Convert.ToDouble(data);
        }

        if (_data is decimal dc)
        {
            if (data is IEquatable<T>)
                return dc > Convert.ToDecimal(data);
        }

        throw new ArgumentException();
    }
}