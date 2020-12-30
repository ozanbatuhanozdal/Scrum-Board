using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TestApplication.Common.Dto.BaseDto;

namespace TestApplication.Common.Dto.UserDtos
{
    public class UserRegisterDto:BaseClassDto
    {
        [Required(ErrorMessage = "Name alanı boş geçilemez")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email alanı boş geçilemez")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password alanı boş geçilemez")]
        public string Password { get; set; }
    }
}
