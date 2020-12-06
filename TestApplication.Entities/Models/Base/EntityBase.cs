using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TestApplication.Entities.Models.Base
{
    public class EntityBase
    {                

        public DateTime CreatedDate { get; set; }

        public EntityBase()
        {
            CreatedDate = DateTime.Now;
        }
          

    }
}
