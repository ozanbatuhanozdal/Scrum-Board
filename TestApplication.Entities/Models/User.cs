using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TestApplication.Entities.Models.Base;

namespace TestApplication.Entities.Models
{
    public class User : EntityBase
    {
        [Key,Required]
        public int UserId { get; set; }

        public string Email { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        

        public virtual IList<UserUserType> userUserTypes { get; set; }
    }
}
