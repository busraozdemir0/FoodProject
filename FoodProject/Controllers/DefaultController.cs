using FoodProject.Data;
using FoodProject.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq;

namespace FoodProject.Controllers
{
    [AllowAnonymous]
    [Authorize(Roles = "Admin, Uye")]
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
            var aboutList = context.Abouts.ToList();
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
        public IActionResult Arama(string p)
        {
            var viewModel = new AramaModel();
            viewModel.AramaKey = p;

            if (!string.IsNullOrEmpty(p))
            {
                var about = context.Abouts.Where(x => x.AboutTitle!.Contains(p)).ToList();
                var food = context.Foods.Where(x => x.Name!.Contains(p)).ToList();

                if (food.Count != 0) // Eğer ürün adı yazılmışsa o ürünün id'sini ViewBag ile taşıyalım
                {
                    var foodID = context.Foods.Where(x => x.Name!.Contains(p)).FirstOrDefault();
                    ViewBag.fID = foodID.FoodID;
                }
                viewModel.Abouts = about;
                viewModel.Foods = food;

            }
            return View(viewModel);
        }
        public IActionResult ProductDetails(int id)
        {
            var userName = User.Identity.Name;
            var foodID = context.Foods.Find(id);
            return View(foodID);

        }
    }
}
