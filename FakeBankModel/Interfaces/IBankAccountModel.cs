using System;
using System.Collections.Generic;
using FakeBankContract.Interfaces;

namespace FakeBankModel.Interfaces
{
    public interface IBankAccountModel
    {
        IBankAccountContract Create(int customerId, string name);
        List<IBankAccountContract> Get();
        IBankAccountContract GetById(int bankAccountId);
        bool Exists(int bankAccountId);
    }
}
