using PhoneBookApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneBookApp.Controllers
{
    public class PeopleController : Controller
    {
        private PhoneBookDbEntities db = new PhoneBookDbEntities();
        // GET: People
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

        // GET: People/Details/5
        public ActionResult Details(int id)
        {
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: People/Create
        public ActionResult Create()
        {
            ViewBag.AddedBy = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: People/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: People/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: People/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: People/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: People/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
