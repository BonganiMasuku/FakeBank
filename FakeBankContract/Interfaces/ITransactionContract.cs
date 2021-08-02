using System;
namespace FakeBankContract.Interfaces
{
    public interface ITransactionContract
    {
        int Id { get; set; }
        int AccountId { get; set; }
        string Description { get; set; }
        double Amount { get; set; }
        DateTime CreatedAt { get; set; }
    }
}
