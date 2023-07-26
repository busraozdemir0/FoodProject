using FoodProject.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FoodProject.Controllers
{
    [AllowAnonymous]
    public class AboutController : Controller
    {
        Context context = new Context();
        public IActionResult Index()
        {
            var about=context.Abouts.ToList();
            return View(about);
        }
        [HttpGet]
        public IActionResult AboutUpdate(int id)
        {
            var aboutID = context.Abouts.Find(id);
            About about = new About()
            {
                AboutID=aboutID.AboutID,
                AboutTitle=aboutID.AboutTitle,
                AboutText=aboutID.AboutText,
                AboutImageURL=aboutID.AboutImageURL
            };           
            return View(aboutID);
        }
        [HttpPost]
        public IActionResult AboutUpdate(About about)
        {
            var x = context.Abouts.Find(about.AboutID);
            x.AboutTitle = about.AboutTitle;
            x.AboutText = about.AboutText;
            x.AboutImageURL= about.AboutImageURL;
            context.Abouts.Update(x);
            context.SaveChanges();
            return RedirectToAction("Index", "About");
        }
    }
}
