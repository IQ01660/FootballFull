using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FootballAppMVC.Models;
using FootballAppMVC.Controllers;

namespace FootballAppMVC.Controllers
{
    public class RegisterController : Controller
    {
        FootDbEntities myTables = new FootDbEntities();
        // GET: Register
        public ActionResult SignUp()
        {
            ViewBag.curUser = CurrentUserHolder.currentUsername;
            return View(myTables.MainMenu.ToList());
        }
        [HttpPost]
        public ActionResult SignUp(string Name, string username, int Age, string Email,
            string Sex, string Password, string Passwordr)
        {
            User user = new User();
            user.Name = Name;
            user.Username = username;
            user.Email = Email;
            user.Age = Age;
            user.Sex = Sex;
            user.Password = Password;
            if (Password == Passwordr)
            {
                myTables.User.Add(user);
                myTables.SaveChanges();
            }
            return RedirectToAction("Index","Home");
        }
    }
}