using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApplication.Common.Dto;
using TestApplication.Common.Dto.UserDtos;
using TestApplication.WebApp.Models.Interfaces;

namespace TestApplication.WebApp.Controllers
{
    public class BaseController : Controller
    {

        protected UserDto CurrentUser;
        private readonly ILoggedUserProvider _loggedUserProvider;

        public BaseController(ILoggedUserProvider loggedUserProvider)
        {
            _loggedUserProvider = loggedUserProvider;

            this.CurrentUser = _loggedUserProvider.GetLoggedUser();
        }
    }
}
