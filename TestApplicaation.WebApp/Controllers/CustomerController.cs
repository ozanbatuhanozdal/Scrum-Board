using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApplication.BusinessLayer.Interfaces;
using TestApplication.Common.Dto.CustomerDtos;
using TestApplication.Common.Dto.UserDtos;
using TestApplication.Entities.Models;

namespace TestApplication.WebApp.Controllers
{
    public class CustomerController : Controller
    {

        private readonly ICustomerManager _customerManager;
        private readonly IMapper _mapper;
        public CustomerController(ICustomerManager customerManager,IMapper mapper)
        {
            _customerManager = customerManager;
            _mapper = mapper;

        }
        public async  Task<IActionResult> Index()
        {
            List<Customer> customers = await _customerManager.GetAllASync();
            List<CustomerListDto> customerListDto = _mapper.Map<List<CustomerListDto>>(customers);
            return View(customerListDto);
        }

        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public async  Task<IActionResult> Create(CustomerAddDto model)
        {
            if(ModelState.IsValid)
            {
                
                Customer customer = _mapper.Map<Customer>(model);
               
                await _customerManager.AddAsync(customer);
                return RedirectToAction("Index");
            }
            else
            {

                
            return View(model);

            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            Customer updateCustomer =  await _customerManager.FindById(id);

            CustomerUpdateDto customerUpdateDto = _mapper.Map<CustomerUpdateDto>(updateCustomer);
            return View(customerUpdateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserUpdateDto userUpdateDto)
        {
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(UserChangePasswordDto userChangePasswordDto)
        {
            return View();
        }

        public  IActionResult Detail()
        {
            return View();
        }

    }
}
