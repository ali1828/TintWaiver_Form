using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using UserApplication.Models;
using PagedList;
namespace UserApplication.Controllers
{
    [Authorize]
    public class MessagesController : Controller
    {
        
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Messages
        public ActionResult Index()
        {
            var roleadmin = db.Roles.Where(r => r.Name == "Admin").FirstOrDefault();
            var userrole = db.Users.Where(u => u.Roles.Where(r => r.RoleId == roleadmin.Id).FirstOrDefault().RoleId == roleadmin.Id).FirstOrDefault();
            if (!User.IsInRole("Admin"))
                return RedirectToAction("ChatBox/" + userrole.Id);
            List<string> myids = new List<string>();
            var messages = db.Messages.Where(u => u.To == userrole.Id).OrderByDescending(o => o.SendTime).Select(s=>s.From).Distinct();
            myids.AddRange(messages);
            myids.Distinct();
            return View(myids.ToList());
        }
        public ActionResult CheckNewMessages(string id)
        {
            var messages = db.Messages.Where(u => u.From == id && u.Vu==false).ToList();
            foreach (var msg in messages)
            {
                msg.Vu = true;
                db.Entry(msg).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return View(messages);
        }
        public ActionResult ChatBox(string id)
        {
            var userid = User.Identity.GetUserId();
            if (id == null)
            {
                var roleadmin = db.Roles.Where(r => r.Name == "Admin").FirstOrDefault();
                var userrole = db.Users.Where(u => u.Roles.Where(r => r.RoleId == roleadmin.Id).FirstOrDefault().RoleId == roleadmin.Id).FirstOrDefault();
                id = userrole.Id;
                if (userrole.Id == User.Identity.GetUserId())
                    return RedirectToAction("Index");
            }

            Session["IdofMessage"] = id;
            var messages = db.Messages.Where(u => u.To == id && u.From == userid || u.To == userid && u.From == id).ToList();
            foreach (var msg in messages)
            {
                if (msg.To == User.Identity.GetUserId()) { 
                msg.Vu = true;
                db.Entry(msg).State = System.Data.Entity.EntityState.Modified;
                }
            }
            db.SaveChanges();
            return View(messages);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChatBox([Bind(Include = "MessageBody")]Messages message)
        {
            if (ModelState.IsValid)
            {
                var userid = User.Identity.GetUserId();
                Messages newmessage = new Messages();
                newmessage.From = User.Identity.GetUserId();
                newmessage.MessageBody = message.MessageBody;
                newmessage.To = (string)Session["IdofMessage"];

                newmessage.SendTime = DateTime.Now;
                db.Messages.Add(newmessage);
                db.SaveChanges();

                var usefullename = db.Users.Where(u => u.Id == newmessage.From).FirstOrDefault();
                string name;
                if (usefullename.FullName == null || usefullename.FullName == "")
                    name = usefullename.UserName;
                else
                    name = usefullename.UserName;
                Notifications newnotification = new Notifications();
                newnotification.Time = DateTime.Now;
                newnotification.NotificationUser = newmessage.To;
                newnotification.NotificationMessage = "New Messages from " + name;
                newnotification.Type = "message";
                db.Notifications.Add(newnotification);
                db.SaveChanges();


                return RedirectToAction("ChatBox/" + Session["IdofMessage"].ToString());
            }
            return View();
        }
        public ActionResult SendNewMessage(string SearchString, int? page)
        {
            if (!User.IsInRole("Admin"))
                return RedirectToAction("Index");
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var usersrole = db.Roles.Where(r => r.Name == "Users").FirstOrDefault();
            if (SearchString != null)
            {
                var users = db.Users.Where(r => r.Roles.Where(j => j.RoleId == usersrole.Id).FirstOrDefault().RoleId == usersrole.Id).Where(u => u.UserName.Contains(SearchString)).OrderByDescending(u => u.RegistrationDate).ToPagedList(pageNumber, pageSize);
                return View(users);
            }
            var userswithoutsearch = db.Users.Where(r => r.Roles.Where(j => j.RoleId == usersrole.Id).FirstOrDefault().RoleId == usersrole.Id).OrderByDescending(u => u.RegistrationDate).ToPagedList(pageNumber, pageSize);
            return View(userswithoutsearch);
        }
    }
}