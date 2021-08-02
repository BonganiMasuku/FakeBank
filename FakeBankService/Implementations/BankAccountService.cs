using System;
using System.Collections.Generic;
using FakeBankContract.Interfaces;
using FakeBankModel.Interfaces;
using FakeBankService.Interfaces;

namespace FakeBankService.Implementations
{
    public class BankAccountService : IBankAccountService
    {
        private readonly IBankAccountModel _bankAccountModel;
        private readonly IBankAccountTransactionService _bankAccountTransactionService;

        public BankAccountService(
            IBankAccountModel bankAccountModel,
            IBankAccountTransactionService bankAccountTransactionService
            )
        {
            _bankAccountModel = bankAccountModel;
            _bankAccountTransactionService = bankAccountTransactionService;
        }

        public bool Create(int customerId, string name, double initialDeposit)
        {
            var newBankAccount = _bankAccountModel.Create(customerId, name);
            return _bankAccountTransactionService.AddOpeningDeposit(newBankAccount.Id, initialDeposit);
        }

        public List<IBankAccountContract> Get()
        {
            return _bankAccountModel.Get();
        }

        public IBankAccountContract GetById(int bankAccountId)
        {
            return _bankAccountModel.GetById(bankAccountId);
        }

        public bool Exists(int bankAccountId)
        {
            return _bankAccountModel.Exists(bankAccountId);
        }
    }
}
