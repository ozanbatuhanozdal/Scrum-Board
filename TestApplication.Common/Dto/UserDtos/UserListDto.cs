﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TestApplication.Common.Dto.UserDtos
{
    public class UserListDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
        public int RestaurantId { get; set; }
    }
}
