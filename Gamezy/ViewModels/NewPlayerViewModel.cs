using System.Collections.Generic;
using Gamezy.Models;

namespace Gamezy.ViewModels
{
    public class NewPlayerViewModel
    {
        // Data we need to show the user.
        public IEnumerable<Membership> Memberships { get; set; }
        // The object we want to create.
        public Player Player { get; set; }

    }
}