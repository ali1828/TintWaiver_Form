using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserApplication.Models
{
    public class MartialStatus
    {
        [Range(00000000, 99999999)]
        [Display(Name = "Id")]
        public int Id { get; set; }

        public int PersonId { get; set; }

        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }

        [Display(Name = "Single")]
        public bool Single { get; set; } = false;

        [Display(Name = "Married")]
        public bool Married { get; set; } = false;

        [Display(Name = "Divorced")]
        public bool Divorced { get; set; } = false;

        [Display(Name = "Separated")]
        public bool Separated { get; set; } = false;

        [Display(Name = "Widowed")]
        public bool Widowed { get; set; } = false;

        [Display(Name = "Common Law")]
        public bool CommonLaw { get; set; } = false;
    }
}