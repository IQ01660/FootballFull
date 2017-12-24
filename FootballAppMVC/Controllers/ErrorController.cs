using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FootballAppMVC.Models;
using FootballAppMVC.Controllers;

namespace FootballAppMVC.Controllers
{
    public class ErrorController : Controller
    {
        FootballAppEntitiesTeamVersion myTables = new FootballAppEntitiesTeamVersion();
        // GET: Error/GoLogin
        public ActionResult GoLogin()
        {
            ViewBag.curUser = CurrentUserHolder.currentUsername;
            List<MainMenu> menuItems = myTables.MainMenu.ToList();
            return View(menuItems);
        }
        public ActionResult IncorrectLogin()
        {
            ViewBag.curUser = CurrentUserHolder.currentUsername;
            List<MainMenu> menuItems = myTables.MainMenu.ToList();
            return View(menuItems);
        }
        public ActionResult IncorrectSignUp()
        {
            ViewBag.curUser = CurrentUserHolder.currentUsername;
            List<MainMenu> menuItems = myTables.MainMenu.ToList();
            return View(menuItems);
        }
    }
}