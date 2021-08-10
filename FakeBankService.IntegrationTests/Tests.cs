using System;
using FakeBankContract.Implementations;
using FakeBankContract.Interfaces;
using FakeBankModel.Implementations;
using FakeBankModel.Interfaces;
using FakeBankService.Implementations;
using FakeBankService.Interfaces;
using Lamar;
using NUnit.Framework;

namespace FakeBankService.IntegrationTests
{
    [TestFixture]
    public class Tests
    {
        private IContainer _iocContainer;

        [SetUp]
        public void Setup()
        {
            _iocContainer = BootstrapContainer();
        }

        private IContainer BootstrapContainer()
        {
            return new Container(x =>
            {
                x.For<ICustomerModel>().Use<CustomerModel>();
                x.For<ITransactionModel>().Use<TransactionModel>();
                x.For<IBankAccountTransferModel>().Use<BankAccountTransferModel>();
                x.For<IBankAccountModel>().Use<BankAccountModel>();

                x.For<ICustomerService>().Use<CustomerService>();
                x.For<ITransactionService>().Use<TransactionService>();
                x.For<IBankAccountTransactionService>().Use<BankAccountTransactionService>();
                x.For<IBankAccountTransferTransactionService>().Use<BankAccountTransferTransactionService>();
                x.For<IBankAccountTransferService>().Use<BankAccountTransferService>();
                x.For<IBankAccountService>().Use<BankAccountService>();
            });
        }

        [Test]
        public void BankAccountServiceTests()
        {
            int customerId = 1;
            double initialDeposit = 100.50;
            string bankAccountName = "Mock Bank Account";

            var bankAccountService = _iocContainer.GetInstance<IBankAccountService>();
            var bankAccountTransactionService = _iocContainer.GetInstance<IBankAccountTransactionService>();

            var bankAccountId = bankAccountService.Create(customerId, bankAccountName, initialDeposit);
            Assert.AreEqual(bankAccountId, 0);

            var bankAccounts = bankAccountService.Get();
            Assert.AreEqual(bankAccounts.Count, 1);

            var bankAccount = bankAccountService.GetById(bankAccountId);
            var index = bankAccounts.FindIndex(x => x.Id == bankAccount.Id);

            Assert.AreEqual(bankAccountId, bankAccount.Id);
            Assert.AreEqual(customerId, bankAccount.CustomerId);
            Assert.AreEqual(bankAccountName, bankAccount.Name);

            var bankAccountExists = bankAccountService.Exists(bankAccountId);
            Assert.AreEqual(true, bankAccountExists);
        }
    }
}
