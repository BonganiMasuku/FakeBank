using System;
namespace FakeBankService.Interfaces
{
    public interface IBankAccountTransferTransactionService
    {
        void AddTransactions(int fromAccountId, int toAccountId, double amount);
    }
}
