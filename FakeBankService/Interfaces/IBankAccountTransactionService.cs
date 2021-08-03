using System;
namespace FakeBankService.Interfaces
{
    public interface IBankAccountTransactionService
    {
        void AddOpeningDeposit(int accountId, double amount);
        double GetBalance(int accountId);
    }
}
