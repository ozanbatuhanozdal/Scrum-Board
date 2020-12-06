using System;
using System.Collections.Generic;
using System.Text;
namespace TestApplication.Common.Dto.UserTypeDtos
{
    public class UserTypeDto
    {
        public int UserTypeId { get; set; }  
        public string UserTypeName { get; set; }        
        public string UserTypeDescription { get; set; }
        public bool Selected { get; set; }
        
    }
}
