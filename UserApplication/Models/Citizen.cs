using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserApplication.Models
{
    public class Citizen
    {
        [Range(00000000, 99999999)]
        [Display(Name = "Id")]
        public int Id { get; set; }

        public int PersonId { get; set; }

        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }

       
        public bool Birth { get; set; } = false;

        [Display(Name = "Naturalization")]
        public bool Naturalization { get; set; } = false;

        [Display(Name = "Registration")]
        public bool Registration { get; set; } = false;

        [Display(Name = "Marriage")]
        public bool Marriage { get; set; } = false;

        [Display(Name = "Dual Citizenship")]
        public bool DualCitizenship { get; set; } = false;

        [Display(Name = "Please Specify")]
        public string DualCitizenSpecification { get; set; }

        [Display(Name = "Other")]
        public bool Other { get; set; } = false;

        [Display(Name = "Please Specify")]
        public string OtherSpecification { get; set; }
    }
}