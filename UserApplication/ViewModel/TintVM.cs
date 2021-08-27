using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserApplication.Models;

namespace UserApplication.ViewModel
{
    public class TintVM
    {
        public Applicant Applicant {get; set;}
        public Citizen Citizen { get; set; }
        public Employer Employer { get; set; }
        public ImmigrationStatus ImmigrationStatus { get; set; }
        public MartialStatus MartialStatus { get; set; }
        public Person Person { get; set; }
        public SelfEmployed SelfEmployed { get; set; }
        public Vehicle Vehicle { get; set; }

        public List<string> validationErrors { get; set; }
    }
}