using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gamezy.Models;
using Gamezy.ViewModels;

namespace Gamezy.Controllers
{
    public class PlayersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IndexPlayerViewModel _viewModel;
        private readonly List<Player> _players;

        //---------------------------------------------------------------------
        public PlayersController()
        {
            // Note: _context not queried until we iterate over the object.
            _context = new ApplicationDbContext(); // Disposable object.
            _players = _context.Players.ToList(); // DB Query -> Iterable List
        }
        //---------------------------------------------------------------------
        protected override void Dispose(bool disposing)
        {
            _context.Dispose(); // Manual dispose.
        }
        //---------------------------------------------------------------------
        // GET: Players/id
        [Route("Players/Details/{id:regex(\\d*)}")]
        public ActionResult Index(int id)
        {
            try
            {
                // Queries players with a given key ID to get specific player.
                var targetPlayer = new List<Player> { _players.Find(p => p.Id == id) };
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
            _viewModel = new IndexPlayerViewModel { Players = _players };
            return this.View(_viewModel);
        }
    }
}