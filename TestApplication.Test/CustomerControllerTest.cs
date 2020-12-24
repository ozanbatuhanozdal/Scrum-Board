using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.BusinessLayer.Managers;
using TestApplication.DataAccess.EntityFrameworkCore.Interfaces;
using TestApplication.Entities.Models;
using TestApplication.WebApp.Controllers;

namespace TestApplication.Test
{

    public class CustomerControllerTest
    {
        private readonly Mock<IRepositoryBase<Customer>> _mockRepo;

        private readonly CustomerManager _customerManager;
        

        private List<Customer> customers;

        public CustomerControllerTest()
        {
            _mockRepo = new Mock<IRepositoryBase<Customer>>();
            _customerManager = new CustomerManager(_mockRepo.Object);

        }

    }
}
