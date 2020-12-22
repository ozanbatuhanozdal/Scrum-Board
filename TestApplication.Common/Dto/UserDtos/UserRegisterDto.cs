using System;
using System.Collections.Generic;
using System.Text;
using TestApplication.Common.Dto.BaseDto;

namespace TestApplication.Common.Dto.UserDtos
{
    public class UserRegisterDto:BaseClassDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
