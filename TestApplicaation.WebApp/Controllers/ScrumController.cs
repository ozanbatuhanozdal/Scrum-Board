using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApplication.BusinessLayer.Interfaces;
using TestApplication.Common.Dto.CustomerCardDtos;
using TestApplication.Common.Dto.CustomerCardRowDtos;
using TestApplication.Entities;
using TestApplication.Entities.Models;
using TestApplication.WebApp.Models.Interfaces;

namespace TestApplication.WebApp.Controllers
{//scrum controller
    public class ScrumController : BaseController
    {

        private readonly ICustomerManager _customerManager;
        private readonly ICustomerCardManager _customerCardManager;
        private readonly ICustomerCardRowManager _customerCardRowManager;
        private readonly IMapper _mapper;
        public ScrumController(ICustomerManager customerManager,ICustomerCardRowManager customerCardRowManager, IMapper mapper ,ICustomerCardManager customerCardManager, ILoggedUserProvider loggedUserProvider) : base(loggedUserProvider)
        {
            _customerManager = customerManager;
            _customerCardManager = customerCardManager;
            _customerCardRowManager = customerCardRowManager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(int id)
        {
            CustomerCard customerCard = await _customerCardManager.FindById(id);
            Customer customer = await _customerManager.FindById(id);

            List<CustomerCardRow> customerCardRows = await _customerCardRowManager.GetAllASync(x => x.CustomerCardId == id);
            List<CustomerCardRowAddDto> customerCardRowAddDto = _mapper.Map<List<CustomerCardRowAddDto>>(customerCardRows);

            CustomerCardAddDto customerCardAddDto = _mapper.Map<CustomerCardAddDto>(customerCard);

            customerCardAddDto.CustomerCardRowAddDto = customerCardRowAddDto;
            customerCardAddDto.CreateDate = customerCard.CreatedDate;
            return View(customerCardAddDto);
        }


        public async Task<IActionResult> TaskMove(int id)
        {
            CustomerCardRow customerCardRow = await _customerCardRowManager.FindById(id);
            customerCardRow.ProgressId++;
            await _customerCardRowManager.UpdateAsync(customerCardRow);
            return RedirectToAction("Index", "Scrum", new { id = customerCardRow.CustomerCardId });
        }

        public async Task<IActionResult> TaskBack(int id)
        {
            CustomerCardRow customerCardRow = await _customerCardRowManager.FindById(id);
            customerCardRow.ProgressId--;
            await _customerCardRowManager.UpdateAsync(customerCardRow);
            return RedirectToAction("Index", "Scrum", new { id = customerCardRow.CustomerCardId });
        }

        public async Task<IActionResult> TaskRemove(int id)
        {
            CustomerCardRow customerCardRow = await _customerCardRowManager.FindById(id);
            int routeId = customerCardRow.CustomerCardId;
            CustomerCard customerCard = await _customerCardManager.FindById(customerCardRow.CustomerCardId);
            customerCard.CostOfCardTime -= 4;
            await _customerCardManager.UpdateAsync(customerCard);
            await _customerCardRowManager.RemoveAsync(customerCardRow);
            return RedirectToAction("Index", "Scrum", new { id = routeId });
        }


    }
}
