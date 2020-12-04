using System;
using System.Collections.Generic;
using System.Text;

namespace TestApplication.Entities.Models.Base
{
    public class EntityBase
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }

        public EntityBase()
        {
            CreatedDate = DateTime.Now;
        }
          

    }
}
