using FoodProject.Data;
using FoodProject.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Linq;

namespace FoodProject.Controllers
{
	[AllowAnonymous] // Bu controller'in yetkilendirilmeden muaf tutulması için yazdık
	public class ChartController : Controller
    {
        // Static Google Chart
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Index2()
        {
            return View();
        }
        public IActionResult VisualizeProductResult()
        {
            return Json(ProList());
        }
        public List<Class1> ProList()
        {
            List<Class1> cs=new List<Class1>();
            cs.Add(new Class1()
            {
                productName="Computer",
                stock=150
            });
            cs.Add(new Class1()
            {
                productName = "LCD",
                stock = 75
            });
            cs.Add(new Class1()
            {
                productName = "USB Disk",
                stock = 220
            });
            return cs;
        }


        // Dynamic Google Chart (Foods)
        public IActionResult Index3()
        {
            return View();
        }
        public IActionResult VisualizeFoodResult()
        {
            return Json(FoodList());
        }
        public List<Class2> FoodList()
        {
            List<Class2> cs2=new List<Class2>();
            using(var context=new Context())
            {
                cs2 = context.Foods.Select(x => new Class2
                {
                    foodName = x.Name,
                    stock = x.Stock
                }).ToList();
            }
            return cs2;
        }



        // Statistics
        public IActionResult Statistics()
        {
            Context context = new Context();

            var foodCount = context.Foods.Count();
            ViewBag.fCount = foodCount;

            var categoryCount = context.Categories.Count();
            ViewBag.categoriCount = categoryCount;

            var fruitCount = context.Foods.Where(x => x.Category.CategoryName == "Meyveler" || x.Category.CategoryName == "meyveler").Count();
            ViewBag.meyveCount = fruitCount;

            var vID = context.Categories.Where(x => x.CategoryName.ToLower() == "sebzeler").Select(y=>y.CategoryID).FirstOrDefault();
            var vegetableCount = context.Foods.Where(x => x.CategoryID==vID).Count();
            ViewBag.sebzeCount = vegetableCount;

            var foodSum = context.Foods.Sum(x => x.Stock);
            ViewBag.fSum = foodSum;

            var legumeCount = context.Foods.Where(x => x.Category.CategoryName.ToLower() == "tahıllar").Count();
            ViewBag.tahılCount = legumeCount;

            var maxStockFood = context.Foods.OrderByDescending(x => x.Stock).Select(y => y.Name).FirstOrDefault(); // FirstOrDefault ile sadece ilk sıradakinin Name'ini çekeceğiz
            ViewBag.maxfStock=maxStockFood;

            var minStockFood = context.Foods.OrderBy(x => x.Stock).Select(y => y.Name).FirstOrDefault(); // OrderBy ile varsayılan olarak ascending sıralayacağı için yine ilk food'u seçtik.
            ViewBag.minfStock = minStockFood;

            var foodPriceAverage=context.Foods.Average(x=>x.Price).ToString("0.00");
            ViewBag.foodPriceAvg = foodPriceAverage;

            var fruitID = context.Categories.Where(x => x.CategoryName.ToLower() == "meyveler").Select(y => y.CategoryID).FirstOrDefault();
            var fruitSum = context.Foods.Where(y=>y.CategoryID==fruitID).Sum(x => x.Stock);
            ViewBag.toplamFruit = fruitSum;

            var vegetableID = context.Categories.Where(x => x.CategoryName.ToLower() == "sebzeler").Select(y => y.CategoryID).FirstOrDefault();
            var vegetableSum = context.Foods.Where(y => y.CategoryID == vegetableID).Sum(x => x.Stock);
            ViewBag.toplamVegetable = vegetableSum;

            var maxPriceFood = context.Foods.OrderByDescending(x => x.Price).Select(y => y.Name).FirstOrDefault();
            ViewBag.maxFiyatFood= maxPriceFood;

            return View();
        }
    }
}
