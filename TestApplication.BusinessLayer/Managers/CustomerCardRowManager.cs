using System;
using System.Collections.Generic;
using System.Text;
using TestApplication.BusinessLayer.Interfaces;
using TestApplication.DataAccess.EntityFrameworkCore.Interfaces;
using TestApplication.Entities;
using TestApplication.Entities.Models;

namespace TestApplication.BusinessLayer.Managers
{
    public class CustomerCardRowManager : ManagerBase<CustomerCardRow> ,ICustomerCardRowManager
    {
        public CustomerCardRowManager(IRepositoryBase<CustomerCardRow> repositoryBase) :base(repositoryBase)
        {

        }
    }
}
