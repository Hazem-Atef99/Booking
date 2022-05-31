using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Booking.Models;

namespace Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketAvilablesController : ControllerBase
    {
        private readonly TicketAvilableContext _context;

        public TicketAvilablesController(TicketAvilableContext context)
        {
            _context = context;
        }

        // GET: api/TicketAvilables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketAvilable>>> GetTicketAvilables()
        {
            return await _context.TicketAvilables.ToListAsync();
        }
    
        // GET: api/TicketAvilables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketAvilable>> GetTicketAvilableById(int id)
        {
            var ticketAvilable = await _context.TicketAvilables.FindAsync(id);

            if (ticketAvilable == null)
            {
                return NotFound();
            }

            return ticketAvilable;
        }

        //[HttpGet("{from}/{to}")]
        //public async Task<ActionResult<TicketAvilable>> GetTicketAvilable(string from ,string to)
        //{
        //    var ticketAvilable = await _context.TicketAvilables.FindAsync(from, to);
        //    if (ticketAvilable == null)
        //    {
        //        return NotFound();
        //    }
        //    return ticketAvilable;
        //}
    

    // PUT: api/TicketAvilables/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPut("{id}")]
        public async Task<IActionResult> PutTicketAvilable(int id, TicketAvilable ticketAvilable)
        {
            if (id != ticketAvilable.id)
            {
                return BadRequest();
            }

            _context.Entry(ticketAvilable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketAvilableExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TicketAvilables
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TicketAvilable>> PostTicketAvilable(TicketAvilable ticketAvilable)
        {
            _context.TicketAvilables.Add(ticketAvilable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTicketAvilable", new { id = ticketAvilable.id }, ticketAvilable);
        }

        // DELETE: api/TicketAvilables/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TicketAvilable>> DeleteTicketAvilable(int id)
        {
            var ticketAvilable = await _context.TicketAvilables.FindAsync(id);
            if (ticketAvilable == null)
            {
                return NotFound();
            }

            _context.TicketAvilables.Remove(ticketAvilable);
            await _context.SaveChangesAsync();

            return ticketAvilable;
        }

        private bool TicketAvilableExists(int id)
        {
            return _context.TicketAvilables.Any(e => e.id == id);
        }
    }
}
