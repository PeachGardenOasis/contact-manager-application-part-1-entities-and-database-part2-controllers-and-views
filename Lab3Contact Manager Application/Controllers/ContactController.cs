using Lab3Contact_Manager_Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3Contact_Manager_Application.Controllers
{
    public class ContactController : Controller
    {
        private ContactContext context { get; set; }

        public ContactController(ContactContext ctx) // this home controller will be injected into contactcontext
        {
            context = ctx;
        }
        //[HttpGet]
        public ActionResult Details(int id)
        {
            var contact = context.Contacts
                   .Include(c => c.Category) // using Microsoft.EntityFrameworkCore;
                   .FirstOrDefault(c => c.ContactId == id); // get record associated with primary key
            return View(contact);
        }
        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Categoryies = context.Categeories.OrderBy(c => c.Name).ToList();
            return View("Edit", new Contact()); // forward to edit view page and an empty value contact page
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Categoryies = context.Categeories.OrderBy(c => c.Name).ToList();
            var contact = context.Contacts
                   .Include(c => c.Category) // using Microsoft.EntityFrameworkCore;
                   .FirstOrDefault(c => c.ContactId == id); // get record associated with primary key
            return View(contact);
          
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var contact = context.Contacts
                      .Include(c => c.Category) // using Microsoft.EntityFrameworkCore;
                      .FirstOrDefault(c => c.ContactId == id); // get record associated with primary key
            return View(contact);
          
        }
        [HttpPost]
        public ActionResult Edit(Contact contact) // edit action that will take in full contact and persist and update db
        {
            string action = (contact.ContactId == 0) ? "Add" : "Edit"; // if edit contact was passed in is equal to 0 do add action otherwise do edit action
            if (ModelState.IsValid)
            {
                if (action == "Add")
                {
                    contact.DateAdded = DateTime.Now;
                    context.Contacts.Add(contact);
                }
                else
                {
                    context.Contacts.Update(contact);
                }
                context.SaveChanges();
                return RedirectToAction("Index", "Home"); // return home
            }
            else // if modelstate is NOT VALID
            {
                ViewBag.Action = action;
                ViewBag.Categoryies = context.Categeories.OrderBy(c => c.Name).ToList();
                return View(contact);
            }

           
        }
        [HttpPost]
        public ActionResult Delete(Contact contact) // final delete are u sure page
        {
            context.Contacts.Remove(contact);
            context.SaveChanges();// Persist changes
            return RedirectToAction("Index", "Home"); // return home
        }
    }
}
