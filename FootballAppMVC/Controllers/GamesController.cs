using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FootballAppMVC.Models;
using FootballAppMVC.Controllers;

namespace FootballAppMVC.Controllers
{
    public class EditGameIdHolder
    {
        static public int currentEditGameId = 0;
    }
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
            // the game id
            ViewBag.gameId = id;
            EditGameIdHolder.currentEditGameId = id;
            // all games list
            List<Games> allGames = myTables.Games.ToList();
            ViewBag.allGamesList = allGames;
            // all teams list
            List<Team> teamsList = myTables.Team.ToList();
            ViewBag.allTeamsList = teamsList;
            // all games and users pivot list
            List<UserAndGamesPivot> usersGamesList = myTables.UserAndGamesPivot.ToList();
            ViewBag.allUsersGamesList = usersGamesList;
            // all users list
            List<User> userList = myTables.User.ToList();
            ViewBag.allUserList = userList;
            return View(menuItems);
        }
        
        public ActionResult AddPlayer()
        {
            List<User> userList = myTables.User.ToList();
            ViewBag.allUserList = userList;
            if (CurrentUserHolder.currentUsername == "")
            {
                return RedirectToAction("GoLogin","Error");
            }
            UserAndGamesPivot newPlayer = new UserAndGamesPivot();
            foreach (var user in userList)
            {
                if (user.Username == CurrentUserHolder.currentUsername)
                {
                    newPlayer.User_id = user.Id;
                    newPlayer.Game_id = EditGameIdHolder.currentEditGameId;
                    myTables.UserAndGamesPivot.Add(newPlayer);
                    break;
                }
            }
            myTables.SaveChanges();
            return RedirectToAction("EditGame","Games",new { id = EditGameIdHolder.currentEditGameId});
        }
    }
}