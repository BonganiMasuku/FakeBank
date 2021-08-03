using System;
using FakeBankModel.Interfaces;
using FakeBankService.Interfaces;

namespace FakeBankService.Implementations
{
    public class BankAccountTransactionService : IBankAccountTransactionService
    {
        private readonly ITransactionModel _transactionModel;

        public BankAccountTransactionService(ITransactionModel transactionModel)
        {
            _transactionModel = transactionModel;
        }

        public void AddOpeningDeposit(int accountId, double amount)
        {
            _transactionModel.Add(accountId, "Opening Deposit", amount);
        }

        public double GetBalance(int bankAccountId)
        {
            var transactions = _transactionModel.GetByAccountId(bankAccountId);

            double balance = 0;

            foreach (var x in transactions)
            {
                balance += x.Amount;
            }

            return balance;
        }
    }
}
