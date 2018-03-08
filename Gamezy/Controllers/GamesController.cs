using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gamezy.ViewModels;

namespace Gamezy.Controllers
{
    using Gamezy.Models;

    /// <inheritdoc cref="Controller"/>
    /// <summary>
    /// Interface between our Game model and Game views.
    /// </summary>
    public class GamesController : Controller
    {
        // DEBUG // TODO Create database.
        private readonly List<Game> _games = new List<Game>
        {
            new Game {Name = "Heroes of the Storm"},
            new Game {Name = "Overwatch"},
            new Game {Name = "World of Warcraft"},
            new Game {Name = "Starcraft"},
            new Game {Name = "Monster Hunter"},
            new Game {Name = "Half Life"},
            new Game {Name = "Shenmue"},
            new Game {Name = "Sonic Adventure"},
            new Game {Name = "Elder Scrolls Online"},
            new Game {Name = "Titanfall"},
            new Game {Name = "Counter Strike"}
        };

        // DEBUG // TODO Create database.
        private readonly List<Player> _players = new List<Player>
        {
            new Player() {Name = "Brandon"},
            new Player() {Name = "Philip"},
            new Player() {Name = "Yilan"},
            new Player() {Name = "Chrissy"},
            new Player() {Name = "James"}
        };

        //---------------------------------------------------------------------
        // GET: Games/Random
        public ViewResult Random()
        {
            // Choose random game from the list of games.
            var rnd = new Random();
            var i = rnd.Next(_games.Count);
            var randomGame = _games[i];

            var viewModel = new RandomGameViewModel
            {
                Game = randomGame,
                Players = _players
            };

            // There are other ways to do this using ViewBag and ViewData but this is the cleanest.
            // View(game) is the equivilant of ViewResult.ViewData.Model where game becomes the model.
            return this.View(viewModel);
        }
        //---------------------------------------------------------------------
        // GET: Games/id
        [Route("Games/Details/{id:regex(\\d*)}")]
        public ActionResult Index(int id)
        {
            try
            {
                // Adds a single, specific game to our list.
                var targetGame = new List<Game> { _games[id] };
                var viewModel = new IndexGameViewModel { Games = targetGame };
                return View(viewModel);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e);
                throw new HttpException(404, "Not found");
            }
        }
        //---------------------------------------------------------------------
        // GET Games
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            // If no args, use default values.
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (string.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            var args = string.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy);

            var viewModel = new ViewModels.IndexGameViewModel { Games = _games };

            return this.View(viewModel);

//            return this.Content(output);
        }
        //---------------------------------------------------------------------
        /*
         *  Instead of using Route Config, we can define routes here.
         *  release format w/ applied regex constaints for input validation.
         *  Route will refer to the below function.
         */
        [Route("_games/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int? year, int? month)
        {
            return Content(year + "/" + month);
        }
    }
}