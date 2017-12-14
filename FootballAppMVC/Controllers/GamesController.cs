using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FootballAppMVC.Models;
using FootballAppMVC.Controllers;

namespace FootballAppMVC.Controllers
{
    public class GamesController : Controller
    {
        FootDbEntities myTables = new FootDbEntities();
        // GET: Games/AllGames
        public ActionResult AllGames()
        {
            ViewBag.curUser = CurrentUserHolder.currentUsername;
            List<MainMenu> menuItems = myTables.MainMenu.ToList();
            // the games list
            List<Games> gamesList = myTables.Games.ToList();
            ViewBag.allGamesList = gamesList;
            // the teams list
            List<Team> teamsList = myTables.Team.ToList();
            ViewBag.allTeamsList = teamsList;
            if(CurrentUserHolder.currentUsername == "")
            {
                return RedirectToAction("GoLogin","Error");
            }
            return View(menuItems);
        }
        public ActionResult NewGame()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewGame(string gameName, string teamFir, string teamSec, string gameDate)
        {
            // creating 2 teams
            Team team1 = new Team();
            Team team2 = new Team();
            //assigning values to teams
            team1.Name = teamFir;
            team2.Name = teamSec;
            team1.Goals = 0;
            team2.Goals = 0;
            // adding teams to the database
            myTables.Team.Add(team1);
            myTables.Team.Add(team2);
            myTables.SaveChanges();
            // adding details to the game
            Games myGame = new Games();
            myGame.Name = gameName;
            myGame.Team1_id = team1.Id;
            myGame.Team2_id = team2.Id;
            myGame.Date = Convert.ToDateTime(gameDate);
            myTables.Games.Add(myGame);
            myTables.SaveChanges();
            return RedirectToAction("AllGames");
        }
        public ActionResult EditGame(int id)
        {
            ViewBag.curUser = CurrentUserHolder.currentUsername;
            // menu items
            List<MainMenu> menuItems = myTables.MainMenu.ToList();
            return View(menuItems);
        }
    }
}