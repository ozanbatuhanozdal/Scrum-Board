using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TestApplication.Entities.Models.Base;

namespace TestApplication.Entities.Models
{
    public class User : EntityBase
    {
        [Required]
        public string DeveloperName { get; set; }
        [Required]
        public string DeveloperPassword { get; set; }

        public List<CustomerCard> customerCards { get; set; }

        public List<CustomerCardRow> customerCardRows { get; set; }
    }
}
