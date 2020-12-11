using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApplication.BusinessLayer.Interfaces;
using TestApplication.Common.Dto.UserTypeDtos;
using TestApplication.Entities.Models;
using TestApplication.WebApp.Models.Interfaces;

namespace TestApplication.WebApp.Controllers
{
    public class UserTypeController : BaseController
    {
        private readonly IUserTypeManager _userTypeManager;
        private readonly IMapper _mapper;

        public UserTypeController(ILoggedUserProvider loggedUserProvider, IUserTypeManager userTypeManager,IMapper mapper) : base(loggedUserProvider)
        {
            _userTypeManager = userTypeManager;
            _mapper = mapper;

        }

        public async Task<IActionResult> Index()
        {
            List<UserType> userType = await _userTypeManager.GetAllASync();

            List<UserTypeDto> userTypeDtos = _mapper.Map <List<UserTypeDto>> (userType);
            return View(userTypeDtos);
        }

        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(UserTypeAddDto userTypeAddDto)
        {
            if(ModelState.IsValid)
            {

                UserType addUser = _mapper.Map<UserType>(userTypeAddDto);
                await _userTypeManager.AddAsync(addUser);
                return RedirectToAction("Index");
            }          
            return View(userTypeAddDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            UserType userType = await _userTypeManager.FindById(id);
            UserTypeUpdateDto userTypeUpdate = _mapper.Map<UserTypeUpdateDto>(userType);

            return View(userTypeUpdate);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UserTypeUpdateDto model)
        {
            if(ModelState.IsValid)
            {

            UserType userType = await _userTypeManager.FindById(model.UserTypeId);
            userType = _mapper.Map<UserType>(model);
            await _userTypeManager.UpdateAsync(userType);
            return RedirectToAction("Index");
            }            
            return View(model);
            
        }

        public async Task<IActionResult> Delete(int id)
        {
            UserType userType = await _userTypeManager.FindById(id);
            UserTypeDto userTypeDto = _mapper.Map<UserTypeDto>(userType);

            return View(userTypeDto);
        }
        
        [HttpPost]
        public async Task<IActionResult> Delete(UserTypeDto userTypeDto)
        {
            UserType userType = _mapper.Map<UserType>(userTypeDto);
            await _userTypeManager.RemoveAsync(userType);
            return RedirectToAction("Index");
        }
    }
}
