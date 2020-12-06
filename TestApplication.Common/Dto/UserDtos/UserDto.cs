using System;
using System.Collections.Generic;
using System.Text;

namespace TestApplication.Common.Dto.UserDtos
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string EMail { get; set; }
        public int RestaurantId { get; set; }
        public List<string> Roles { get; set; }
    }
}
