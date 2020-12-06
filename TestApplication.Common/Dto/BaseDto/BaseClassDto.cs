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
            CreateDate = DateTime.Now;
            CreatedByUserId = 1;
            IsActive = 1;
        }


        public BaseClassDto(int userId)
        {
            CreatedByUserId = userId;
        }
    }
}
