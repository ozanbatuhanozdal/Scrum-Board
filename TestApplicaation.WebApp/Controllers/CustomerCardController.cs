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
    //customrCardController
    public class CustomerCardController : BaseController
    {

        private readonly ICustomerCardManager _customerCardManager;
        private readonly ICustomerManager _customerManager;
        private readonly ICustomerCardRowManager _customerCardRowManager;
        private readonly IUserManager _userManager;
        private readonly IMapper _mapper;


        public CustomerCardController(ILoggedUserProvider loggedUserProvider,ICustomerCardManager customerCardManager,ICustomerCardRowManager customerCardRowManager,IUserManager userManager,IMapper mapper,ICustomerManager customerManager) :base(loggedUserProvider)
        {
            _customerCardManager = customerCardManager;
            _customerCardRowManager = customerCardRowManager;
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
          
            //List<CustomerCardListDto> empty = _mapper.Map<List<CustomerCardListDto>>(customerCards);
            List<CustomerListDto> customerListDtos = _mapper.Map<List<CustomerListDto>>(customers);

            //List<CustomerCardListDto> customerListDto = _mapper.Map<List<CustomerListDto>>(empty);
            return View(customers);
        }

        public async  Task<IActionResult> Create(int id)
        {
            ViewBag.CustomerId = new SelectList(await _customerManager.GetAllASync(x=> x.CustomerId == id), "CustomerId", "CustomerName");
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
            User user = await _userManager.FindById(Convert.ToInt32(customerCardRowAddDtos[0].ProductManagerName));
            customerCardAddDto.CustomerCardName = customerCardRowAddDtos[0].CustomerCardName;
            customerCardAddDto.ProductManagerName = user.Name;
            Customer customer = _customerManager.Find(x => x.CustomerId == Convert.ToInt32(customerCardRowAddDtos[0].CustomerName));
            customerCardAddDto.CustomerName = customer.CustomerName;
            customerCardAddDto.FinishedDate = DateTime.Now.AddDays(7);
            if (ModelState.IsValid)
            {
                List<CustomerCardRow> customerCardRow = _mapper.Map<List<CustomerCardRow>>(customerCardRowAddDtos);
                CustomerCard customerCardAdd = _mapper.Map<CustomerCard>(customerCardAddDto);
                customerCardRow.ForEach(x => x.CustomerCardId = customerCardAdd.CustomerCardId);
                customerCardAdd.CustomerCardRow = customerCardRow;
                customerCardAdd.CustomerId = customer.CustomerId;
                customerCardAdd.CostOfCardTime = customerCardAdd.CustomerCardRow.Count * 4;
                await _customerCardManager.AddAsync(customerCardAdd);
                return RedirectToAction("Index","Home");
            }
            else
            {
                return View(CustomerCard);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            CustomerCard customerCard = await _customerCardManager.FindById(id);

            List<CustomerCardRow> customerCardRows = await _customerCardRowManager.GetAllASync(x => x.CustomerCardId == id);

            
            List<CustomerCardRowAddDto> customerCardRowAddDto = _mapper.Map<List<CustomerCardRowAddDto>>(customerCardRows);

            CustomerCardAddDto customerCardAddDto = _mapper.Map<CustomerCardAddDto>(customerCard);

            customerCardAddDto.CustomerCardRowAddDto = customerCardRowAddDto;
            ViewBag.CustomerId = new SelectList(await _customerManager.GetAllASync(x => x.CustomerId == customerCard.CustomerId), "CustomerId", "CustomerName");
            ViewBag.DeveloperName = new SelectList(await _userManager.GetAllASync(), "UserId", "Name");
            ViewBag.ProductId = new SelectList(await _userManager.GetAllASync(), "UserId", "Name");
            customerCardAddDto.FinishedDate = DateTime.Now;
            return View(customerCardAddDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] string CustomerCard)
        {
            List<CustomerCardRowAddDto> customerCardRowAddDtos = JsonConvert.DeserializeObject<List<CustomerCardRowAddDto>>(CustomerCard);
            CustomerCardAddDto customerCardAddDto = new CustomerCardAddDto();
            User user = await _userManager.FindById(Convert.ToInt32(customerCardRowAddDtos[0].ProductManagerName));
            customerCardAddDto.CustomerCardRowAddDto = customerCardRowAddDtos;
            customerCardAddDto.CustomerCardName = customerCardRowAddDtos[0].CustomerCardName;
            customerCardAddDto.ProductManagerName = user.Name;
            customerCardAddDto.CustomerCardId = customerCardRowAddDtos[0].CustomerCardId;
            Customer customer = _customerManager.Find(x => x.CustomerId == Convert.ToInt32(customerCardRowAddDtos[0].CustomerName));
            customerCardAddDto.CustomerName = customer.CustomerName;           
            if (ModelState.IsValid)
            {
                List<CustomerCardRow> customerCardRow = _mapper.Map<List<CustomerCardRow>>(customerCardRowAddDtos);
                CustomerCard customerCardAdd = _mapper.Map<CustomerCard>(customerCardAddDto);
                customerCardRow.ForEach(x => x.CustomerCardId = customerCardAdd.CustomerCardId);
                customerCardAdd.CustomerCardRow = customerCardRow;
                customerCardAdd.CustomerId = customer.CustomerId;
                customerCardAdd.CostOfCardTime = customerCardAdd.CustomerCardRow.Count * 4;
                await _customerCardManager.UpdateAsync(customerCardAdd);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(CustomerCard);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            CustomerCard deletedCustomer = await _customerCardManager.FindById(id);
            
            await _customerCardManager.RemoveAsync(deletedCustomer);
            return RedirectToAction("Index", "Home");
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

 
 // public ActionResult CreateMultiple()
//{
//    return View();
//}

//public JsonResult SaveData(string getepassdata)//WebMethod to Save the data  
//{
   // try
   // {
    //    var serializeData = JsonConvert.DeserializeObject<List<GatePass>>(getepassdata);

     //   foreach (var data in serializeData)
      //  {
       //     db.GatePasses.Add(data);
      //  }

    //    db.SaveChanges();
   // }
  //  catch (Exception)
   // {
  //      return Json("fail");
  //  }

  //  return Json("success");
//}
