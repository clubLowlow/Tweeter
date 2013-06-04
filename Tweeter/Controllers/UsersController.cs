using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tweeter.Models;
using WebMatrix.WebData;

namespace Tweeter.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private TweeterDBContext db = new TweeterDBContext();

        //
        // GET: /Users/
        [AllowAnonymous]
        public ActionResult Index()
        {
            throw new HttpException(403, "Forbidden");
            //return View(db.Users.ToList());
        }

        //
        // GET: /Users/Details/5

        [AllowAnonymous]
        public ActionResult Details(int id = 0)
        {
            User user = db.Users.Include(u => u.Tweets).Single(u => u.ID == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // GET: /Users/Create

        [AllowAnonymous]
        public ActionResult Create()
        {
            throw new HttpException(403, "Forbidden");
        }

        //
        // POST: /Users/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Create(User user)
        {
            throw new HttpException(403, "Forbidden");
            //if (ModelState.IsValid)
            //{
            //    db.Users.Add(user);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //return View(user);
        }

        public ActionResult EditProfile()
        {
            var currentUserId = WebSecurity.CurrentUserId;

            if (currentUserId == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                return RedirectToAction("Edit", "Users", new { ID = currentUserId });
            }
        }

        //
        // GET: /Users/Edit/5

        public ActionResult Edit(int id = 0)
        {
            var currentUserId = WebSecurity.CurrentUserId;

            if (id != currentUserId) 
            {
                throw new HttpException(403, "Forbidden");
            }

            User user = db.Users.Include(u => u.Tweets).Single(u => u.ID == id);
            
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /Users/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("SearchIndex");
            }
            return View(user);
        }

        //
        // GET: /Users/Delete/5

        public ActionResult Delete(int id = 0)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /Users/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public ActionResult SearchIndex(string searchString)
        {
            var users = from u in db.Users
                                   select u;

            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(u => u.Name.Contains(searchString));
            }

            return View(users);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}