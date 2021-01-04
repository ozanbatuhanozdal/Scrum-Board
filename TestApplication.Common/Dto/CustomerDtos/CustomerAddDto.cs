using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TestApplication.Common.Dto.CustomerDtos
{
    //customer ekleme işleminde işimize yarayacak objeler
    public class CustomerAddDto
    {
        [Required(ErrorMessage ="Name alanı boş geçilemez")]
        public string CustomerName { get; set; }
        
        [Required(ErrorMessage = "Phone alanı boş geçilemez")]
        [MaxLength(11)]
        public string CustomerPhone { get; set; }

        [Required(ErrorMessage = "Address alanı boş geçilemez")]
        public string CustomerAddress { get; set; }

    }
}
