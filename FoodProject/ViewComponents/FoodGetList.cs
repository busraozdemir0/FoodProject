using FoodProject.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FoodProject.ViewComponents
{
	public class FoodGetList:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			FoodRepository foodRepository = new FoodRepository();
			var foodList = foodRepository.TList().Take(12);
			return View(foodList);
		}
	}
}
