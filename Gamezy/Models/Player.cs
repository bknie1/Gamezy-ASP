using System;
using System.ComponentModel.DataAnnotations;

namespace Gamezy.Models
{
    public class Player
    {
        public int Id { get; set; }
        // Data annotations. Easy way to override SQL params.
        [Required] // No longer nullable.
        [StringLength(255)] // Char limit.
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Birthday { get; set; }
        public bool NewsletterSubscription { get; set; }
        public byte MembershipId { get; set; } // Entity will treat this as a foreign key.
        public Membership Membership { get; set; }
    }
}