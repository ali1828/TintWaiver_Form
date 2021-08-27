using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserApplication.Models
{
    public class Vehicle
    {
        [Range(00000000, 99999999)]
        [Display(Name = "Id")]
        public int Id { get; set; }

        public int PersonId { get; set; }

        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }

        [Required]
        [Display(Name = "Name of Registered Owner")]
        public string NameofRegisteredOwner { get; set; }

        [Required]
        [Display(Name = "Type of Vehicle")]
        public string TypeofVehicle { get; set; }

        [Required]
        [Display(Name = "Registration No.")]
        public string RegistrationNo { get; set; }

        [Display(Name = "Colour")]
        public string Colour { get; set; }

        [Required]
        [Display(Name = "Seating Capacity")]
        public int SeatingCapacity { get; set; }

        [Required]
        [Display(Name = "Identification Mark")]
        public string IdentificationMark { get; set; }

        [Display(Name = "Chassis No")]
        public string ChassisNo { get; set; }

        [Required]
        [Display(Name = "Engine No.")]
        public int EngineNo { get; set; }

        [Required]
        [Display(Name = "Driving Licence No.")]
        public string DrivingLicenceNo { get; set; }

        [Display(Name = "Date of Expiry")]
        [Required]
        public DateTime DLDateOfExpiry { get; set; }

        [Required]
        [Display(Name = "Motor Vehicle Licence No.")]
        public string MotorVehicleLicenceNo { get; set; }

        [Display(Name = "Date of Expiry")]
        [Required]
        public DateTime MVLDateOfExpiry { get; set; }

        [Required]
        [Display(Name = "Certificate of Fitness No.")]
        public string CertificateOfFitnessNo { get; set; }

        [Display(Name = "Date of Expiry")]
        [Required]
        public DateTime CertificateOfFitnessDateOfExpiry { get; set; }
    }
}