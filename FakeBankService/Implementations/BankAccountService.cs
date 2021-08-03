using System;
using System.Collections.Generic;
using FakeBankContract.Interfaces;
using FakeBankModel.Interfaces;
using FakeBankService.Interfaces;

namespace FakeBankService.Implementations
{
    public class BankAccountService : IBankAccountService
    {
        private readonly ICustomerService _customerService;
        private readonly IBankAccountModel _bankAccountModel;
        private readonly IBankAccountTransactionService _bankAccountTransactionService;

        public BankAccountService(
            ICustomerService customerService,
            IBankAccountModel bankAccountModel,
            IBankAccountTransactionService bankAccountTransactionService
            )
        {
            _customerService = customerService;
            _bankAccountModel = bankAccountModel;
            _bankAccountTransactionService = bankAccountTransactionService;
        }

        public void Create(int customerId, string name, double initialDeposit)
        {
            try
            {
                var newBankAccount = _bankAccountModel.Create(customerId, name);

                var exists = _customerService.Exists(customerId);
                if (!exists)
                {
                    throw new Exception("Customer not found with provided Id");
                }

                _bankAccountTransactionService.AddOpeningDeposit(newBankAccount.Id, initialDeposit);
            }
            catch (Exception e)
            {
                throw;
            }
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
