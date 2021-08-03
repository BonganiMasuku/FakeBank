using System;
using System.Collections.Generic;
using FakeBankContract.Interfaces;
using FakeBankModel.Interfaces;
using FakeBankService.Interfaces;

namespace FakeBankService.Implementations
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionModel _transactionModel;

        public TransactionService(ITransactionModel transactionModel)
        {
            _transactionModel = transactionModel;
        }

        public void Add(int accountId, string description, double amount)
        {
            _transactionModel.Add(accountId, description, amount);
        }

        public List<ITransactionContract> GetByAccountId(int accountId)
        {
            return _transactionModel.GetByAccountId(accountId);
        }
    }
}
