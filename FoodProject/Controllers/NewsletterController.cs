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
        [HttpGet]
        public PartialViewResult Subscribe()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Subscribe(Subscribe subscribe)
        {
            context.Subscribes.Add(subscribe);
            context.SaveChanges();
            Response.Redirect("/Default/Index", true); // Abone olduktan sonra başka sayfaya gitmemesi için
            return PartialView();
        }
    }
}
