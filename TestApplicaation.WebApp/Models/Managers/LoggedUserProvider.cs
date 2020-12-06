using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApplication.Common.Dto;
using TestApplication.Common.Dto.UserDtos;
using TestApplication.CustomFilters;
using TestApplication.WebApp.Models.Interfaces;

namespace TestApplication.WebApp.Models.Managers
{
    public class LoggedUserProvider : ILoggedUserProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoggedUserProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        
        public UserDto GetLoggedUser()
        {

            string token = _httpContextAccessor.HttpContext.Session.GetString("token");
            UserDto user = JwtAuthorizeHelper.GetCurrentUser(token);

            return user;
        }
    }
}
