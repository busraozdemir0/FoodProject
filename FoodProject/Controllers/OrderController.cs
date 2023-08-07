﻿using FoodProject.Data;
using FoodProject.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

            p.FoodPrice = food.Price;

            Shopping shopping = new Shopping()
            {
                FoodID = p.FoodID,
                AppUserID = p.AppUserID,
                ShoppingPrice = p.FoodPrice,
            };

            //var line = context.Shoppings.Where(x => x.Food.FoodID == id).FirstOrDefault();
            //var linePrice = context.Shoppings.Where(x => x.Food.FoodID == id).Select(y => y.Food.Price).FirstOrDefault();

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
                var basket = context.Shoppings.Where(x => x.AppUserID == userID).ToList();

                ViewBag.TotalPrice = basket.Sum(x => x.ShoppingPrice * x.ShoppingQuantity);

                if (basket.Count() != 0)
                {
                    ViewBag.basketCount = basket.Count();
                }
                else
                {
                    ViewBag.basketCount = "Ürün bulunmamaktadır.";
                }
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
        [HttpGet]
        public IActionResult PaymentAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult PaymentAdd(Payment payment)
        {
            OrderDetail orderDetail = new OrderDetail();

            var userName = User.Identity.Name;
            var userID = context.Users.Where(x => x.UserName == userName).Select(y => y.Id).FirstOrDefault();
            var paymentID = context.Shoppings.Where(x => x.AppUser.Id == userID).Include(y => y.AppUser).Select(y => y.AppUserID).FirstOrDefault();

            var basket = context.Shoppings.Where(x => x.AppUserID == userID).ToList(); // Giriş yapan kullanıcıya ait sepetteki ürünleri listeler
            foreach (var item in basket)
            {
                if (item.AppUserID != payment.AppUserID)
                {
                   
                    payment.AppUserID = paymentID;    // Giriş yapan kullanıcının id'si ile ödeme yapma işlemi
                    payment.ShoppingTotal = basket.Sum(x => x.ShoppingPrice * x.ShoppingQuantity); // ödenilen toplam fiyatı yansıttık

                    context.Payments.Add(payment);
                    context.SaveChanges();

                    while (item.AppUserID == payment.AppUserID) // Ürün siparişi alındıktan sonra sepetteki ürünleri kaldırma işlemi (Giriş yapan kullanıcının id'sine eşit ürün kaydı oldukça döngü çalışacak)
                    {
                        // Ürün stock güncelleme işlemi
                        var shoppingFoodId = context.Shoppings.Where(x => x.AppUserID == userID).Select(y => y.FoodID).FirstOrDefault();
                        var foods = context.Foods.Find(shoppingFoodId);
                        if (shoppingFoodId == 0) // Sepette ürün kalmayınca döngünün kırılması için
                        {
                            break;
                        }
                        foods.Stock -= item.ShoppingQuantity;

                        // Sipariş verdikten sonra ürünleri sepetten kaldırma işlemi
                        var removeId = context.Shoppings.Where(x => x.AppUserID == userID).Select(y => y.ShoppingID).FirstOrDefault(); // giriş yapan kullanıcının id'si Shopping tablosunda varsa o kaydı seç
                        if (removeId == 0)   // Sepette ürün kalmayınca döngünün kırılması için
                        {
                            break;
                        }

                        orderDetail.FoodName = foods.Name;
                        orderDetail.FoodPrice = foods.Price;
                        orderDetail.FoodImage = foods.ImageURL;
                        orderDetail.FoodStock = foods.Stock;
                        orderDetail.AppUserID = item.AppUserID;
                        context.OrderDetails.Add(orderDetail);
                        context.SaveChanges();

                        var id = context.Shoppings.Find(removeId); // seçilen kaydı Shopping tablosunda bul
                        context.Shoppings.Remove(id); // ve bulunan kaydı sil
                        context.SaveChanges();
                    }
                }

                return RedirectToAction("Index", "Default");
            }

            return View();
        }
    }
}