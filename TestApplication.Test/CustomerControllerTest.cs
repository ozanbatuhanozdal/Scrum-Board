using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.BusinessLayer.Interfaces;
using TestApplication.BusinessLayer.Managers;
using TestApplication.DataAccess.EntityFrameworkCore.Interfaces;
using TestApplication.Entities.Models;
using TestApplication.WebApp.Controllers;
using TestApplication.WebApp.Models.Interfaces;
using Xunit;

namespace TestApplication.Test
{

    public class CustomerControllerTest
    {
        
        private  Mock<ICustomerManager> _mockCustomerManager;
        private  Mock<IMapper> _mockAutoMapper;
        private  Mock<ILoggedUserProvider> _mockLoggedUserProvider;
        
        private  CustomerController _customerController;
       
               
       
        private List<Customer> customers;
        public CustomerControllerTest()
        {
            _mockCustomerManager = new Mock<ICustomerManager>();
            _mockAutoMapper = new Mock<IMapper>();
            _mockLoggedUserProvider = new Mock<ILoggedUserProvider>();
            _customerController = new CustomerController(_mockCustomerManager.Object, _mockAutoMapper.Object, _mockLoggedUserProvider.Object);

            customers = new List<Customer>() { new Customer
            {
                CustomerId = 1,
                CustomerName="VakıfbankAŞ",
                CustomerPhone = "534342",
                CustomerAddress="Ümraniye",
                CreatedDate = DateTime.Now} , { new Customer
            {
                CustomerId = 2,
                CustomerName="Garanti",
                CustomerPhone = "536123",
                CustomerAddress="İzmir",
                CreatedDate = DateTime.Now} } };

        }

        [Fact]
        public async void Index_ActionExecute_ReturnView()
        {
            var result = await _customerController.Index();

            Assert.IsType<ViewResult>(result);

        }
            

    }
}
