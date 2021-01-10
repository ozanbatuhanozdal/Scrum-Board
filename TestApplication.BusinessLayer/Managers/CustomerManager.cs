using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestApplication.BusinessLayer.Interfaces;
using TestApplication.DataAccess.EntityFrameworkCore.Interfaces;
using TestApplication.Entities.Models;

namespace TestApplication.BusinessLayer.Managers
{
    public class CustomerManager : ManagerBase<Customer> , ICustomerManager
    {

        private readonly ICustomerRepository _customerRepository;
        
        //customerManager
        public CustomerManager(IRepositoryBase<Customer> repository,ICustomerRepository customerRepository) :base(repository)
        {
            _customerRepository = customerRepository;

        }


        public async Task AddCustomer(Customer customer)
        {
            await _customerRepository.AddCustomer(customer);
        }
    }
}
