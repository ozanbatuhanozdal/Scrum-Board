using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApplication.Common.Dto.UserDtos;

namespace TestApplication.WebApp.Models.Interfaces
{
    public interface ILoggedUserProvider
    {
        UserDto GetLoggedUser();
    }
}
