using System;
using FakeBankContract.Interfaces;

namespace FakeBankContract.Implementations
{
    public class BankAccountContract : IBankAccountContract
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
