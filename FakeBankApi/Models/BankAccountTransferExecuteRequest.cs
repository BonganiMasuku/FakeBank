using System;
namespace FakeBankApi.Models
{
    public class BankAccountTransferExecuteRequest
    {
        public int FromAccountId { get; set; }
        public int ToAccountId { get; set; }
        public double Amount { get; set; }
    }
}
