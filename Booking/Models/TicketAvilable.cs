using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Models
{
    public class TicketAvilable
    { 
        [Key]
        public int id { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public string price { get; set; }
        public string type { get; set; }
        public string time { get; set; }

    }
}
