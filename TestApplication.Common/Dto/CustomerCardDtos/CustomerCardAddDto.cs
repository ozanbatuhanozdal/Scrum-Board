using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Common.Dto.CustomerCardRowDtos;

namespace TestApplication.Common.Dto.CustomerCardDtos
{
    public class CustomerCardAddDto
    {
        public int CustomerCardRowId { get; set; }
        public int CustomerCardId { get; set; }

        public int DevId { get; set; }

        public int Priorty { get; set; }

        public DateTime FinishedDate { get; set; }

        public IList<CustomerCardRowAddDto> CustomerCardRowAddDto { get; set; }

        public string Explanation { get; set; }
    }
}
