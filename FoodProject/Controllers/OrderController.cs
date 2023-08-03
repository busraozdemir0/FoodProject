using FoodProject.Data;
using FoodProject.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Xml.Schema;

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
            p.AppUserID = userId;
            p.FoodID = food.FoodID;

            Shopping shopping = new Shopping()
            {
                FoodID = p.FoodID,
                AppUserID = p.AppUserID,
            };

            var line = context.Shoppings.Where(x => x.Food.FoodID == id).FirstOrDefault();
            var linePrice = context.Shoppings.Where(x => x.Food.FoodID == id).Select(y => y.Food.Price).FirstOrDefault();

            context.Shoppings.Add(shopping);
            context.SaveChanges();
            return RedirectToAction("Index", "Default");

        }
        public IActionResult BasketDetails()
        {
            var userName = User.Identity.Name;
            var userID = context.Users.Where(x => x.UserName == userName).Select(y => y.Id).FirstOrDefault();
            var shopping = context.Shoppings.Where(x => x.AppUser.UserName == userName).Include(y => y.Food).ToList();

            if (User.Identity.IsAuthenticated) // sisteme otantike olmuşsa sepeti görüntüleyecek
            {
                var basket = context.Shoppings.Where(x=>x.AppUserID== userID).ToList();

                ViewBag.TotalPrice = basket.Sum(x => x.Food.Price * x.ShoppingQuantity);
                return View(basket);
            }
            else
            {
                return RedirectToAction("Index", "Category");
            }

        }
        public IActionResult DeleteProduct(int id)
        {
            var deleteID = context.Shoppings.Find(id);
            context.Shoppings.Remove(deleteID);
            context.SaveChanges();
            return RedirectToAction("BasketDetails", "Order");
        }
        public IActionResult PlusProduct(int id)
        {
            var plusID = context.Shoppings.Find(id);
            plusID.ShoppingQuantity += 1;
            context.SaveChanges();
            return RedirectToAction("BasketDetails", "Order");
        }
        
        public IActionResult MinusProduct(int id)
        {
            var minusID = context.Shoppings.Find(id);
            minusID.ShoppingQuantity -= 1;
            context.SaveChanges();
            return RedirectToAction("BasketDetails", "Order");
        }
    }
}
