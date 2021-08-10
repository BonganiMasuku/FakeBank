using System;
using FakeBankContract.Implementations;
using FakeBankContract.Interfaces;
using FakeBankModel.Interfaces;
using FakeBankService.Implementations;
using FakeBankService.Interfaces;
using Lamar;
using Moq;
using NUnit.Framework;

namespace FakeBankService.UnitTests
{
    [TestFixture]
    public class BankAccountServiceTests
    {
        private IContainer _iocContainer;

        private Mock<ICustomerModel> _customerModel;
        private Mock<ITransactionModel> _transactionModel;
        private Mock<IBankAccountTransferModel> _bankAccountTransferModel;
        private Mock<IBankAccountModel> _bankAccountModel;

        private Mock<ICustomerService> _customerService;
        private Mock<ITransactionService> _transactionService;
        private Mock<IBankAccountTransactionService> _bankAccountTransactionService;
        private Mock<IBankAccountTransferTransactionService> _bankAccountTransferTransactionService;
        private Mock<IBankAccountTransferService> _bankAccountTransferService;
        private Mock<IBankAccountService> _bankAccountService;

        [SetUp]
        public void Setup()
        {
            _customerModel.Reset();
            _transactionModel.Reset();
            _bankAccountTransferModel.Reset();
            _bankAccountModel.Reset();

            _customerService.Reset();
            _transactionService.Reset();
            _bankAccountTransactionService.Reset();
            _bankAccountTransferTransactionService.Reset();
            _bankAccountTransferService.Reset();
            _bankAccountService.Reset();
        }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            SetupMocks();
            _iocContainer = BootstrapContainer();
        }

        private void SetupMocks()
        {
            _customerModel = new Mock<ICustomerModel>();
            _transactionModel = new Mock<ITransactionModel>();
            _bankAccountTransferModel = new Mock<IBankAccountTransferModel>();
            _bankAccountModel = new Mock<IBankAccountModel>();

            _customerService = new Mock<ICustomerService>();
            _transactionService = new Mock<ITransactionService>();
            _bankAccountTransactionService = new Mock<IBankAccountTransactionService>();
            _bankAccountTransferTransactionService = new Mock<IBankAccountTransferTransactionService>();
            _bankAccountTransferService = new Mock<IBankAccountTransferService>();
            _bankAccountService = new Mock<IBankAccountService>();
        }

        private IContainer BootstrapContainer()
        {
            return new Container(x =>
            {
                x.For<ICustomerModel>().Use(_customerModel.Object);
                x.For<ITransactionModel>().Use(_transactionModel.Object);
                x.For<IBankAccountTransferModel>().Use(_bankAccountTransferModel.Object);
                x.For<IBankAccountModel>().Use(_bankAccountModel.Object);

                x.For<ICustomerService>().Use(_customerService.Object);
                x.For<ITransactionService>().Use(_transactionService.Object);
                x.For<IBankAccountTransactionService>().Use(_bankAccountTransactionService.Object);
                x.For<IBankAccountTransferTransactionService>().Use(_bankAccountTransferTransactionService.Object);
                x.For<IBankAccountTransferService>().Use(_bankAccountTransferService.Object);
                x.For<IBankAccountService>().Use<BankAccountService>();
            });
        }

        [Test]
        public void CreateBankAccount_Success_ShouldReturnNewBankAccountNumber()
        {
            int customerId = 1;
            double initialDeposit = 100.50;
            string bankAccountName = "Mock Bank Account";

            IBankAccountContract bankAccountContract = new BankAccountContract
            {
                Id = 0,
                CustomerId = customerId,
                Name = bankAccountName,
                CreatedAt = DateTime.Now
            };

            _customerService.Setup(x => x.Exists(It.IsAny<int>())).Returns(true);
            _bankAccountModel.Setup(x => x.Create(It.IsAny<int>(), It.IsAny<string>())).Returns(bankAccountContract);
            _bankAccountTransactionService.Setup(x => x.AddOpeningDeposit(It.IsAny<int>(), It.IsAny<double>()));

            var service = _iocContainer.GetInstance<IBankAccountService>();
            var response = service.Create(customerId, bankAccountName, initialDeposit);

            Assert.AreEqual(response, It.IsAny<int>());
            _customerService.Verify(x => x.Exists(It.IsAny<int>()), Times.Once);
            _bankAccountModel.Verify(x => x.Create(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
            _bankAccountTransactionService.Verify(x => x.AddOpeningDeposit(It.IsAny<int>(), It.IsAny<double>()), Times.Once);
        }
    }
}
