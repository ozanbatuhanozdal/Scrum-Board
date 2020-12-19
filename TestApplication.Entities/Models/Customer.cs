using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TestApplication.Entities.Models.Base;

namespace TestApplication.Entities.Models
{
    public class Customer : EntityBase
    {
        [Key, Required]
        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string CustomerPhone { get; set;}

        public string CustomerAddress { get; set; }

        public virtual  IList<CustomerCard> CustomerCards { get; set; }

        public Customer()
        {
            CustomerCards = new List<CustomerCard>();
        }
    }
}
