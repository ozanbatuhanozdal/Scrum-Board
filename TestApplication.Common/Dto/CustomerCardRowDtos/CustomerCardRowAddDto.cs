﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication.Common.Dto.CustomerCardRowDtos
{
    public class CustomerCardRowAddDto
    {
        public int CustomerCardRowId { get; set; }
        public int CustomerCardId { get; set; }

        public string DevName { get; set; }

        public int Priorty { get; set; }

        public DateTime FinishedDate { get; set; }

        public string Explanation { get; set; }
    }
}
