using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserApplication.Models
{
    public class Employer
    {
        [Range(00000000, 99999999)]
        [Display(Name = "Id")]
        public int Id { get; set; }

        public int PersonId { get; set; }

        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }

        [Required]
        [Display(Name = "Address of Employer")]
        public string Address { get; set; }


        [Required]
        [Display(Name = "Profession Or Occupation")]
        public string ProfessionOrOccupation { get; set; }


        [Display(Name = "Tel No")]
        public string TelNo { get; set; }

   
        [Display(Name = "Fax No")]
        public string FaxNo { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Name of Employer")]
        public string NameOfEmployer { get; set; }
    }
}