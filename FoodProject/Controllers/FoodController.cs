using FoodProject.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FoodProject.Controllers
{
    public class FoodController : Controller
    {
        public IActionResult Index()
        {
            FoodRepository foodRepository = new FoodRepository();
            return View(foodRepository.TList("Category")); // İlgili yiyeceğin kategori adını getirebilmek için
        }
    }
}
