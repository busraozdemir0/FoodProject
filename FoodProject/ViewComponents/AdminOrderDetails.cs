using FoodProject.Data;
using FoodProject.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FoodProject.ViewComponents
{
    public class AdminOrderDetails : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Context context = new Context();
            var userOrders=context.OrderDetails.Where(x => x.AppUser.Id == x.AppUserID).ToList();
            return View(userOrders);
        }
    }
}
