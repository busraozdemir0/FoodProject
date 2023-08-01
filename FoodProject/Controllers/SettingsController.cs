using FoodProject.Data;
using FoodProject.Data.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FoodProject.Controllers
{
    public class SettingsController : Controller
    {
        Context context = new Context();
        [HttpGet]
        public IActionResult Index(int id)
        {


            //var userName = User.Identity.Name;
            //var userID = context.Admins.Where(x => x.UserName == userName).Select(y => y.AdminID).FirstOrDefault();
            //var name = context.Admins.Where(x => x.UserName == userName).Select(y => y.Name).FirstOrDefault();
            //var surname = context.Admins.Where(x => x.UserName == userName).Select(y => y.Surname).FirstOrDefault();
            //var userN = context.Admins.Where(x => x.AdminID == userID).Select(y => y.UserName).FirstOrDefault();
            //var password = context.Admins.Where(x => x.AdminID == userID).Select(y => y.Password).FirstOrDefault();
            //var eMail = context.Admins.Where(x => x.AdminID == userID).Select(y => y.EMail).FirstOrDefault();

            //UserUpdateModel model = new UserUpdateModel();
            //model.userid = userID;
            //model.name = name;
            //model.surname = surname;
            //model.email = eMail;
            //model.username = userName;
            //model.password = password;
            
            var adminID = context.Admins.Find(id);
            ViewBag.admin = adminID;
            return View(adminID);

        }
        [HttpPost]
        public IActionResult Index(Admin admin)
        {
            //var userName = User.Identity.Name;
            //var userID = context.Admins.Where(x => x.UserName == userName).Select(y => y.AdminID).FirstOrDefault();
            //model.userid = userID;
            //if (ModelState.IsValid)
            //{
            //    Admin admin = new Admin
            //    {
            //        AdminID = model.userid,
            //        Name = model.name,
            //        Surname = model.surname,
            //        EMail = model.surname,
            //        UserName = model.username,
            //        Password = model.password
            //    };
            //    Admin user = new Admin();
            //    user.Name = model.name;
            //    user.Surname = model.surname;
            //    user.EMail = model.email;
            //    user.UserName = model.username;
            //    user.Password = model.password;

            context.Admins.Update(admin);
            context.SaveChanges();
            return RedirectToAction("Index","Statistics");

        }

    }
}
