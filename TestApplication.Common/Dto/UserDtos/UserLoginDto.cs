using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TestApplication.Common.Dto.UserDtos
{
    public class UserLoginDto
    {
        [Required(ErrorMessage = "Email alanı boş geçilemez")]
        public string Email { get; set; }
        [Required(ErrorMessage = "PassWord alanı boş geçilemez")]
        public string Password { get; set; }
    }
}
