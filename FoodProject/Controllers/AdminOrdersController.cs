using FoodProject.Data;
using FoodProject.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var orders = context.Payments.ToList();
            return View(orders.ToPagedList(page, 6)); // Her sayfada 6 sipariş olsun
        }
        public IActionResult OrderDetails(int id) 
        {
            var paymentID = context.Payments.Find(id);           
            return View(paymentID);
        }
    }
}
