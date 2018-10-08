using PhoneBookApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace PhoneBookApp.Controllers
{
    public class PersonController : Controller
    {
        private PhoneBookDbEntities db = new PhoneBookDbEntities();
        // GET: Person
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

        // GET: Person/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            ViewBag.AddedBy = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: Person/Create
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(PersonViewModel Modelperson)
        {
            try
            {
                // TODO: Add insert logic here
                //PhoneBookDbEntities db = new PhoneBookDbEntities();
                Person person = new Person();
                person.FirstName = Modelperson.FirstName;
                person.MiddleName = Modelperson.MiddleName;
                person.LastName = Modelperson.LastName;
                person.AddedOn = DateTime.Now;
                person.AddedBy = User.Identity.GetUserId();
                person.UpdateOn = DateTime.Now;
                person.DateOfBirth = Modelperson.DateOfBirth;
                person.HomeAddress = Modelperson.HomeAddress;
                person.HomeCity = Modelperson.HomeCity;
                person.FaceBookAccountId = Modelperson.FaceBookAccountId;
                person.LinkedInId = Modelperson.LinkedInId;
                person.TwitterId = Modelperson.TwitterId;
                person.EmailId = Modelperson.EmailId;
                person.ImagePath = Modelperson.ImagePath;

                db.People.Add(person);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                String error = ex.Message;
                return View();
            }
        }
        

        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Person/Edit/5
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

        // GET: Person/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Person/Delete/5
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
