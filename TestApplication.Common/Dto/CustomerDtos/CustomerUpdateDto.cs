using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication.Common.Dto.CustomerDtos
{
    public class CustomerUpdateDto
    {
        //customer update işleminde işimize yarayacak objeler
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Name alanı boş geçilemez")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Phone alanı boş geçilemez")]
        public string CustomerPhone { get; set; }

        [Required(ErrorMessage = "Adress alanı boş geçilemez")]

        public string CustomerAddress { get; set; }
        //data annotations
    }
}
