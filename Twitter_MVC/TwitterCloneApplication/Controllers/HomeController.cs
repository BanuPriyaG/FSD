using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwitterCloneApplication.Models;

namespace TwitterCloneApplication.Controllers
{
    public class HomeController : Controller
    {
        private TwitterModel db = new TwitterModel();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Person person)
        {
            using(db)
            {
                var user = db.People.Where(x => x.user_id.Equals(person.user_id) && x.password.Equals(person.password)).FirstOrDefault();
                if (user!=null)
                {
                    return RedirectToAction("HomePage",user);
                }
                else
                {
                    return View();
                }
            }
            
        }


        
        public ActionResult HomePage(Person person)
        {
            using (db)
            {
                var user = db.People.Where(x => x.user_id.Equals(person.user_id)).FirstOrDefault();
                user.Tweets = db.Tweets.Where(s => s.user_id == person.user_id).ToList();
                    return View(user);
            }

        }





        public ActionResult Signup()
        {

            return View();
        }
       

    }
}