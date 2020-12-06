using System;
using System.Collections.Generic;
using System.Text;

namespace TestApplication.Common.Dto.UserDtos
{
    public class UserChangePasswordDto
    {
        public int UserId { get; set; }                
        public string Password { get; set; }
        public string CorrectPassword { get; set; }
    }
}
