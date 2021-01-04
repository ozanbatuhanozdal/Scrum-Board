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
using TestApplication.Common.Dto.CustomerDtos;
using TestApplication.DataAccess.EntityFrameworkCore.Interfaces;
using TestApplication.Entities.Models;
using TestApplication.WebApp.Controllers;
using TestApplication.WebApp.Models.Interfaces;
using Xunit;

namespace TestApplication.Test
{
    //customer controller test
    public class CustomerControllerTest
    {
        
        private  Mock<ICustomerManager> _mockCustomerManager;
        private  Mock<IMapper> _mockAutoMapper;
        private  Mock<ILoggedUserProvider> _mockLoggedUserProvider;
        
        //test edeceğimi controller customer controllerdır.
        private  CustomerController _customerController;



        private List<Customer> customers;
        private List<CustomerAddDto> customerAddDtos;
        public CustomerControllerTest()
        {
            //const. ınitial ediyoruz.
            _mockCustomerManager = new Mock<ICustomerManager>();
            _mockAutoMapper = new Mock<IMapper>();
            _mockLoggedUserProvider = new Mock<ILoggedUserProvider>();
            //customer controllerı mockladık.
            _customerController = new CustomerController(_mockCustomerManager.Object, _mockAutoMapper.Object, _mockLoggedUserProvider.Object);
            //customer olusturuyoruz
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

            customerAddDtos = new List<CustomerAddDto>() { new CustomerAddDto
            {
                
                CustomerName="VakıfbankAŞ",
                CustomerPhone = "534342",
                CustomerAddress="Ümraniye",
                } , { new CustomerAddDto
            {
               
                CustomerName="Garanti",
                CustomerPhone = "536123",
                CustomerAddress="İzmir",
                } } };

        }

        //isimlendirme kuralına göre
        //test edilen metot-Action'ın çalışma durumunu test ediliyor-geriye view dönmesini bekliyoruz.

        [Fact]
        public async void Index_ActionExecute_ReturnView()
        {
            var result = await _customerController.Index();
            // gelen result ın ViewResult  olup olmadığını test ediyoruz. 
            Assert.IsType<ViewResult>(result);

        }
        //index metodumuzun geriye bir list dönüp dönmediğini test ediyoruz.
        [Fact]
        public async void Index_ActionExecute_ReturnCustomerList()
        {
            _mockCustomerManager.Setup(repo => repo.GetAllASync()).ReturnsAsync(customers);

            var result = await _customerController.Index();            

            var viewResult = Assert.IsType<ViewResult>(result);            
            Assert.Equal<int>(2, customers.Count());
        }

        //create view test
        [Fact]
        public  void Create_ActionExecute_ReturnView()
        {
            var result =  _customerController.Create();

            Assert.IsType<ViewResult>(result);

        }


        //create metodunun post edilmesi durumunu test ediyoruz.
        //hata verdiğimiz zaman ındexe yönelmek yerine aynı sayfaya yöneliyor mu onu test ediyoruz.
        [Fact]
        public async void Create_InvalidModelState_ReturnView()
        {
            _customerController.ModelState.AddModelError("Name", "Name Alanı Boş Geçilemez");

            var result = await _customerController.Create(customerAddDtos.First());

            var viewResult = Assert.IsType<ViewResult>(result);

            Assert.IsType<CustomerAddDto>(viewResult.Model);
        }


    }
}
