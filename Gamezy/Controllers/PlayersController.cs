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
        //DEBUG // TODO Create database.
        public List<Player> Players = new List<Player>
        {
            new Player() {Name = "Brandon"},
            new Player() {Name = "Philip"},
            new Player() {Name = "Yilan"},
            new Player() {Name = "Chrissy"},
            new Player() {Name = "James"}
        };

        private IndexPlayerViewModel _viewModel;
        //---------------------------------------------------------------------
        // GET: Players/id
        [Route("Players/Details/{id:regex(\\d*)}")]
        public ActionResult Index(int id)
        {
            try
            {
                // Adds a single, specific player to our list.
                var targetPlayer = new List<Player> { Players[id] };
                _viewModel = new IndexPlayerViewModel { Players = targetPlayer };
                return View(_viewModel);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e);
                throw new HttpException(404, "Not found");
            }
        }
        //---------------------------------------------------------------------
        // GET: Players
        public ActionResult Index()
        {
            _viewModel = new IndexPlayerViewModel { Players = Players };
            return this.View(_viewModel);
        }
    }
}