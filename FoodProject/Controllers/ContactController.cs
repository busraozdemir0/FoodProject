using FoodProject.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FoodProject.Controllers
{
    public class ContactController : Controller
    {
        Context context = new Context();
        public IActionResult Index()
        {
            var contact = context.Contacts.ToList();
            return View(contact);
        }
        public IActionResult ContactDelete(int id)
        {
            var contactID = context.Contacts.Find(id);
            context.Contacts.Remove(contactID);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult ContactDetails(int id)
        {
            var contactID = context.Contacts.Find(id);
            return View(contactID);
        }

    }
}
