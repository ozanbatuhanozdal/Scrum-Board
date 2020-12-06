using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TestApplication.Entities.Models.Base;

namespace TestApplication.Entities.Models
{
    public  class UserUserType :EntityBase
    {
        [Key, Required]
        public int UserUserTypeId { get; set; }

        public virtual User user { get; set; }
        
        public int UserId { get; set; }

        public virtual UserType userType { get; set; }

        public int UserTypeId { get; set; }
        
    }
}
