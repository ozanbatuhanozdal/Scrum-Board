using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Entities.Models;

namespace TestApplication.BusinessLayer.Interfaces
{//ICustomerManager
    public interface ICustomerManager : IManagerBase<Customer>
    {
        Task AddCustomer(Customer customer);
        Task DeleteCustomer(int id);
    }
}
