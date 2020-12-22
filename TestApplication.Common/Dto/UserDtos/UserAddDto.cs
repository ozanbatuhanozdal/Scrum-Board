
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TestApplication.Common.Dto.BaseDto;
using TestApplication.Common.Dto.UserTypeDtos;

namespace TestApplication.Common.Dto.UserDtos
{
    public class UserAddDto : BaseClassDto
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Name alanı boş geçilemez")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email alanı boş geçilemez")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password alanı boş geçilemez")]
        public string Password { get; set; }

        public int UserTypeId { get; set; }
        public List<UserTypeDto> userUserTypes { get; set; }        
        
    }
}
