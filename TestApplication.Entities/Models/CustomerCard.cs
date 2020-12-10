using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TestApplication.Entities.Models.Base;

namespace TestApplication.Entities.Models
{
    public class CustomerCard : EntityBase
    {
        [Key, Required]
        public int CustomerCardId { get; set; }

        public string CustomerCardName { get; set; }               

        public int Priorty { get; set; }

        public List<CustomerCardRow> CustomerCardRows { get; set; }

        public int UserId { get; set; }

        public int CustomerId { get; set; }

        public string Explanation { get; set; }
        

        
    }
}
