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
            return View(orders.ToPagedList(page, 8)); // Her sayfada 8 sipariş olsun
        }
        public IActionResult OrderDetails(int id) 
        {
            var paymentID = context.Payments.Find(id);
            ViewBag.ID = paymentID.AppUserID;
            return View(paymentID);
        }
        public IActionResult OrderCompleted(int id)
        {
            var paymentID = context.Payments.Find(id);
            context.Payments.Remove(paymentID);
            context.SaveChanges();

            var orderDetailID=context.OrderDetails.Where(x => x.AppUserID == paymentID.AppUserID).Select(y=>y.OrderDetailID).ToList();
            foreach(var item in orderDetailID)
            {
                var orderIDFind=context.OrderDetails.Find(item);
                context.OrderDetails.Remove(orderIDFind);
                context.SaveChanges();
            }

            return RedirectToAction("Index", "AdminOrders");
        }
    }
}
