using FoodProject.Data;
using FoodProject.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FoodProject.Controllers
{
    [AllowAnonymous]
    public class OrderController : Controller
    {
        Context context = new Context();
        public IActionResult Index(int id)
        {
            ShoppingViewModel p = new ShoppingViewModel();
            var userName = User.Identity.Name;
            var userId = context.Users.Where(x => x.UserName == userName).Select(y => y.Id).FirstOrDefault();
            var food = context.Foods.Find(id);
            var foodName=context.Foods.Where(x => x.FoodID==id).Select(y=>y.Name).FirstOrDefault();
            p.AppUserID = userId;
            p.FoodID = food.FoodID;
            p.FoodName = foodName;
            Shopping shopping = new Shopping()
            {
                FoodID = p.FoodID,
                AppUserID = p.AppUserID,               
            };

            context.Shoppings.Add(shopping);
            context.SaveChanges();
            return RedirectToAction("Index","Default");
        }
        public IActionResult BasketDetails()
        {
            var userName = User.Identity.Name;
            var shopping = context.Shoppings.Where(x => x.AppUser.UserName == userName).Include(y => y.Food).ToList();

            //var ilans = c.isilanlaris.Where(x => x.AppUser.UserName == userName).Include(x => x.IsBasvuruTbls).ThenInclude(y => y.AppUser).ToList();
            //var ilanid = c.isilanlaris.Where(x => x.AppUserId == userid).Select(y => y.Id).ToList();
            //var sayi = c.IsBasvuruTbls.Where(x => ilanid.Contains(x.isilanlariId)).Select(y => y.AppUserId).Count();
          
            if (User.Identity.IsAuthenticated)
            {
                var basket = context.Shoppings.ToList();
                return View(basket);
            }
            else // sisteme otantike olmamışsa giriş sayfasına yönlendirecek
            {
                return RedirectToAction("Index", "Login");
            }
           
        }
        public IActionResult DeleteProduct(int id)
        {
            var deleteID = context.Shoppings.Find(id);
            context.Shoppings.Remove(deleteID);
            context.SaveChanges();
            return RedirectToAction("BasketDetails", "Order");
        }


    }
}
