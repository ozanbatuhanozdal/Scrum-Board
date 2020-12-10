using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApplication.BusinessLayer.Interfaces;
using TestApplication.Common.Dto.CustomerCardDtos;
using TestApplication.Common.Dto.CustomerDtos;
using TestApplication.Entities.Models;
using TestApplication.WebApp.Models.Interfaces;

namespace TestApplication.WebApp.Controllers
{
    public class CustomerCardController : BaseController
    {

        private readonly ICustomerCardManager _customerCardManager;
        private readonly ICustomerManager _customerManager;
        private readonly IMapper _mapper;


        public CustomerCardController(ILoggedUserProvider loggedUserProvider,ICustomerCardManager customerCardManager,IMapper mapper,ICustomerManager customerManager) :base(loggedUserProvider)
        {
            _customerCardManager = customerCardManager;
            _customerManager = customerManager;
            _mapper = mapper;
        }


      
        public async Task<IActionResult> Index()
        {
            List<CustomerCard> customerCards = await _customerCardManager.GetAllASync();

            List<Customer> customers = await _customerManager.GetAllASync();

            customers.ForEach(x =>
            {
                customerCards.ForEach(y =>
                {
                   if(x.CustomerId == y.CustomerId)
                    {
                        x.CustomerCards.Add(y);
                    }
                });
            });

            List<CustomerCardListDto> empty = new List<CustomerCardListDto>();

            //List<CustomerListDto> customerListDto = _mapper.Map<List<CustomerListDto>>(customers);
            return View(empty);
        }

        public async  Task<IActionResult> Create()
        {
            ViewBag.CustomerId = new SelectList(await _customerManager.GetAllASync(), "CustomerId", "CustomerName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerAddDto model)
        {
            if (ModelState.IsValid)
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
            Customer updateCustomer = await _customerManager.FindById(id);

            CustomerUpdateDto customerUpdateDto = _mapper.Map<CustomerUpdateDto>(updateCustomer);
            return View(customerUpdateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CustomerUpdateDto customerUpdateDto)
        {
            if (ModelState.IsValid)
            {
                Customer updatedCustomer = await _customerManager.FindById(customerUpdateDto.CustomerId);
                if (updatedCustomer == null)
                {
                    return View(customerUpdateDto);
                }
                updatedCustomer = _mapper.Map<Customer>(customerUpdateDto);
                await _customerManager.UpdateAsync(updatedCustomer);
                return RedirectToAction("Index");
            }
            else
            {


                return View(customerUpdateDto);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            Customer deletedCustomer = await _customerManager.FindById(id);

            CustomerListDto customer = _mapper.Map<CustomerListDto>(deletedCustomer);

            return View(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CustomerListDto customerListDto)
        {
            Customer deletedCustomer = _mapper.Map<Customer>(customerListDto);
            await _customerManager.RemoveAsync(deletedCustomer);
            return RedirectToAction("Index");
        }

        public IActionResult Detail()
        {
            return View();
        }
    }
}
