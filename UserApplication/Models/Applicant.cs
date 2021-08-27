using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserApplication.Models
{
    public class Applicant
    {
        [Range(00000000, 99999999)]
        [Display(Name = "Application ID")]
        public int ApplicantId { get; set; }

        [Display(Name = "Form Number")]
        public string FormNumber { get; set; }

        [Display(Name = "Is Your First Application")]
        public bool IsApplicantFirstApplication { get; set; } = false;

        
        [Display(Name = "Yes")]
        public bool Yes { get;
            set; } = false;

        [Display(Name = "No")]
        public bool No { get; set; } = false;

        [Required]
        public DateTime DateOfApplication { get; set; }

        private DateTime _DateOfFirstApplication;
        public DateTime DateOfFirstApplication
        {
            get
            {
                return _DateOfFirstApplication;
            }
            set
            {
                if (!IsApplicantFirstApplication)
                {
                    _DateOfFirstApplication = value;
                }
            }
        }

        public int PersonId { get; set; }

        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }
    }
}