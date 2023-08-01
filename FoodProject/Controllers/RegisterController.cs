using FoodProject.Data;
using FoodProject.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Threading.Tasks;

namespace FoodProject.Controllers
{
	[AllowAnonymous]
	public class RegisterController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public RegisterController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(UserSignUpViewModel p)
		{
			if (ModelState.IsValid)
			{
				AppUser user = new AppUser()
				{
					Email=p.Mail,
					UserName=p.UserName,
					NameSurname=p.NameSurname
				};
				var result = await _userManager.CreateAsync(user,p.Password);
				if(result.Succeeded)
				{
					return RedirectToAction("Index", "Login");
				}
				else
				{
					foreach(var item in result.Errors)
					{
						ModelState.AddModelError("", item.Description);
					}
				}
			}
			return RedirectToAction("Index", "Login");
			
		}

		//Eski kodlar

		//[HttpPost]
		//public IActionResult Index(Admin admin)
		//{
		//	context.Admins.Add(admin);
		//	context.SaveChanges();
		//	return RedirectToAction("Index", "Login");
		//}
	}
}
