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
        FootballAppEntitiesTeamVersion myTables = new FootballAppEntitiesTeamVersion();
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
            List<User> Register = myTables.User.ToList();
            bool users = true, emails = true;
            User user = new User();
            user.Name = Name;
            user.Username = username;
            user.Email = Email;
            user.Age = Age;
            user.Sex = Sex;
            user.Password = Password;
            foreach (var name in Register)
            {
                if (name.Username == username)
                {
                    users = false;
                    break;
                }
            }
            foreach (var emaill in Register)
            {
                if (emaill.Email == Email)
                {
                    emails = false;
                    break;
                }
            }
            if (!(Password == Passwordr && users == true && emails == true))
            {
                return RedirectToAction("IncorrectSignUp", "Error");
            }
            if (Password == Passwordr && users == true && emails == true)
            {
                myTables.User.Add(user);
                myTables.SaveChanges();
            }
            return RedirectToAction("SuccessfulSignUp", "Register");
        }

        public ActionResult SuccessfulSignUp()
        {
            ViewBag.curUser = CurrentUserHolder.currentUsername;
            return View(myTables.MainMenu.ToList());
        }
    }
}