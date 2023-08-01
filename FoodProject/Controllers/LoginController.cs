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
    [Authorize(Roles = "Admin,Uye")]
    public class LoginController : Controller
	{
		private readonly SignInManager<AppUser> _signInManager;
		Context context = new Context();
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
                    var name = context.Users.Where(x => x.UserName == p.username).Select(y => y.NameSurname).FirstOrDefault();
                    var userId = context.Users.Where(x => x.NameSurname == name).Select(y => y.Id).FirstOrDefault();

                    var userRoleId = context.UserRoles.Where(x => x.UserId == userId).Select(y => y.RoleId).FirstOrDefault();
                    var roleName = context.Roles.Where(x => x.Id == userRoleId).Select(y => y.Name).FirstOrDefault();
                    if (roleName == "Admin")
                    {
                        return RedirectToAction("Statistics", "Chart");
                    }
                    else if (roleName == "Uye")
                    {
                        return RedirectToAction("Index", "Default");
                    }
                }
				else
				{
                    return RedirectToAction("Index", "Login");
                }
			}
			return RedirectToAction("Index", "Login");


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
		public IActionResult AccessDenied()
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> LogOut()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Login");
		}

	}
}
