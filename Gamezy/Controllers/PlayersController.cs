using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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

        //---------------------------------------------------------------------
        public PlayersController()
        {
            // Note: _context not queried until we iterate over the object.
            _context = new ApplicationDbContext(); // Disposable object.
        }
        //---------------------------------------------------------------------
        protected override void Dispose(bool disposing)
        {
            _context.Dispose(); // Disposable object.
        }
        //---------------------------------------------------------------------
        // GET: Players/New
        public ActionResult New()
        {
            var viewModel = new NewPlayerViewModel { Memberships = _context.Membership.ToList() };
            return View(viewModel);
        }
        //---------------------------------------------------------------------
        // POST: Players/Create
        // To save user data.
        // We use MODEL BINDING to pass our local new player view model.
        [HttpPost]
        public ActionResult Create(NewPlayerViewModel viewModel)
        {
            var newPlayer = new Player
            {
                Name = viewModel.Player.Name,
                Birthday = viewModel.Player.Birthday,
                NewsletterSubscription = viewModel.Player.NewsletterSubscription,
                MembershipId = viewModel.Player.MembershipId
            };

            // Does the player already exist? If so, update. Otherwise, create.
            _context.Players.Add(newPlayer); // Add our new player locally.
            _context.SaveChanges(); // Write changes to DB via transaction.
            return RedirectToAction("Index", "Players");
        }
        //---------------------------------------------------------------------
        // GET: Players/Edit/id
        [Route("Players/Edit/{id:regex(\\d*)}")]
        public ActionResult Edit(int id)
        {
            return View();
        }
        //---------------------------------------------------------------------
        // POST: Players/Update
        // To update user data.
        // TODO: Handle edit or use Create schema to add OR update.
        //---------------------------------------------------------------------
        // GET: Players/id
        [Route("Players/Details/{id:regex(\\d*)}")]
        public ActionResult Details(int id)
        {
            try
            {
                // Queries players with a given key ID to get specific player.
                var targetPlayer = new List<Player> { _context.Players.SingleOrDefault(p => p.Id == id) };

                // Adds that match to a list. Only yields one result.
                _viewModel = new IndexPlayerViewModel { Players = targetPlayer };
                return View(_viewModel);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e);
                throw new HttpException(404, "Not found.");
            }
        }
        //---------------------------------------------------------------------
        // GET: Players
        public ViewResult Index()
        {
            // Fetches all players.
            //_viewModel = new IndexPlayerViewModel { Players = _context.Players.ToList() };

            _viewModel = new IndexPlayerViewModel {Players = _context.Players.Include(p => p.Membership).ToList()};
            return View(_viewModel);
        }
    }
}