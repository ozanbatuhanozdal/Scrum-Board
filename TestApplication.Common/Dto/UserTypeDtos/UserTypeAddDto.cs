using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication.Common.Dto.UserTypeDtos
{
    public class UserTypeAddDto
    {
        public int UserTypeId { get; set; }
        [Required(ErrorMessage = "UserTypeName alanı boş geçilemez")]
        public string UserTypeName { get; set; }
        [Required(ErrorMessage = "Description alanı boş geçilemez")]
        public string UserTypeDescription { get; set; }
    }
}
