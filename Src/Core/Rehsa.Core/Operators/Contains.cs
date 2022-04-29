﻿using Rehsa.Core.Contracts.Operators;
using Rehsa.Core.Models;

namespace Rehsa.Core.Operators
{
    public class Contains<TProperty> : IConditionalOperator
    {
        public TProperty Data { get; set; }

        public Contains(TProperty data)
        {
            Data = data;
        }
        public async Task<bool> ExecuteAsync<TData,TProperty>(ICollectedData<TData> collectedData, Func<TData, TProperty> suspectedFunc,
            CancellationToken? cancellationToken = null)
        {
            return await Task.Run(() =>
            {
                var data = suspectedFunc.Invoke(collectedData.GetData());
                if (data.GetType() is string)
                {
                    return data.ToString().Contains(Data.ToString());
                }
                else
                {
                    throw new ArgumentException();
                }
            });
        }

        public bool Execute<TData,TProperty>(ICollectedData<TData> collectedData, Func<TData, TProperty> suspectedFunc)
        {
            var data = suspectedFunc.Invoke(collectedData.GetData());

            if (data is null)
            {
                throw new ArgumentNullException();
            }

            if (data.GetType() == null)
                throw new ArgumentNullException();

            if (data.GetType() == typeof(string))
            {
                return data.ToString().Contains(Data.ToString());
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}