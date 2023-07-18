using FoodProject.Data.Models;
using FoodProject.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace FoodProject.Controllers
{
    public class FoodController : Controller
    {
        FoodRepository foodRepository = new FoodRepository();
        Context context = new Context();
        public IActionResult Index()
        {
            return View(foodRepository.TList("Category")); // İlgili yiyeceğin kategori adını getirebilmek için
        }
        [HttpGet]
        public IActionResult FoodAdd()
        {
            List<SelectListItem> values = (from x in context.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text=x.CategoryName,
                                               Value=x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.categories = values;
            return View();
        }
        [HttpPost]
        public IActionResult FoodAdd(Food food)
        {
            if (!ModelState.IsValid)
            {
                return View("FoodAdd");
            }
            foodRepository.TAdd(food);
            return RedirectToAction("Index");
        }
        public IActionResult FoodDelete(int id)
        {
            foodRepository.TDelete(new Food { FoodID=id});
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
                FoodID=x.FoodID,
                CategoryID=x.CategoryID,
                Name=x.Name,
                Price=x.Price,
                Stock=x.Stock,
                Description=x.Description,
                ImageURL=x.ImageURL
            };
            return View(food);
        }
        [HttpPost]
        public IActionResult FoodUpdate(Food food)
        {
            var x=foodRepository.TGet(food.FoodID);
            x.Name= food.Name;
            x.Stock=food.Stock;
            x.Price=food.Price;
            x.Description=food.Description;
            x.ImageURL=food.ImageURL;
            x.CategoryID=food.CategoryID;
            foodRepository.TUpdate(x); // x'e göre güncelleme yapacağız
            return RedirectToAction("Index");
        }
    }
}
