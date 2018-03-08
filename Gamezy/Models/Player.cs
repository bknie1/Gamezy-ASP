using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Gamezy.Models
{
    public class Player
    {
        public int Id { get; set; }
        // Data annotations. Easy way to override SQL params.
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool NewsletterSubscription { get; set; }
        public byte MembershipId { get; set; } // Entity will treat this as a foreign key.
        public Membership Membership { get; set; }
    }
}