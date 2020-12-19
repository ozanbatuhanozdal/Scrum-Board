using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Common.Dto.CustomerDtos;
using TestApplication.DataAccess.EntityFrameworkCore.Interfaces;
using TestApplication.Entities.Models;

namespace TestApplication.DataAccess.EntityFrameworkCore.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
      /*
        public async Task<List<Customer>> GetCustomerCards()
        {
            using var context = new DatabaseContext();

            var customerCardList = await context.CustomerCard.Join(context.Customer, x => x.CustomerId, y => y.CustomerId, (customerCard, customer) => new
            {
                customerCard,
                customer,
            }).Join(context.CustomerCardRow, two => two.customerCard.CustomerCardId, ccr => ccr.CustomerCardRowId, (twoTable, customerCardRow) => new
            {
                twoTable.customerCard,
                twoTable.customer,
                customerCardRow
            }).Select(x => new Customer
            {
                CustomerName = x.customer.CustomerName,
                CustomerPhone = x.customer.CustomerPhone,               

            }).ToListAsync();

            return customerCardList;
         */
        }
    }

