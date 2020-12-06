using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestApplication.Entities.Models
{
    public  class UserType
    {
        [Key, Required]
        public int UserTypeId { get; set; }
        public string UserTypeName { get; set; }
        public string UserTypeDescription { get; set; }

      public virtual IList<UserUserType> userUserTypes { get; set; }
    }
}
