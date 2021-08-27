using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserApplication.Models;
using PagedList;
using System.IO;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;

namespace UserApplication.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DeleteLoginLogs(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            var userdeatils = db.LoginDetails.Where(u => u.Id == id).FirstOrDefault();
            if (userdeatils == null)
                return RedirectToAction("Index");
            db.LoginDetails.Remove(userdeatils);
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }
        public ActionResult UserLoginLogs(string id,int? page)
        {
            if (id == null)
                return RedirectToAction("Index");
            var userdeatils = db.Users.Where(u => u.Id == id).FirstOrDefault();
            if (userdeatils == null)
                return RedirectToAction("Index");
            int pageSize = 30;
            int pageNumber = (page ?? 1);
            var loginlogs = db.LoginDetails.Where(u=>u.UserId==userdeatils.Id).OrderByDescending(u=>u.LoginTime).ToPagedList(pageNumber, pageSize);

            Activity acti = new Activity();
            acti.Time = DateTime.Now;
            acti.UserId = User.Identity.GetUserId(); ;
            acti.IPAdress = Request.UserHostAddress;
            acti.Agent = Request.Browser.Type;
            acti.Message = "Show User login Logs :" + userdeatils.UserName;
            db.Activitys.Add(acti);
            db.SaveChanges();
            return View(loginlogs);
        }
        public ActionResult BannedUsers(int? page)
        {
            var usersrole = db.Roles.Where(r => r.Name == "Users").FirstOrDefault();
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var banneduser = db.Users.Where(u => u.Banned == true);
            return View(banneduser.Where(r => r.Roles.Where(j => j.RoleId == usersrole.Id).FirstOrDefault().RoleId == usersrole.Id).OrderByDescending(u => u.RegistrationDate).ToPagedList(pageNumber, pageSize));
        }
        public ActionResult UncorfirmedUsers(int? page)
        {
            var usersrole = db.Roles.Where(r => r.Name == "Users").FirstOrDefault();
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var uncorfirmedUsers = db.Users.Where(u => u.EmailConfirmed == false);
            return View(uncorfirmedUsers.Where(r => r.Roles.Where(j => j.RoleId == usersrole.Id).FirstOrDefault().RoleId == usersrole.Id).OrderByDescending(u => u.RegistrationDate).ToPagedList(pageNumber, pageSize));
        }
        public ActionResult NewUsers(int? page)
        {
            var usersrole = db.Roles.Where(r => r.Name == "Users").FirstOrDefault();

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var newUsers = db.Users.Where(u => u.RegistrationDate.Month == DateTime.Today.Month);
            return View(newUsers.Where(r => r.Roles.Where(j => j.RoleId == usersrole.Id).FirstOrDefault().RoleId == usersrole.Id).OrderByDescending(u => u.RegistrationDate).ToPagedList(pageNumber, pageSize));
        }
        public ActionResult AllUsers(int? page)
        {
            var usersrole = db.Roles.Where(r => r.Name == "Users").FirstOrDefault();
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var All = db.Users;
            return View(All.Where(r => r.Roles.Where(j => j.RoleId == usersrole.Id).FirstOrDefault().RoleId == usersrole.Id).OrderByDescending(u => u.RegistrationDate).ToPagedList(pageNumber, pageSize));
        }
        public ActionResult UserDetails(string id)
        {
            if (id == null)
                return RedirectToAction("Index");
            var userdeatils = db.Users.Where(u => u.Id == id).FirstOrDefault();
            if (userdeatils == null)
                return RedirectToAction("Index");
            Activity acti = new Activity();
            acti.Time = DateTime.Now;
            acti.UserId = User.Identity.GetUserId();
            acti.IPAdress = Request.UserHostAddress;
            acti.Agent = Request.Browser.Type;
            acti.Message = "Show User Details :" + userdeatils.UserName;
            db.Activitys.Add(acti);
            db.SaveChanges();
            return View(userdeatils);
        }
        public ActionResult UserLogs(string id, int? page)
        {
            if (id == null)
                return RedirectToAction("Index");
            var user = db.Users.Where(u=>u.Id==id).FirstOrDefault();
            if (user == null)
                return RedirectToAction("Index");
            int pageSize = 50;
            int pageNumber = (page ?? 1);
            var userlogs = db.Activitys.Where(u => u.UserId == id);
            Activity acti = new Activity();
            acti.Time = DateTime.Now;
            acti.UserId = User.Identity.GetUserId(); ;
            acti.IPAdress = Request.UserHostAddress;
            acti.Agent = Request.Browser.Type;
            acti.Message = "Show User Logs for :"+user.UserName;
            db.Activitys.Add(acti);
            db.SaveChanges();
            return View(userlogs.OrderByDescending(u=>u.Time).ToPagedList(pageNumber, pageSize));
        }
        public ActionResult EditUser(string id)
        {
            if (id == null)
                return RedirectToAction("Index");
            var useredit = db.Users.Where(u => u.Id == id).FirstOrDefault();
            if (useredit == null)
                return RedirectToAction("Index");
            return View(useredit);
        }
        public ActionResult DeleteUser(string id)
        {
            if (id == null)
                return Redirect(Request.UrlReferrer.ToString());
            var userid = User.Identity.GetUserId();
            if(id==userid)
                return Redirect(Request.UrlReferrer.ToString());
            var useredit = db.Users.Where(u => u.Id == id).FirstOrDefault();
            if (useredit == null)
                return Redirect(Request.UrlReferrer.ToString());
            var userlogin = db.LoginDetails.Where(k=>k.UserId==useredit.Id);
            var useractivity = db.Activitys.Where(a=>a.UserId==useredit.Id);
            try { System.IO.File.Delete(Server.MapPath("~/UsersProfile/" + useredit.Profile)); } catch
            { }
            db.Activitys.RemoveRange(useractivity);
            db.LoginDetails.RemoveRange(userlogin);

            Activity acti = new Activity();
            acti.Time = DateTime.Now;
            acti.UserId = User.Identity.GetUserId(); ;
            acti.IPAdress = Request.UserHostAddress;
            acti.Agent = Request.Browser.Type;
            acti.Message = "Delete User :" + useredit.UserName;
            db.Activitys.Add(acti);
            db.Users.Remove(useredit);

            db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }
        public ActionResult AddUser()
        {
            return View();
        }
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ViewBag.Message += error+ "\n";
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddUser(string UserName, string password, string Email, string FullName, string Birthday, string Country, string Adress, string PhoneNumber, string Skype, string Facebook, string Twitter, HttpPostedFileBase myProfile, string status,string confirmpassword)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = new ApplicationUser { UserName = UserName, Email = Email, FullName=FullName,Birthday=Birthday,Country=Country,Adress=Adress,PhoneNumber=PhoneNumber,Facebook=Facebook,Skype=Skype,Twitter=Twitter };
            if (status == "Banned")
                user.Banned = true;
            else if (status == "Active")
                user.EmailConfirmed = true;
            user.RegistrationDate = DateTime.Now;
            if (password == confirmpassword)
            {
                var result = UserManager.Create(user, password);
                if (result.Succeeded) {
                var userid = db.Users.Where(u => u.UserName == UserName && u.Email == u.Email).FirstOrDefault();
                UserManager.AddToRole(userid.Id, "Users");
                    Activity acti = new Activity();
                    acti.Time = DateTime.Now;
                    acti.UserId = User.Identity.GetUserId(); ;
                    acti.IPAdress = Request.UserHostAddress;
                    acti.Agent = Request.Browser.Type;
                    acti.Message = "Add User :" + UserName;
                    db.Activitys.Add(acti);
                    db.SaveChanges();
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
                                           userid.Id + getextenstion);
                            myProfile.SaveAs(path);
                            userid.Profile = userid.Id + getextenstion;
                            db.Entry(userid).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
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
                    return RedirectToAction("Index");
            }
                AddErrors(result);
            }
            else
            {
                ViewBag.Message = "Password and Confirmation password does not match";
                return View(user);
            }

            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUser(string Id, string UserName, string password, string Email, string FullName, string Birthday, string Country, string Adress, string PhoneNumber, string Skype, string Facebook, string Twitter, HttpPostedFileBase myProfile, string status)
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
                if (status == "Banned") { 
                    user.Banned = true;
                user.EmailConfirmed = true;
                }
                else if (status == "Unconfirmed") { 
                    user.EmailConfirmed = false;
                    user.Banned = false;
                }
                else
                {
                    user.Banned = false;
                    user.EmailConfirmed = true;
                }
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
                    ViewBag.Message = "Error :"+ex.Message;
                    return View(user);
                }
                if (password != "")
                {
                    UserManager<IdentityUser> userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>());
                    string hashedpassword = userManager.PasswordHasher.HashPassword(password);

                    user.PasswordHash = hashedpassword;
                    
                }
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                Activity acti = new Activity();
                acti.Time = DateTime.Now;
                acti.UserId = User.Identity.GetUserId(); 
                acti.IPAdress = Request.UserHostAddress;
                acti.Agent = Request.Browser.Type;
                acti.Message = "Edit User :" + UserName;
                db.Activitys.Add(acti);
                db.SaveChanges();
                ViewBag.Message = "All Changes are successfully saved";
            }

            return View(user);
        }

        public ActionResult DeleteActivity(int id)
        {
            var activity = db.Activitys.Where(u => u.Id == id).FirstOrDefault();
            if (activity!=null){ 
            db.Activitys.Remove(activity);
                db.SaveChanges();
            }
            
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}