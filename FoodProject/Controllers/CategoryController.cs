using FoodProject.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FoodProject.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            CategoryRepository categoryRepository = new CategoryRepository();
            return View(categoryRepository.TList());
        }
    }
}
