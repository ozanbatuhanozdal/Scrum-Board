using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TestApplication.Entities.Models.Base;

namespace TestApplication.Entities
{
    //customerCardRow Entities
    public class CustomerCardRow : EntityBase
    {
        [Key]
        public int CustomerCardRowId { get; set; }
        public int CustomerCardId { get; set; }

        [Required]
        public string DeveloperName { get; set; }
        
        [Required]
        public string Priorty { get; set; }

        public DateTime FinishedDate { get; set; }

        public int ProgressId { get; set; }

        [Required]
        public string Explanation { get; set; }
        
    }
}
