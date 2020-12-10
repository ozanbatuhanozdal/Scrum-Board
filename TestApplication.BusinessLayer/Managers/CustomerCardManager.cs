using System;
using System.Collections.Generic;
using System.Text;
using TestApplication.BusinessLayer.Interfaces;
using TestApplication.DataAccess.EntityFrameworkCore.Interfaces;
using TestApplication.Entities.Models;

namespace TestApplication.BusinessLayer.Managers
{
    public class CustomerCardManager : ManagerBase<CustomerCard>  ,ICustomerCardManager
    {

        public CustomerCardManager(IRepositoryBase<CustomerCard> repository) : base(repository)
        {

        }
    }
}
