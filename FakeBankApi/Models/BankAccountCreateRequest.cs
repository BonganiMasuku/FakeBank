using System;
namespace FakeBankApi.Models
{
    public class BankAccountCreateRequest
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public double InitialDeposit { get; set; }
    }
}
