using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FootballAppMVC.Models;
using FootballAppMVC.Controllers;

namespace FootballAppMVC.Controllers
{
    public class LogoutController : Controller
    {
        // GET: Logout
        public ActionResult Exit()
        {
            CurrentUserHolder.currentUsername = "";
            return RedirectToAction("Index","Home");
        }
    }
}