using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gamezy.Models
{
    public class Membership
    {
        public byte Id { get; set; }
        public short SignUpFee { get; set; } // $0 - $32,000
        public byte DurationMonth { get; set; } // 0 - 12 Months
        public byte DiscountRate { get; set; } // 0 - 100%
    }
}