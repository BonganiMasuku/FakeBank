using System;
namespace FakeBankService.Interfaces
{
    public interface ICustomerService
    {
        bool Exists(int customerId);
    }
}
