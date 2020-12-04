using System;
using System.Collections.Generic;
using System.Text;
using TestApplication.Entities.Models.Base;

namespace TestApplication.Entities.Models
{
    public class Customer : EntityBase
    {
        public string CustomerName { get; set; }

        public string CustomerPhone { get; set;}

        public string CustomerAddress { get; set; }
    }
}
