using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tweeter.Models;

namespace Tweeter.Controllers
{
    [Authorize]
    public class TweetController : Controller
    {
        private TweeterDBContext db = new TweeterDBContext();

        //
        // GET: /Tweet/

        public ActionResult Index()
        {
            return View(db.Tweets.ToList());
        }

        //
        // GET: /Tweet/Details/5

        public ActionResult Details(int id = 0)
        {
            Tweet tweet = db.Tweets.Find(id);
            if (tweet == null)
            {
                return HttpNotFound();
            }
            return View(tweet);
        }

        //
        // GET: /Tweet/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Tweet/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tweet tweet)
        {
            if (ModelState.IsValid)
            {
                db.Tweets.Add(tweet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tweet);
        }

        //
        // GET: /Tweet/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Tweet tweet = db.Tweets.Find(id);
            if (tweet == null)
            {
                return HttpNotFound();
            }
            return View(tweet);
        }

        //
        // POST: /Tweet/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tweet tweet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tweet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tweet);
        }

        //
        // GET: /Tweet/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Tweet tweet = db.Tweets.Find(id);
            if (tweet == null)
            {
                return HttpNotFound();
            }
            return View(tweet);
        }

        //
        // POST: /Tweet/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tweet tweet = db.Tweets.Find(id);
            db.Tweets.Remove(tweet);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}