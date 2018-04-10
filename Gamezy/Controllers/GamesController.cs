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
        private readonly ApplicationDbContext _context;
        private readonly List<Game> _games;
        //---------------------------------------------------------------------
        public GamesController()
        {
            _context = new ApplicationDbContext(); // Disposable object.
            _games = _context.Games.ToList(); // DB Query -> Iterable List
        }
        //---------------------------------------------------------------------
        protected override void Dispose(bool disposing)
        {
            _context.Dispose(); // Manual dispose.
        }

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
                var targetGame = new List<Game> { _games.Find(c => c.Id == id) };
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