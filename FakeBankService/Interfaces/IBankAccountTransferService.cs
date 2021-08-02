using System;
using System.Collections.Generic;
using FakeBankContract.Interfaces;
using FakeBankModel.Enums;

namespace FakeBankService.Interfaces
{
    public interface IBankAccountTransferService
    {
        bool Execute(int fromAccountId, int toAccountId, double amount);
        List<IBankAccountTransferContract> GetAccountHistory(int accountId, TransferRoleEnum transferRole);
    }
}
