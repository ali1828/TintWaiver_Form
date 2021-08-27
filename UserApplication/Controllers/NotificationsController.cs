using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using UserApplication.Models;

namespace UserApplication.Controllers
{
    [Authorize]
    public class NotificationsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Notifications
        public ActionResult Index(int? page)
        {
            var userid = User.Identity.GetUserId();
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var notifications = db.Notifications.Where(n => n.NotificationUser == userid).OrderByDescending(n => n.Time);
            foreach (var notif in notifications)
            {
                notif.Viewed = true;
                db.Entry(notif).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return View(notifications.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult CheckNewNotification()
        {
            var userid = User.Identity.GetUserId();
            var notifications = db.Notifications.Where(n => n.NotificationUser == userid && n.Viewed==false).OrderByDescending(n => n.Time).ToList();
            foreach (var notif in notifications)
            {
                notif.Viewed = true;
                db.Entry(notif).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return View(notifications.ToList());
        }
    }
}