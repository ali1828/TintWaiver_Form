using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserApplication.Models
{
    public class SelfEmployed
    {
        [Range(00000000, 99999999)]
        [Display(Name = "Id")]
        public int Id { get; set; }

        public int PersonId { get; set; }

        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }

        [Display(Name = "Type of Business")]
        public string TypeOfBusiness { get; set; }

        [Required]
        [Display(Name = "Name of Business")]
        public string NameOfBusiness { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Tel No")]
        public string TelNo { get; set; }

        [Display(Name = "Fax No")]
        public string FaxNo { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
    }
}