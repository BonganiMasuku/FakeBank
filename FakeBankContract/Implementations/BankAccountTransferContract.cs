using System;
using FakeBankContract.Interfaces;

namespace FakeBankContract.Implementations
{
    public class BankAccountTransferContract : IBankAccountTransferContract
    {
        public int Id { get; set; }
        public int FromAccountId { get; set; }
        public int ToAccountId { get; set; }
        public double Amount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
