using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApplication.BusinessLayer.Interfaces;
using TestApplication.Common.Dto.UserDtos;
using TestApplication.Common.Dto.UserTypeDtos;
using TestApplication.Entities.Models;
using TestApplication.WebApp.Models.Interfaces;

namespace TestApplication.WebApp.Controllers
{
    public class UserController : BaseController
    {

        private readonly ILoggedUserProvider _loggedUserProvider;
        private readonly IUserManager _userManager;
        private readonly IUserTypeManager _userTypeManager;
        private readonly IMapper _mapper;
        public UserController(ILoggedUserProvider loggedUserProvider,IUserManager userManager,IUserTypeManager userTypeManager,IMapper mapper) : base(loggedUserProvider)
        {
            _loggedUserProvider = loggedUserProvider;
            _userManager = userManager;
            _userTypeManager = userTypeManager;
            _mapper = mapper;
        }

        public async  Task<IActionResult> Index()
        {
            List<User> users = await _userManager.GetAllASync();
            List<UserListDto> userListDto = _mapper.Map<List<UserListDto>>(users);
            return View(userListDto);
        }

        public async  Task<IActionResult> Create()
        {
            // ViewBag.UserId = new SelectList(await _userManager.)
            List<UserType> userType =  await _userTypeManager.GetAllASync();
            List<UserTypeDto> userTypeDto = _mapper.Map<List<UserTypeDto>>(userType);
            UserAddDto userAddDto = new UserAddDto()
            {
                userUserTypes = userTypeDto
            };

            return View(userAddDto);
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserAddDto model)
        {
            if (ModelState.IsValid)
            {
                User checkUser = await _userManager.FindByEmail(model.Email);
                if (checkUser == null)
                {
                    var selected = model.userUserTypes.Where(x => x.Selected == true);
                    model.userUserTypes = selected.ToList();

                    User userAdd = _mapper.Map<User>(model);
                    await _userManager.AddAsync(userAdd);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "U Have user with this email");
                }

            }
            return View(model);                           
        }


        public async Task<IActionResult> Edit(int id)
        {
            User user =  await _userManager.FindById(id);
            List<UserType> userTypes = await _userTypeManager.GetAllASync();
            
            List<UserType> userTypeList = await _userManager.GetRolesByEmail(user.Email);

            List<UserTypeDto> userTypeDto = _mapper.Map<List<UserTypeDto>>(userTypeList);
            List<UserTypeDto> userTypesDs = _mapper.Map<List<UserTypeDto>>(userTypes);
            userTypesDs.ForEach(x =>
            {
                userTypeList.ForEach(y =>
                {
                    if(x.UserTypeId == y.UserTypeId)
                    {
                        x.Selected = true;
                    }
                });
            });
            UserAddDto userUpdate = _mapper.Map<UserAddDto>(user);
            
            
            
            userUpdate.userUserTypes = userTypesDs;

            return View(userUpdate);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserAddDto model)
        {
            if(ModelState.IsValid)
            {

            User userUpdate = await _userManager.FindById(model.UserId);
            var selectedTypeList = model.userUserTypes.Where(x => x.Selected == true);
            model.userUserTypes = selectedTypeList.ToList();

            userUpdate = _mapper.Map<User>(model);
            await _userManager.UpdateAsync(userUpdate);
            return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            User user = await _userManager.FindById(id);
            List<UserType> userTypes = await _userTypeManager.GetAllASync();

            List<UserType> userTypeList = await _userManager.GetRolesByEmail(user.Email);

            List<UserTypeDto> userTypeDto = _mapper.Map<List<UserTypeDto>>(userTypeList);
            List<UserTypeDto> userTypesDs = _mapper.Map<List<UserTypeDto>>(userTypes);
            userTypesDs.ForEach(x =>
            {
                userTypeList.ForEach(y =>
                {
                    if (x.UserTypeId == y.UserTypeId)
                    {
                        x.Selected = true;
                    }
                });
            });
            UserAddDto userDelete = _mapper.Map<UserAddDto>(user);



            userDelete.userUserTypes = userTypesDs;

            return View(userDelete);            
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UserAddDto model)
        {
            User user = await _userManager.FindById(model.UserId);
            await _userManager.RemoveAsync(user);
            return RedirectToAction("Index");
        }




    }
}
