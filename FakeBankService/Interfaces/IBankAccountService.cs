using System;
using System.Collections.Generic;
using FakeBankContract.Interfaces;

namespace FakeBankService.Interfaces
{
    public interface IBankAccountService
    {
        bool Create(int customerId, string name, double initialDeposit);
        List<IBankAccountContract> Get();
        IBankAccountContract GetById(int bankAccountId);
        bool Exists(int bankAccountId);
    }
}
