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
        // GET: Games/Random
        public ViewResult Random()
        {
            // There are other ways to do this using ViewBag and ViewData but this is the cleanest.
            var game = new Game { Name = "Heroes of the Storm" };

            var players = new List<Player>
            {
                new Player() {Name = "Brandon"},
                new Player() {Name = "Philip"},
                new Player() {Name = "Yilan"},
                new Player() {Name = "Chrissy"},
                new Player() {Name = "James"}
            };

            var viewModel = new RandomGameViewModel
            {
                Game = game,
                Players = players
            };

            // View(game) is the equivilant of ViewResult.ViewData.Model where game becomes the model.
            return this.View(viewModel);
        }

        public ContentResult Edit(int id)
        {
            return this.Content("id=" + id);
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
//            // If no args, use default values.
//            if (!pageIndex.HasValue)
//                pageIndex = 1;
//
//            if (string.IsNullOrWhiteSpace(sortBy))
//                sortBy = "Name";
//
//            var args = string.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy);

            var games = new List<Game>
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

            var viewModel = new ViewModels.IndexGameViewModel { Games = games };

            return this.View(viewModel);

//            return this.Content(output);
        }
        /*
         *  Instead of using Route Config, we can define routes here.
         *  release format w/ applied regex constaints for input validation.
         *  Route will refer to the below function.
         */
        [Route("games/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int? year, int? month)
        {
            return Content(year + "/" + month);
        }
    }
}