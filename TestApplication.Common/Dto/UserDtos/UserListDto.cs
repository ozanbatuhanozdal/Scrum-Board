using System;
using System.Collections.Generic;
using System.Text;

namespace TestApplication.Common.Dto.UserDtos
{
    public class UserListDto
    {
        //user listeleme işleminde işimize yarayacak objeler
        public int UserId { get; set; }
        public string Name { get; set; }        
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
