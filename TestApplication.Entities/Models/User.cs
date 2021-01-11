using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TestApplication.Entities.Models.Base;

namespace TestApplication.Entities.Models
{
    //user Entities
    public class User : EntityBase
    {
        [Key,Required]
        public int UserId { get; set; }

        public string Email { get; set; }
        //name boş geçilemez
        [Required]
        public string Name { get; set; }
        //password boş geçilemez
        [Required]
        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public string Guid { get; set; }


        public virtual IList<UserUserType> userUserTypes { get; set; }
    }
}
