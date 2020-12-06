using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApplication.Common.Dto;

namespace TestApplication.WebApp.Models.Managers
{
    public class LoggedUserProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoggedUserProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        /*
        public UserDto GetLoggedUser()
        {

            string token = _httpContextAccessor.HttpContext.Session.GetString("token");
            UserDto user = JwtAuthorizeHelper.GetCurrentUser(token);

            return user;
        }*/
    }
}
