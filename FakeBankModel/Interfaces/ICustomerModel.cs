using System;
namespace FakeBankModel.Interfaces
{
    public interface ICustomerModel
    {
        bool Exists(int customerId);
    }
}
