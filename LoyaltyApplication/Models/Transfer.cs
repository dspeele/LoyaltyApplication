using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoyaltyApplication.Models
{
    public class Transfer
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long Amount { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
