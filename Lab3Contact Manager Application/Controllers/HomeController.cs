using Lab3Contact_Manager_Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace Lab3Contact_Manager_Application.Controllers
{
    public class HomeController : Controller // traffic cop(controller), get result set of contacts and forward user to view
    {
        private ContactContext context { get; set; }

        public HomeController(ContactContext ctx) // this home controller will be injected into contactcontext
        {
            context = ctx;
        }
        
        public IActionResult Index()
        {
            var contacts=context.Contacts
                .Include(c => c.Category) // using Microsoft.EntityFrameworkCore;
                .OrderBy(c => c.Firstname).ToList(); // using System.Linq; needed

            return View(contacts); // forward to index.cshtml by default
        }
    }
}
