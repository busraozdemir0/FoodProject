using FoodProject.Data;
using FoodProject.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodProject.Controllers
{
    [AllowAnonymous]
    [Authorize(Roles = "Admin,Uye")]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        Context context = new Context();

        public RegisterController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
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
                    Email = p.Mail,
                    UserName = p.UserName,
                    NameSurname = p.NameSurname

                };

                var result = await _userManager.CreateAsync(user, p.Password);

                var roleName = context.Roles.Where(x => x.NormalizedName == "UYE").Select(y => y.Name).FirstOrDefault();

                if (result.Succeeded)
                {
                    IdentityResult roleresult = await _userManager.AddToRoleAsync(user, roleName);

                    return RedirectToAction("Index", "Category");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View();

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
