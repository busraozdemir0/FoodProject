﻿using FoodProject.Data;
using FoodProject.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        public IActionResult Arama(string p)
        {
            var viewModel = new AramaModel();
            viewModel.AramaKey = p;

            if(!string.IsNullOrEmpty(p))
            { 
                var about = context.Abouts.Where(x => x.AboutTitle!.Contains(p)).ToList();
                var food = context.Foods.Where(x => x.Name!.Contains(p)).ToList();

                if (p == food.ToString())
                {
                    var foodID = context.Foods.Where(x => x.Name == p).Select(y => y.FoodID);
                    ViewBag.fID=foodID;
                }
                viewModel.Abouts= about;
                viewModel.Foods= food;

            }
            return View(viewModel);
        }
        public IActionResult ProductDetails(int id)
        {
            var foodID = context.Foods.Find(id);
            var categoryID = foodID.CategoryID;
            var categoryName = context.Categories.Where(x => x.CategoryID == categoryID).Select(y => y.CategoryName).FirstOrDefault();
            ViewBag.categoryName = categoryName;
            return View(foodID);

        }
    }
}
