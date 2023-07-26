using FoodProject.Data;
using FoodProject.Data.Models;
using FoodProject.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using X.PagedList;

namespace FoodProject.Controllers
{
    public class FoodController : Controller
    {
        FoodRepository foodRepository = new FoodRepository();
        Context context = new Context();
        public IActionResult Index(int page = 1)
        {
            return View(foodRepository.TList("Category").ToPagedList(page, 3)); // Sayfalama 1. sayfadan başlayıp her sayfada 3 veri olsun. // İlgili yiyeceğin kategori adını getirebilmek için
        }
        [HttpGet]
        public IActionResult FoodAdd()
        {
            List<SelectListItem> values = (from x in context.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.categories = values;
            return View();
        }
        [HttpPost]
        public IActionResult FoodAdd(FoodImage p)
        {
            Food food = new Food();

            if (p.ImageURL != null)
            {
                var extension = Path.GetExtension(p.ImageURL.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Resimler/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                p.ImageURL.CopyTo(stream);
                food.ImageURL = newImageName;
            }
            food.Name = p.Name;
            food.Price = p.Price;
            food.Stock = p.Stock;
            food.Description = p.Description;
            food.CategoryID = p.CategoryID;
            foodRepository.TAdd(food);
            return RedirectToAction("Index");
        }
        public IActionResult FoodDelete(int id)
        {
            foodRepository.TDelete(new Food { FoodID = id });
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult FoodUpdate(int id)
        {
            // Verileri dropdownlist'e taşıma
            List<SelectListItem> values = (from y in context.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.CategoryName,
                                               Value = y.CategoryID.ToString()
                                           }).ToList();
            ViewBag.categories = values;

            var x = foodRepository.TGet(id);
            return View(x);
        }
        [HttpPost]
        public IActionResult FoodUpdate(FoodImage p)
        {
            Food food=new Food();

            if (p.ImageURL != null)
            {
                var extension = Path.GetExtension(p.ImageURL.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Resimler/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                p.ImageURL.CopyTo(stream);
                food.ImageURL = newImageName;
               
            }
            food.FoodID = p.FoodID;
            food.Name = p.Name;
            food.Stock = p.Stock;
            food.Price = p.Price;
            food.Description = p.Description;
            food.CategoryID = p.CategoryID;
            foodRepository.TUpdate(food); 
            return RedirectToAction("Index","Food");
        }
    }
}
