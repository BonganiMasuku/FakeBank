using System;
namespace FakeBankService.Interfaces
{
    public interface IBankAccountTransactionService
    {
        bool AddOpeningDeposit(int accountId, double amount);
        double GetBalance(int accountId);
    }
}
