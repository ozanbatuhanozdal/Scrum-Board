using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TestApplication.Common.Dto.UserDtos
{
    public class UserLoginDto
    {
        //user login işleminde işimize yarayacak objeler
        //data annotations
        [Required(ErrorMessage = "Email alanı boş geçilemez")]
        public string Email { get; set; }
        [Required(ErrorMessage = "PassWord alanı boş geçilemez")]
        public string Password { get; set; }
    }
}
