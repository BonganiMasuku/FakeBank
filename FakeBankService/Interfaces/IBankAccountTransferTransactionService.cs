using System;
namespace FakeBankService.Interfaces
{
    public interface IBankAccountTransferTransactionService
    {
        bool AddTransactions(int fromAccountId, int toAccountId, double amount);
    }
}
