using System;
using FakeBankContract.Interfaces;

namespace FakeBankContract.Implementations
{
    public class TransactionContract : ITransactionContract
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
