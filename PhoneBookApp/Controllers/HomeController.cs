using PhoneBookApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneBookApp.Controllers
{
    public class HomeController : Controller
    {
        private PhoneBookDbEntities db = new PhoneBookDbEntities();
        public ActionResult Index()
        {
            List<Person> lst = db.People.ToList();
            List<Person> viewList = new List<Person>();
            foreach (Person p in lst)
            {
                Person person = new Person();
                person.FirstName = p.FirstName;
                person.MiddleName = p.MiddleName;
                person.LastName = p.LastName;
                person.DateOfBirth = p.DateOfBirth;
                person.AddedOn = p.AddedOn;
                person.AddedBy = p.AddedBy;
                person.HomeAddress = p.HomeAddress;
                person.HomeCity = p.HomeCity;
                person.FaceBookAccountId = p.FaceBookAccountId;
                person.LinkedInId = p.LinkedInId;
                person.UpdateOn = p.UpdateOn;
                person.ImagePath = p.ImagePath;
                person.TwitterId = p.TwitterId;
                person.EmailId = p.EmailId;
                viewList.Add(person);
            }

            return View(viewList);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}