using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodProject.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous] // Projedeki tüm controlleri yetkisiz giriş için engellediğimizden Login'de yer alan Index'i AllowAnonymous ile hariç bırakmış olduk.
        public IActionResult Index()
        {
            return View();
        }
    }
}
