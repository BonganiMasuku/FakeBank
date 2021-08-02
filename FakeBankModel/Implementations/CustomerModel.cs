using System;
using System.Collections.Generic;
using System.Linq;
using FakeBankContract.Implementations;
using FakeBankContract.Interfaces;
using FakeBankModel.Interfaces;

namespace FakeBankModel.Implementations
{
    public class CustomerModel : ICustomerModel
    {
        private List<ICustomerContract> customerList = new List<ICustomerContract>();

        public CustomerModel()
        {
            customerList.Add(new CustomerContract
            {
                Id = 1,
                Name = "Arisha Barron"
            });

            customerList.Add(new CustomerContract
            {
                Id = 2,
                Name = "Branden Gibson"
            });

            customerList.Add(new CustomerContract
            {
                Id = 3,
                Name = "Rhonda Church"
            });

            customerList.Add(new CustomerContract
            {
                Id = 4,
                Name = "Georgina Hazel"
            });
        }

        public bool Exists(int customerId)
        {
            return customerList.FindIndex(x => x.Id == customerId) > -1;
        }
    }
}
