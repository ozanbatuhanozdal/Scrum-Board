using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Common.Dto.BaseDto;
using TestApplication.Common.Dto.CustomerCardRowDtos;

namespace TestApplication.Common.Dto.CustomerCardDtos
{
    //listeleme işleminde işimize yarayacak objeler
    public class CustomerCardListDto : BaseClassDto
    {
        public int CustomerCardId { get; set; }

        public string CustomerCardName { get; set; }

        public int Priorty { get; set; }

        public List<CustomerCardRowDto> CustomerCardRows { get; set; }

        public int UserId { get; set; }

        public int CustomerId { get; set; }

        public string Explanation { get; set; }
    }
}
