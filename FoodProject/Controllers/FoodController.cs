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
        public IActionResult FoodGet(int id)
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
            Food food = new Food()
            {
                FoodID = x.FoodID,
                CategoryID = x.CategoryID,
                Name = x.Name,
                Price = x.Price,
                Stock = x.Stock,
                Description = x.Description,
                ImageURL = x.ImageURL
            };
            return View(food);
        }
        [HttpPost]
        public IActionResult FoodUpdate(Food food)
        {
            //FoodImage p = new FoodImage();
            //if (p.ImageURL != null)
            //{
            //    var extension = Path.GetExtension(p.ImageURL.FileName);
            //    var newImageName = Guid.NewGuid() + extension;
            //    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Resimler/", newImageName);
            //    var stream = new FileStream(location, FileMode.Create);
            //    p.ImageURL.CopyTo(stream);
            //    food.ImageURL = newImageName;
            //}

            var x = foodRepository.TGet(food.FoodID);
            x.Name = food.Name;
            x.Stock = food.Stock;
            x.Price = food.Price;
            x.Description = food.Description;
            x.ImageURL = food.ImageURL;
            x.CategoryID = food.CategoryID;
            foodRepository.TUpdate(x); // x'e göre güncelleme yapacağız
            return RedirectToAction("Index");
        }
    }
}
