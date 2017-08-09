using System;
using Demo.Utility.Transactions;

namespace Demo.Domain.Transactions.BaseTransaction
{
    /// <summary>
    /// http://martinfowler.com/eaaCatalog/transactionScript.html
    /// </summary>
    /// <typeparam name="TOutput">Type that will be Returned when transaction is ran</typeparam>
    public abstract class TransactionScript<TOutput>
    {
        protected TransactionScript()
        {
            TransactionsEnabled = true;
        }

        protected virtual void RollbackCalls() { }
        protected abstract TOutput ExecuteCalls();
        protected TOutput ReturnData;

        public TOutput PerformTransaction()
        {
            try
            {
                if (TransactionsEnabled)
                {
                    using (var scope = TransactionFactory.CreateTransactionScope())
                    {
                        ReturnData = ExecuteCalls();
                        scope.Complete();
                        return ReturnData;
                    }
                }
                return ExecuteCalls();
            }
            catch (Exception)
            {
                RollbackCalls();
                throw;
            }
        }

        protected bool TransactionsEnabled { get; set; }
    }

    /// <summary>
    /// http://martinfowler.com/eaaCatalog/transactionScript.html
    /// </summary>
    /// <typeparam name="TInput">Type that will be Returned when transaction is ran</typeparam>
    /// /// <typeparam name="TOutput">Type that is passedin</typeparam>
    public abstract class TransactionScript<TInput, TOutput>
    {
        protected TransactionScript()
        {
            TransactionsEnabled = true;
        }

        protected virtual void RollbackCalls() { }
        protected abstract TOutput ExecuteCalls(TInput operand);
        protected TOutput ReturnData;

        public TOutput PerformTransaction(TInput input)
        {
            try
            {
                if (TransactionsEnabled)
                {
                    using (var scope = TransactionFactory.CreateTransactionScope())
                    {
                        ReturnData = ExecuteCalls(input);
                        scope.Complete();
                        return ReturnData;
                    }
                }
                return ExecuteCalls(input);
            }
            catch (Exception)
            {
                RollbackCalls();
                throw;
            }
        }

        protected bool TransactionsEnabled { get; set; }
    }

    /// <summary>
    /// http://martinfowler.com/eaaCatalog/transactionScript.html
    /// </summary>
    /// <typeparam name="TInput">Type that will be Returned when transaction is ran</typeparam>
    /// /// <typeparam name="TOutput">Type that is passedin</typeparam>
    public abstract class TransactionScriptVoid<TInput>
    {
        protected TransactionScriptVoid()
        {
            TransactionsEnabled = true;
        }

        protected virtual void RollbackCalls() { }
        protected abstract void ExecuteCalls(TInput input);


        public void PerformTransaction(TInput input)
        {
            try
            {
                if (TransactionsEnabled)
                {
                    using (var scope = TransactionFactory.CreateTransactionScope())
                    {
                        ExecuteCalls(input);
                        scope.Complete();
                        return;
                    }
                }
                ExecuteCalls(input);
            }
            catch (Exception)
            {
                RollbackCalls();
                throw;
            }
        }

        protected bool TransactionsEnabled { get; set; }
    }
}
