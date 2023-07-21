﻿using FoodProject.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodProject.Controllers
{
	[AllowAnonymous]
	public class DefaultController : Controller
	{
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
        public IActionResult Subscribe()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Subscribe(Subscribe subscribe)
        {
            Context context = new Context();
            context.Subscribes.Add(subscribe);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
