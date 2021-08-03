using System;
using System.Collections.Generic;
using FakeBankContract.Interfaces;
using FakeBankModel.Enums;

namespace FakeBankModel.Interfaces
{
    public interface IBankAccountTransferModel
    {
        void Execute(int fromAccountId, int toAccountId, double amount);
        List<IBankAccountTransferContract> GetAccountHistory(int accountId, TransferRoleEnum transferRole);
    }
}
