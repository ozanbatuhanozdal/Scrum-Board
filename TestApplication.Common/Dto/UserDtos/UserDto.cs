using System;
using System.Collections.Generic;
using System.Text;

namespace TestApplication.Common.Dto.UserDtos
{
    public class UserDto
    {
        public int UserId { get; set; }        
        public string Email { get; set; }     
        public string Name { get; set; }
        public List<string> Roles { get; set; }
    }
}
