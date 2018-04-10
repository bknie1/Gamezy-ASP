using System;
using System.ComponentModel.DataAnnotations;

namespace Gamezy.Models
{
    public class Player
    {
        public int Id { get; set; }
        // Data annotations. Easy way to override SQL params.
        [Required] // No longer nullable.
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public DateTime Birthday { get; set; }
        public bool NewsletterSubscription { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipId { get; set; } // Entity will treat this as a foreign key.

        public Membership Membership { get; set; }
    }
}