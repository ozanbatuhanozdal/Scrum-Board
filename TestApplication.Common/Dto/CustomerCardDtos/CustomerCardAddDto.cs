using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Common.Dto.BaseDto;
using TestApplication.Common.Dto.CustomerCardRowDtos;

namespace TestApplication.Common.Dto.CustomerCardDtos
{
    //Customercard ekleme işleminde işimize yarayacak objeler
    public class CustomerCardAddDto : BaseClassDto
    {
        public int UserId { get; set; }
        public int CustomerCardRowId { get; set; }
        public int CustomerCardId { get; set; }
        public string CustomerName { get; set; }

        public string CustomerCardName { get; set; }
        
        public string DeveloperName { get; set; }

        public int ProgressId { get; set; }

        public string ProductManagerName { get; set; }

        public string Priorty { get; set; }

        public DateTime FinishedDate { get; set; }

        public double CostOfCardTime { get; set; }

        public List<CustomerCardRowAddDto> CustomerCardRowAddDto { get; set; }

        public string Explanation { get; set; }
    }
}
