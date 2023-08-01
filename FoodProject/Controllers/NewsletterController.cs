using FoodProject.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FoodProject.Controllers
{
    public class NewsletterController : Controller
    {
        Context context = new Context();
        public IActionResult Index()
        {
            var subscribeMails=context.Subscribes.ToList();
            return View(subscribeMails);
        }
        public IActionResult NewsletterDelete(int id)
        {
            var subscribeID = context.Subscribes.Find(id);
            context.Subscribes.Remove(subscribeID);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
