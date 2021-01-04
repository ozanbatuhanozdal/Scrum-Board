using System;
using System.Collections.Generic;
using System.Text;
using TestApplication.DataAccess.EntityFrameworkCore.Interfaces;
using TestApplication.Entities;

namespace TestApplication.DataAccess.EntityFrameworkCore.Repositories
{   //entity bazlı somut repository sınıflarımızdır.
    //CustomerCardRowRepository
    public class CustomerCardRowRepository : RepositoryBase<CustomerCardRow> , ICustomerCardRowRepository
    {
    }
}
