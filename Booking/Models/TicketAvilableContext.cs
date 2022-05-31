using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Models
{
    public class TicketAvilableContext : DbContext
    {
        public TicketAvilableContext(DbContextOptions<TicketAvilableContext> options) : base(options)
        { }
        public DbSet<TicketAvilable> TicketAvilables { get; set; }
        

        }
    }

