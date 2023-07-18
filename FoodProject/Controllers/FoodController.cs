using FoodProject.Data.Models;
using FoodProject.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FoodProject.Controllers
{
    public class FoodController : Controller
    {
        FoodRepository foodRepository = new FoodRepository();
        public IActionResult Index()
        {
            return View(foodRepository.TList("Category")); // İlgili yiyeceğin kategori adını getirebilmek için
        }
        [HttpGet]
        public IActionResult FoodAdd()
        {
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
    }
}
