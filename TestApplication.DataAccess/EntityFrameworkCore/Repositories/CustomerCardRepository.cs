using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Common.Dto.CustomerCardDtos;
using TestApplication.DataAccess.EntityFrameworkCore.Interfaces;
using TestApplication.Entities.Models;

namespace TestApplication.DataAccess.EntityFrameworkCore.Repositories
{
    public class CustomerCardRepository : RepositoryBase<CustomerCard> , ICustomerCardRepository
    {

       /*
        public async Task<List<CustomerCard>> GetCustomerCards()
        {
            using var context = new DatabaseContext();
            List<CustomerCardListDto> customerCards = new List<CustomerCardListDto>();

            var customerCardList = await context.CustomerCard.Join(context.Customer, x=> x.CustomerId, y => y.CustomerId,(customerCard,customer) => new { 
            customerCard,
            customer,
            }).Join(context.CustomerCardRow, two => two.customerCard.CustomerCardId, ccr => ccr.CustomerCardRowId,(twoTable,customerCardRow) => new
            {
                twoTable.customerCard,
                twoTable.customer,
                customerCardRow
            }).Select( x=> new CustomerCard
            {
                CustomerCardId = x.customerCard.CustomerCardId,
                CustomerCardName = x.customerCard.CustomerCardName,
                CustomerId = x.customerCard.CustomerId,
                CustomerCardRows = x.customerCardRow


            }

        }
        */
    }
}
