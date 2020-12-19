using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Common.Dto.CustomerCardDtos;

namespace TestApplication.Common.Dto.CustomerDtos
{
    public class CustomerListDto
    {
        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string CustomerPhone { get; set; }

        public List<CustomerCardDto> customerCardDtos { get; set; }

        public string CustomerAddress { get; set; }
    }
}
