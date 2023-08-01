using FoodProject.Data;
using FoodProject.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;

namespace FoodProject.Controllers
{
    [AllowAnonymous]
    [Authorize(Roles = "Admin")]
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
            return View(aboutID);
        }
        [HttpPost]
        public IActionResult AboutUpdate(AboutImage p)
        {
            About about = new About();
            if (p.AboutImageURL != null)
            {
                var extension = Path.GetExtension(p.AboutImageURL.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Resimler/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                p.AboutImageURL.CopyTo(stream);
                about.AboutImageURL = newImageName;
            }
            about.AboutID = p.AboutID;
            about.AboutTitle = p.AboutTitle;
            about.AboutText = p.AboutText;
            context.Abouts.Update(about);
            context.SaveChanges();
            return RedirectToAction("Index", "About");
        }
    }
}
