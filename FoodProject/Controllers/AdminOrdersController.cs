using FoodProject.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Linq;
using X.PagedList;

namespace FoodProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminOrdersController : Controller
    {
        Context context = new Context();
        public IActionResult Index(int page = 1)
        {
            //var shopping = context.Shoppings.Include(y => y.Payment).ToList();
            var orders = context.Payments.ToList();
            return View(orders.ToPagedList(page, 6)); // Her sayfada 6 sipariş olsun
        }
    }
}
