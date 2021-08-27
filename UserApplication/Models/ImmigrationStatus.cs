using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserApplication.Models
{
    public class ImmigrationStatus
    {
        [Range(00000000, 99999999)]
        [Display(Name = "Id")]
        public int Id { get; set; }

        public int PersonId { get; set; }

        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }

        [Display(Name = "Permanent Resident")]
        public bool PermanentResident { get; set; } = false;

        [Display(Name = "Voluntary Remigrant")]
        public bool VoluntaryRemigrant { get; set; } = false;

        [Display(Name = "Involuntary Remigrant")]
        public bool InvoluntaryRemigrant { get; set; } = false;
    }
}