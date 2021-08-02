using System;
using System.Collections.Generic;
using FakeBankContract.Interfaces;
using FakeBankModel.Enums;
using FakeBankModel.Interfaces;
using FakeBankService.Interfaces;

namespace FakeBankService.Implementations
{
    public class BankAccountTransferService : IBankAccountTransferService
    {
        private readonly IBankAccountTransferModel _bankAccountTransferModel;
        private readonly IBankAccountTransferTransactionService _bankAccountTransferTransactionService;

        public BankAccountTransferService(
            IBankAccountTransferModel bankAccountTransferModel,
            IBankAccountTransferTransactionService bankAccountTransferTransactionService
            )
        {
            _bankAccountTransferModel = bankAccountTransferModel;
            _bankAccountTransferTransactionService = bankAccountTransferTransactionService;
        }

        public bool Execute(int fromAccountId, int toAccountId, double amount)
        {
            _bankAccountTransferModel.Execute(fromAccountId, toAccountId, amount);
            _bankAccountTransferTransactionService.AddTransactions(fromAccountId, toAccountId, amount);

            return true;
        }

        public List<IBankAccountTransferContract> GetAccountHistory(int accountId, TransferRoleEnum transferRole)
        {
            return _bankAccountTransferModel.GetAccountHistory(accountId, transferRole);
        }
    }
}
