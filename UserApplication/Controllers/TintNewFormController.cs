using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserApplication.Models;
using UserApplication.ViewModel;

namespace UserApplication.Controllers
{
    public class TintNewFormController : Controller
    {
        // GET: Tint
        public ActionResult HomeNew()
        {
            return View();
        }

        [HttpPost]
        public ActionResult HomeNew(TintVM tintVM)
        {
            TintVM temp = tintVM;

            List<string> ValidationList = new List<string>();



            ApplicationDbContext dbContext = new ApplicationDbContext();
            if (tintVM != null)
            {
                if (tintVM.Person != null)
                {
                    var Person = dbContext.Persons.Add(tintVM.Person);
                    dbContext.SaveChanges();


                    if (Person?.PersonId > 0)
                    {
                        if (tintVM.Vehicle != null)
                        {
                            tintVM.Vehicle.PersonId = Person.PersonId;
                            dbContext.Vehicles.Add(tintVM.Vehicle);
                        }
                        if (tintVM.SelfEmployed != null)
                        {
                            tintVM.SelfEmployed.PersonId = Person.PersonId;
                            dbContext.selfEmployeds.Add(tintVM.SelfEmployed);
                        }
                        if (tintVM.Employer != null)
                        {
                            tintVM.Employer.PersonId = Person.PersonId;
                            dbContext.Employers.Add(tintVM.Employer);
                        }
                        if (tintVM.MartialStatus != null)
                        {
                            tintVM.MartialStatus.PersonId = Person.PersonId;
                            dbContext.MartialStatuses.Add(tintVM.MartialStatus);
                        }
                        if (tintVM.Citizen != null)
                        {
                            tintVM.Citizen.PersonId = Person.PersonId;
                            dbContext.Citizens.Add(tintVM.Citizen);
                        }
                        if (tintVM.ImmigrationStatus != null)
                        {
                            tintVM.ImmigrationStatus.PersonId = Person.PersonId;
                            dbContext.ImmigrationStatuses.Add(tintVM.ImmigrationStatus);
                        }

                        if (tintVM.Applicant != null)
                        {
                            if (string.IsNullOrEmpty(tintVM.Applicant.FormNumber))
                            {
                                ValidationList.Add("Please provide form number");
                            }
                            if (tintVM.Applicant.DateOfApplication == null)
                            {
                                ValidationList.Add("Please provide Date of Application");
                            }
                            if (tintVM.Person.PersonId == 0)
                            {
                                ValidationList.Add("Form Person not created successfully.");
                            }

                            tintVM.Applicant.PersonId = Person.PersonId;
                            dbContext.Applicants.Add(tintVM.Applicant);
                            dbContext.SaveChanges();
                        }
                    }
                    else
                    {
                        ValidationList.Add("Form Person not created successfully. Retry");
                    }

                }
            }

            if (ValidationList?.Count > 0)
            {
                foreach (var item in ValidationList)
                {
                    ModelState.AddModelError(string.Empty, item);
                }
                return View(tintVM);
            }


            return View(tintVM);
        }
    }
}