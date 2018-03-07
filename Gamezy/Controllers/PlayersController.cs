using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gamezy.Models;
using Gamezy.ViewModels;

namespace Gamezy.Controllers
{
    public class PlayersController : Controller
    {
        public List<Player> Players = new List<Player>
        {
            new Player() {Name = "Brandon"},
            new Player() {Name = "Philip"},
            new Player() {Name = "Yilan"},
            new Player() {Name = "Chrissy"},
            new Player() {Name = "James"}
        };

        private IndexPlayerViewModel viewModel;

        // GET: Players/id
        [Route("Players/{id:regex(\\d*)}")]
        public ActionResult Index(int? id)
        {
            if(!id.HasValue)
            { 
                return RedirectToAction("Index");
            }
            else
            {
                // Try to find the player.
                try
                {
                    var i = id ?? default(int);
                    // Adds a single, specific player to our list.
                    
                    var targetPlayer = new List<Player>
                    {
                        Players[i]
                    };
                    viewModel = new IndexPlayerViewModel { Players = targetPlayer };

                    return View(viewModel);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e);
                    throw new HttpException(404, "Not found");
                }
            }
            
        }

        // GET: Players
        public ActionResult Index()
        {
            viewModel = new IndexPlayerViewModel { Players = Players };
            return this.View(viewModel);
        }
    }
}