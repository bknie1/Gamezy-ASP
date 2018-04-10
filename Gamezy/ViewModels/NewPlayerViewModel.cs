using System.Collections.Generic;
using Gamezy.Models;

namespace Gamezy.ViewModels
{
    public class NewPlayerViewModel
    {
        // Plenty for iteration.
        public IEnumerable<Membership> Memberships { get; set; }
        public Player Player { get; set; }

    }
}