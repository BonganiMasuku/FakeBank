using System;
using FakeBankModel.Interfaces;
using FakeBankService.Interfaces;

namespace FakeBankService.Implementations
{
    public class BankAccountTransferTransactionService : IBankAccountTransferTransactionService
    {
        private readonly ITransactionModel _transactionModel;

        public BankAccountTransferTransactionService(ITransactionModel transactionModel)
        {
            _transactionModel = transactionModel;
        }

        public void AddTransactions(int fromAccountId, int toAccountId, double amount)
        {
            var description = "Inter-account Transfer";

            _transactionModel.Add(fromAccountId, description, amount * -1);
            _transactionModel.Add(toAccountId, description, amount);
        }
    }
}
