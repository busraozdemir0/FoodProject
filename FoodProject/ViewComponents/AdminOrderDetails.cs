using FoodProject.Data;
using FoodProject.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FoodProject.ViewComponents
{
    public class AdminOrderDetails : ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            Context context = new Context();
            var userOrders=context.OrderDetails.Where(x => x.AppUserID == id).ToList();
            return View(userOrders);
        }
    }
}
