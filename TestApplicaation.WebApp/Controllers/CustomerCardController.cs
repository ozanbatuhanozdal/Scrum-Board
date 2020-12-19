using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApplication.BusinessLayer.Interfaces;
using TestApplication.Common.Dto.CustomerCardDtos;
using TestApplication.Common.Dto.CustomerCardRowDtos;
using TestApplication.Common.Dto.CustomerDtos;
using TestApplication.Entities;
using TestApplication.Entities.Models;
using TestApplication.WebApp.Models.Interfaces;

namespace TestApplication.WebApp.Controllers
{
    public class CustomerCardController : BaseController
    {

        private readonly ICustomerCardManager _customerCardManager;
        private readonly ICustomerManager _customerManager;
        private readonly IUserManager _userManager;
        private readonly IMapper _mapper;


        public CustomerCardController(ILoggedUserProvider loggedUserProvider,ICustomerCardManager customerCardManager,IUserManager userManager,IMapper mapper,ICustomerManager customerManager) :base(loggedUserProvider)
        {
            _customerCardManager = customerCardManager;
            _customerManager = customerManager;
            _userManager = userManager;
            _mapper = mapper;
        }



        public async Task<IActionResult> Index()
        {
            List<CustomerCard> customerCards = await _customerCardManager.GetAllASync();
            
            List<Customer> customers = await _customerManager.GetAllASync();

            /*
            customers.ForEach(x =>
            {
                customerCards.ForEach(y =>
                {
                    if (y.CustomerId == x.CustomerId)
                        x.CustomerCards.Add(y);
                });
            });*/
            customerCards.ForEach(x =>
            {
                customers.ForEach(y =>
                {
                    if (y.CustomerId == x.CustomerId)
                        y.CustomerCards.Add(x);
                });
            });
          

           // List<CustomerCardListDto> empty = _mapper.Map<List<CustomerCardListDto>>(customerCards);
            List<CustomerListDto> customerListDtos = _mapper.Map<List<CustomerListDto>>(customers);

            //List<CustomerCardListDto> customerListDto = _mapper.Map<List<CustomerListDto>>(empty);
            return View(customers);
        }

        public async  Task<IActionResult> Create()
        {
            ViewBag.CustomerId = new SelectList(await _customerManager.GetAllASync(), "CustomerId", "CustomerName");
            ViewBag.DeveloperName = new SelectList(await _userManager.GetAllASync(), "UserId", "Name");
            ViewBag.ProductId = new SelectList(await _userManager.GetAllASync(), "UserId", "Name");
            CustomerCardAddDto cardAddDto = new();
            cardAddDto.FinishedDate = DateTime.Now;
           
            return View(cardAddDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] string CustomerCard)
        {
            List<CustomerCardRowAddDto> customerCardRowAddDtos = JsonConvert.DeserializeObject<List<CustomerCardRowAddDto>>(CustomerCard);
            CustomerCardAddDto customerCardAddDto = new CustomerCardAddDto();
            customerCardAddDto.CustomerCardRowAddDto = customerCardRowAddDtos;
            customerCardAddDto.CustomerCardName = customerCardRowAddDtos[0].CustomerCardName;
            customerCardAddDto.CustomerName = customerCardRowAddDtos[0].CustomerName;
            Customer customer = _customerManager.Find(x => x.CustomerName == customerCardAddDto.CustomerName);
            customerCardAddDto.FinishedDate = DateTime.Now.AddDays(7);
            if (ModelState.IsValid)
            {
                List<CustomerCardRow> customerCardRow = _mapper.Map<List<CustomerCardRow>>(customerCardRowAddDtos);
                CustomerCard customerCardAdd = _mapper.Map<CustomerCard>(customerCardAddDto);
                customerCardRow.ForEach(x => x.CustomerCardId = customerCardAdd.CustomerCardId);
                customerCardAdd.CustomerCardRow = customerCardRow;
                customerCardAdd.CustomerId = customer.CustomerId;
                await _customerCardManager.AddAsync(customerCardAdd);
                return RedirectToAction("Index");
            }
            else
            {


                return View();
                 
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

        public JsonResult SaveData([FromBody] string test)//WebMethod to Save the data  
        {
            var serialize  = JsonConvert.DeserializeObject(test);
            serialize.ToString();
            List<CustomerCardRow> cardrow = JsonConvert.DeserializeObject<List<CustomerCardRow>>(test);           
           
            try
            {
                

               
            }
            catch (Exception)
            {
                return Json("fail");
            }

            return Json("success");
        }
      
    }
}

/*
 * 
 * public ActionResult CreateMultiple()
{
    return View();
}

public JsonResult SaveData(string getepassdata)//WebMethod to Save the data  
{
    try
    {
        var serializeData = JsonConvert.DeserializeObject<List<GatePass>>(getepassdata);

        foreach (var data in serializeData)
        {
            db.GatePasses.Add(data);
        }

        db.SaveChanges();
    }
    catch (Exception)
    {
        return Json("fail");
    }

    return Json("success");
}
*/