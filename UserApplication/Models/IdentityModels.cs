using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace UserApplication.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Birthday")]
        public string Birthday { get; set; }

        [Display(Name = "Adress")]
        public string Adress { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }

        [Display(Name = "Skype")]
        public string Skype { get; set; }

        [Display(Name = "Facebook")]
        public string Facebook { get; set; }

        [Display(Name = "Twitter")]
        public string Twitter { get; set; }

        [Display(Name = "Profile")]
        public string Profile { get; set; }

        [Display(Name = "FullName")]
        public string FullName { get; set; }

        public DateTime RegistrationDate { get; set; }

        public bool Banned { get; set; }

        public virtual ICollection<LoginDetails> loginDetails { get; set; }
        public virtual ICollection<Activity> activitys { get; set; }
        public virtual ICollection<Notifications> notifications { get; set; }
        public virtual ICollection<Messages> messages { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public System.Data.Entity.DbSet<UserApplication.Models.LoginDetails> LoginDetails { get; set; }
        public System.Data.Entity.DbSet<UserApplication.Models.Messages> Messages { get; set; }
        public System.Data.Entity.DbSet<UserApplication.Models.Notifications> Notifications { get; set; }
        public System.Data.Entity.DbSet<UserApplication.Models.Activity> Activitys { get; set; }

        public System.Data.Entity.DbSet<UserApplication.Models.Applicant> Applicants { get; set; }
        public System.Data.Entity.DbSet<UserApplication.Models.Citizen> Citizens { get; set; }
        public System.Data.Entity.DbSet<UserApplication.Models.Employer> Employers { get; set; }
        public System.Data.Entity.DbSet<UserApplication.Models.ImmigrationStatus> ImmigrationStatuses { get; set; }
        public System.Data.Entity.DbSet<UserApplication.Models.Vehicle> Vehicles { get; set; }
        public System.Data.Entity.DbSet<UserApplication.Models.Person> Persons { get; set; }
        public System.Data.Entity.DbSet<UserApplication.Models.SelfEmployed> selfEmployeds { get; set; }
        public System.Data.Entity.DbSet<UserApplication.Models.MartialStatus> MartialStatuses { get; set; }




    }
}