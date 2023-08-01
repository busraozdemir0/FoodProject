using FoodProject.Data;
using FoodProject.Data.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FoodProject.Controllers
{
	[AllowAnonymous]
	public class LoginController : Controller
	{
		private readonly SignInManager<AppUser> _signInManager;

		public LoginController(SignInManager<AppUser> signInManager)
		{
			_signInManager = signInManager;
		}

		[AllowAnonymous] // Projedeki tüm controlleri yetkisiz giriş için engellediğimizden Login'de yer alan Index'i AllowAnonymous ile hariç bırakmış olduk.
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> Index(UserSignInViewModel p)
		{
			if (ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync(p.username, p.password, false, true);
				if (result.Succeeded)
				{
					return RedirectToAction("Statistics", "Chart");
				}
				else
				{
					return RedirectToAction("Index", "Login");
				}

			}
			return View();
		}

		/* Kodların eski hali */
		//      [AllowAnonymous]
		//      [HttpPost]
		//public async Task<IActionResult> Index(Admin admin)
		//{
		//          var dataValue = context.Admins.FirstOrDefault(x => x.UserName == admin.UserName && x.Password == admin.Password);
		//          if (dataValue != null)
		//          {
		//              var claims = new List<Claim>
		//              {
		//                  new Claim(ClaimTypes.Name,admin.UserName)
		//              };
		//              var userIdentity=new ClaimsIdentity(claims,"Login");
		//              ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
		//              await HttpContext.SignInAsync(principal);
		//              return RedirectToAction("Index", "Category");
		//          }
		//          else
		//          {
		//		return View();
		//	}			
		//}


		//[HttpGet]
		//public async Task<IActionResult> LogOut()
		//{
		//	await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
		//	return RedirectToAction("Index", "Login");
		//}

	}
}
