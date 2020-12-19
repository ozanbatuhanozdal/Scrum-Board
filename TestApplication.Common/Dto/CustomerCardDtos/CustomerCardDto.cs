using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Common.Dto.BaseDto;
using TestApplication.Common.Dto.CustomerCardRowDtos;

namespace TestApplication.Common.Dto.CustomerCardDtos
{
    public class CustomerCardDto : BaseClassDto
    {
        public int CustomerCardId { get; set; }

        public string CustomerCardName { get; set; }

        public List<CustomerCardRowDto> CustomerCardRow { get; set; }

        public string ProductManagerName { get; set; }

        public int CustomerId { get; set; }
    }
}
