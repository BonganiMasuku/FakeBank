using System;
using FakeBankModel.Interfaces;
using FakeBankService.Interfaces;

namespace FakeBankService.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerModel _customerModel;

        public CustomerService(ICustomerModel customerModel)
        {
            _customerModel = customerModel;
        }

        public bool Exists(int customerId)
        {
            return _customerModel.Exists(customerId);
        }
    }
}
