
using System;
using System.Collections.Generic;
using System.Text;
using TestApplication.Common.Dto.BaseDto;
using TestApplication.Common.Dto.UserTypeDtos;

namespace TestApplication.Common.Dto.UserDtos
{
    public class UserAddDto : BaseClassDto
    {
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserTypeId { get; set; }
        public List<UserTypeDto> userUserTypes { get; set; }
        public int RestaurantId { get; set; }        
        
    }
}
