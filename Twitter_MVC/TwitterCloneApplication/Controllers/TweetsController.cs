using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TwitterCloneApplication.Models;

namespace TwitterCloneApplication.Controllers
{
    public class TweetsController : Controller
    {
        private TwitterModel db = new TwitterModel();

        // GET: Tweets
        public ActionResult Index()
        {
            var tweets = db.Tweets.Include(t => t.Person);
            return View(tweets.ToList());
        }

        // GET: Tweets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tweet tweet = db.Tweets.Find(id);
            if (tweet == null)
            {
                return HttpNotFound();
            }
            return View(tweet);
        }

        // GET: Tweets/Create
        public ActionResult Create()
        {
            ViewBag.user_id = new SelectList(db.People, "user_id", "password");
            return View();
        }

        // POST: Tweets/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tweet tweet, string userId)
        {
            if (ModelState.IsValid)
            {
                tweet.created = DateTime.Now;
                tweet.user_id = userId;
                db.Tweets.Add(tweet);
                db.SaveChanges();
            }
            return RedirectToAction("HomePage");
        }

        // GET: Tweets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tweet tweet = db.Tweets.Find(id);
            if (tweet == null)
            {
                return HttpNotFound();
            }
            ViewBag.user_id = new SelectList(db.People, "user_id", "password", tweet.user_id);
            return View(tweet);
        }

        // POST: Tweets/Edit/5.
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
            ViewBag.user_id = new SelectList(db.People, "user_id", "password", tweet.user_id);
            return View(tweet);
        }
    }
}
