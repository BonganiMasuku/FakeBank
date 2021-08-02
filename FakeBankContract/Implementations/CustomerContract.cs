using System;
using FakeBankContract.Interfaces;

namespace FakeBankContract.Implementations
{
    public class CustomerContract : ICustomerContract
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
