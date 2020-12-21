using System;
using System.Collections.Generic;
using System.Text;

namespace TestApplication.Common.Dto.BaseDto
{
    public class BaseClassDto
    {
        public DateTime CreateDate { get; set; }
        public int CreatedByUserId { get; set; }
        public byte IsActive { get; set; }

        public BaseClassDto()
        {          
            CreatedByUserId = 1;
            IsActive = 1;
        }

   
    }
}
