using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodProject.Controllers
{
	[AllowAnonymous]
	public class DefaultController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
        public IActionResult CategoryDetails(int id)
        {
			ViewBag.ID = id;
            return View();
        }
    }
}
