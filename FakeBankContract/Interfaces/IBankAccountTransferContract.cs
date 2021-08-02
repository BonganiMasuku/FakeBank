using System;
namespace FakeBankContract.Interfaces
{
    public interface IBankAccountTransferContract
    {
        int Id { get; set; }
        int FromAccountId { get; set; }
        int ToAccountId { get; set; }
        double Amount { get; set; }
        DateTime CreatedAt { get; set; }
    }
}
