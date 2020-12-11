using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication.Common.Dto.UserTypeDtos
{
    public class UserTypeUpdateDto
    {
        public int UserTypeId { get; set; }
        public string UserTypeName { get; set; }
        public string UserTypeDescription { get; set; }
    }
}
