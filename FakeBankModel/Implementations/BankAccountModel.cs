using System;
using System.Collections.Generic;
using FakeBankContract.Implementations;
using FakeBankContract.Interfaces;
using FakeBankModel.Interfaces;

namespace FakeBankModel.Implementations
{
    public class BankAccountModel : IBankAccountModel
    {
        private List<IBankAccountContract> bankAccountList = new List<IBankAccountContract>();

        public IBankAccountContract Create(int customerId, string name)
        {
            var bankAccount = new BankAccountContract
            {
                Id = bankAccountList.Count,
                CustomerId = customerId,
                Name = name,
                CreatedAt = DateTime.Now
            };

            bankAccountList.Add(bankAccount);

            return bankAccount;
        }

        public List<IBankAccountContract> Get()
        {
            return bankAccountList;
        }

        public IBankAccountContract GetById(int bankAccountId)
        {
            return bankAccountList.Find(x => x.Id == bankAccountId);
        }

        public bool Exists(int bankAccountId)
        {
            return bankAccountList.FindIndex(x => x.Id == bankAccountId) > -1;
        }
    }
}
