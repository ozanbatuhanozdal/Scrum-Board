using System;
using System.Collections.Generic;
using System.Text;
using TestApplication.BusinessLayer.Interfaces;
using TestApplication.DataAccess.EntityFrameworkCore.Interfaces;
using TestApplication.Entities.Models;

namespace TestApplication.BusinessLayer.Managers
{
    public class CustomerManager : ManagerBase<Customer> , ICustomerManager
    {
        public CustomerManager(IRepositoryBase<Customer> repository) :base(repository)
        {

        }
    }
}
