using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TestApplication.Entities.Models.Base;

namespace TestApplication.Entities
{
    public class CustomerCardRow : EntityBase
    {
        [Key]
        public int CustomerCardRowId { get; set; }
        public int CustomerCardId { get; set; }

        public string DeveloperName { get; set; }
        
        public string Priorty { get; set; }

        public DateTime FinishedDate { get; set; }

        public string Explanation { get; set; }
        
    }
}
