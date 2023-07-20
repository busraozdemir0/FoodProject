using FoodProject.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FoodProject.ViewComponents
{
	public class FoodGetList:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			FoodRepository foodRepository = new FoodRepository();
			var foodList = foodRepository.TList();
			return View(foodList);
		}
	}
}
