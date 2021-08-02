using System;

namespace FakeBankContract.Interfaces
{
    public interface IBankAccountContract
    {
        int Id { get; set; }
        int CustomerId { get; set; }
        string Name { get; set; }
        DateTime CreatedAt { get; set; }
    }
}
