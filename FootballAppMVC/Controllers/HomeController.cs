using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FootballAppMVC.Models;
using FootballAppMVC.Controllers;

namespace FootballAppMVC.Controllers
{
    public class HomeController : Controller
    {
        FootDbEntities myTables = new FootDbEntities();
        // GET: Home
        public ActionResult Index()
        {
            List<MainMenu> menuItems = myTables.MainMenu.ToList();
            List<Games> gamesList = myTables.Games.ToList();
            List<User> usersList = myTables.User.ToList();
            // Senfing to the view below

            ViewBag.curUser = CurrentUserHolder.currentUsername;
            ViewBag.gamesItems = gamesList;
            ViewBag.usersItems = usersList;
            return View(menuItems);
        }
    }
}