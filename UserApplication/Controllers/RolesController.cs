using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserApplication.Models;

namespace UserApplication.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Roles
        public ActionResult Index()
        {
            return View(db.Roles.ToList());
        }



        // GET: Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        [HttpPost]
        public ActionResult Create(IdentityRole role)
        {

            if (ModelState.IsValid)
            {
                db.Roles.Add(role);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(role);

        }

        // GET: Roles/Edit/5
        public ActionResult Edit(string id)
        {
            var myrole = db.Roles.Find(id);
            if (myrole == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (myrole.Name == "Admin" || myrole.Name== "Users")
                {
                    return RedirectToAction("Index");
                }
                return View(myrole);
            }
        }

        // POST: Roles/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Name")]IdentityRole role)
        {

            if (ModelState.IsValid)
            {
                db.Entry(role).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(role);
        }

        // GET: Roles/Delete/5
        public ActionResult Delete(string id)
        {
            var myrole = db.Roles.Find(id);
            if (myrole == null)
            {
                return HttpNotFound();
            }
            else
            {
               
                return View(myrole);
            }


        }

        // POST: Roles/Delete/5
        [HttpPost]
        public ActionResult Delete(IdentityRole role)
        {
            var myrole = db.Roles.Find(role.Id);

            if (myrole == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (myrole.Name == "Admin")
                {
                    ViewBag.ErrorMessage = "Admin Role can't be deleted or edited";
                    return View();
                }
                if (myrole.Name == "Users")
                {
                    ViewBag.ErrorMessage = "Users Role can't be deleted or edited";
                    return View();
                }
                db.Roles.Remove(myrole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }



        }
    }
}