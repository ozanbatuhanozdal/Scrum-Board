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
    }
}
