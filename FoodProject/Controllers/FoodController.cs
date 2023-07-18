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
    }
}
