using FoodProject.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FoodProject.Controllers
{
	[AllowAnonymous]
	public class DefaultController : Controller
	{
        Context context = new Context();
        public IActionResult Index()
		{
			return View();
		}
        public IActionResult CategoryDetails(int id)
        {
			ViewBag.ID = id;
            return View();
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
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(Contact contact)
        {
            context.Contacts.Add(contact);
            context.SaveChanges();
            return RedirectToAction("Index", "Default");
        }
        public PartialViewResult Footer()
        {
            return PartialView();
        }
        public IActionResult About()
        {
            var aboutList=context.Abouts.ToList();
            return View(aboutList);
        }
        public IActionResult Products()
        {
            var productList = context.Foods.ToList();
            return View(productList);
        }
        public PartialViewResult Slider()
        {
            return PartialView();
        }
    }
}
