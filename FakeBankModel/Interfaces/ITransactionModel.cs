using System;
using System.Collections.Generic;
using FakeBankContract.Interfaces;

namespace FakeBankModel.Interfaces
{
    public interface ITransactionModel
    {
        void Add(int accountId, string description, double amount);
        List<ITransactionContract> GetByAccountId(int accountId);
    }
}
