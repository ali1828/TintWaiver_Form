using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserApplication.Models
{
    public class Person
    {
        [Range(00000000, 99999999)]
        [Display(Name = "Id")]
        public int PersonId { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Place of Birth")]
        public DateTime PlaceOfBirth { get; set; }

        [Required]
        [Display(Name = "Nationality")]
        public string Nationality { get; set; }

        
        [Display(Name = "Male")]
        public bool Male { get; set; }

        
        [Display(Name = "Female")]
        public bool Female { get; set; }

        [Required]
        [Display(Name = "Ethicinity")]
        public string Ethicinity { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Tel No")]
        public string TelNo { get; set; }

        [Required]
        [Display(Name = "Cell No")]
        public string CellNo { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "National ID No")]
        public string NationalIDNo { get; set; }

        [Display(Name = "Passport Number")]
        public string PassportNumber { get; set; }

        [Display(Name = "TIN")]
        public string TIN { get; set; }
    }
}