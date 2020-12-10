using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApplication.BusinessLayer.Interfaces;
using TestApplication.Common.Dto.UserDtos;
using TestApplication.Entities.Models;
using TestApplication.WebApp.Models.Interfaces;

namespace TestApplication.WebApp.Controllers
{
    public class UserController : BaseController
    {

        private readonly ILoggedUserProvider _loggedUserProvider;
        private readonly IUserManager _userManager;
        private readonly IMapper _mapper;
        public UserController(ILoggedUserProvider loggedUserProvider,IUserManager userManager,IMapper mapper) : base(loggedUserProvider)
        {
            _loggedUserProvider = loggedUserProvider;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async  Task<IActionResult> Index()
        {
            List<User> users = await _userManager.GetAllASync();
            List<UserListDto> userListDto = _mapper.Map<List<UserListDto>>(users);
            return View(userListDto);
        }

        public IActionResult Create()
        {
           // ViewBag.UserId = new SelectList(await _userManager.)

            return View();
        }
        [HttpPost]
        public IActionResult Create(UserAddDto model)
        {

            return View();
        }
    }
}
