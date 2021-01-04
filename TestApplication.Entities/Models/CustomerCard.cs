using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TestApplication.Entities.Models.Base;

namespace TestApplication.Entities.Models
{
    //customerCard Entities
    public class CustomerCard : EntityBase
    {
        //boş geçilemez
        [Key, Required]
        public int CustomerCardId { get; set; }
        [Required]
        public string CustomerCardName { get; set; }               

        public List<CustomerCardRow> CustomerCardRow { get; set; }

        [Required]
        public string ProductManagerName { get; set; }

        public double CostOfCardTime { get; set; }

        public int CustomerId { get; set; }
        
    }
}
