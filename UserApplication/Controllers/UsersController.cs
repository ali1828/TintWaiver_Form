using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserApplication.Models;

namespace UserApplication.Controllers
{
    [Authorize(Roles ="Users")]
    public class UsersController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UserDetails()
        {
            string id = User.Identity.GetUserId();
            var userdeatils = db.Users.Where(u => u.Id == id).FirstOrDefault();
            if (userdeatils == null)
                return RedirectToAction("Index");
            Activity acti = new Activity();
            acti.Time = DateTime.Now;
            acti.UserId = User.Identity.GetUserId();
            acti.IPAdress = Request.UserHostAddress;
            acti.Agent = Request.Browser.Type;
            acti.Message = "Show User Details";
            db.Activitys.Add(acti);
            db.SaveChanges();
            return View(userdeatils);
        }
        public ActionResult EditProfile()
        {
            string id = User.Identity.GetUserId();

            var useredit = db.Users.Where(u => u.Id == id).FirstOrDefault();
            if (useredit == null)
                return RedirectToAction("Index");
            return View(useredit);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile(string Id, string UserName, string Email, string FullName, string Birthday, string Country, string Adress, string PhoneNumber, string Skype, string Facebook, string Twitter, HttpPostedFileBase myProfile)
        {

            var user = db.Users.Where(u => u.Id == Id).FirstOrDefault();
            if (user != null)
            {
                user.UserName = UserName;
                user.Email = Email;
                user.FullName = FullName;
                user.Facebook = Facebook;
                user.Twitter = Twitter;
                user.Skype = Skype;
                user.Birthday = Birthday;
                user.Adress = Adress;
                user.Country = Country;
                user.PhoneNumber = PhoneNumber;
                try
                {
                    if (myProfile != null && myProfile.ContentLength > 0)
                    {
                        string getextenstion = Path.GetExtension(myProfile.FileName);
                        List<string> exts = new List<string>();
                        exts.Add(".png");
                        exts.Add(".jpg");
                        exts.Add(".jpeg");
                        exts.Add(".bmp");
                        if (exts.Contains(getextenstion))
                        {
                            string path = Path.Combine(Server.MapPath("~/UsersProfile"),
                                           Id + getextenstion);
                            myProfile.SaveAs(path);
                            user.Profile = Id + getextenstion;
                        }
                        else
                        {
                            ViewBag.Message = "You have not specified a valid image.";
                            return View(user);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "Error :" + ex.Message;
                    return View(user);
                }
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                Activity acti = new Activity();
                acti.Time = DateTime.Now;
                acti.UserId = User.Identity.GetUserId(); ;
                acti.IPAdress = Request.UserHostAddress;
                acti.Agent = Request.Browser.Type;
                acti.Message = "Edit User Profile";
                db.Activitys.Add(acti);
                db.SaveChanges();
                ViewBag.Message = "All Changes are successfully saved";
            }

            return View(user);
        }
    }
}