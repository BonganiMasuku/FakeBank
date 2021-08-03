using System;
using System.Collections.Generic;
using FakeBankContract.Implementations;
using FakeBankContract.Interfaces;
using FakeBankModel.Enums;
using FakeBankModel.Interfaces;

namespace FakeBankModel.Implementations
{
    public class BankAccountTransferModel : IBankAccountTransferModel
    {
        private List<IBankAccountTransferContract> bankAccountTransferList = new List<IBankAccountTransferContract>();

        public void Execute(int fromAccountId, int toAccountId, double amount)
        {
            bankAccountTransferList.Add(new BankAccountTransferContract
            {
                Id = bankAccountTransferList.Count,
                FromAccountId = fromAccountId,
                ToAccountId = toAccountId,
                Amount = amount,
                CreatedAt = DateTime.Now
            });
        }

        public List<IBankAccountTransferContract> GetAccountHistory(int accountId, TransferRoleEnum transferRole)
        {
            var accountHistoryList = new List<IBankAccountTransferContract>();

            foreach (var transfer in bankAccountTransferList)
            {
                if (transferRole == TransferRoleEnum.Sender)
                {
                    if (transfer.FromAccountId == accountId)
                        accountHistoryList.Add(transfer);
                }

                if (transferRole == TransferRoleEnum.Receiver)
                {
                    if (transfer.ToAccountId == accountId)
                        accountHistoryList.Add(transfer);
                }
            }

            return accountHistoryList;
        }
    }
}
