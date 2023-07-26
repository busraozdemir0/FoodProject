using FoodProject.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FoodProject.ViewComponents
{
    public class CategoryList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Context context = new Context();
            var categoryList = context.Categories.Where(x => x.Status == true).ToList();
            return View(categoryList);
        }
    }
}
