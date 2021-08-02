using System;
using System.Collections.Generic;
using FakeBankContract.Interfaces;

namespace FakeBankService.Interfaces
{
    public interface ITransactionService
    {
        bool Add(int accountId, string description, double amount);
        List<ITransactionContract> GetByAccountId(int accountId);
    }
}
