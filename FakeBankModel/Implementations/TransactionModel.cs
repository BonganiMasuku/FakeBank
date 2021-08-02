using System;
using System.Collections.Generic;
using FakeBankContract.Implementations;
using FakeBankContract.Interfaces;
using FakeBankModel.Interfaces;

namespace FakeBankModel.Implementations
{
    public class TransactionModel : ITransactionModel
    {
        private List<ITransactionContract> transactionList = new List<ITransactionContract>();

        public bool Add(int accountId, string description, double amount)
        {
            transactionList.Add(new TransactionContract
            {
                Id = transactionList.Count,
                AccountId = accountId,
                Description = description,
                Amount = amount,
                CreatedAt = DateTime.Now
            });

            return true;
        }

        public List<ITransactionContract> GetByAccountId(int accountId)
        {
            var accountTransactionList = new List<ITransactionContract>();

            foreach (var transaction in transactionList)
            {
                if (transaction.AccountId == accountId)
                    accountTransactionList.Add(transaction);
            }

            return accountTransactionList;
        }
    }
}
