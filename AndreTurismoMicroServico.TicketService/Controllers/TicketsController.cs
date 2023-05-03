using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndreTurismoMicroServico.TicketService.Data;
using Models;
using System.Net.Sockets;

namespace AndreTurismoMicroServico.TicketService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly AndreTurismoMicroServicoTicketServiceContext _context;

        public TicketsController(AndreTurismoMicroServicoTicketServiceContext context)
        {
            _context = context;
        }

        // GET: api/Tickets
        [HttpGet (Name = "GetTicket")]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTicket()
        {
          if (_context.Ticket == null)
          {
              return NotFound();
          }

            await _context.Ticket.Include(a => a.Origin).ToListAsync();
            await _context.Ticket.Include(a => a.Origin.Id_City_Address).ToListAsync();
            await _context.Ticket.Include(a => a.Destiny).ToListAsync();
            await _context.Ticket.Include(a => a.Destiny.Id_City_Address).ToListAsync();
            await _context.Ticket.Include(a => a.ClientTicket).ToListAsync();
            await _context.Ticket.Include(a => a.ClientTicket.AddressClient.Id_City_Address).ToListAsync();



            return await _context.Ticket.ToListAsync();
        }

        // GET: api/Tickets/5
        [HttpGet("{id}", Name = "GetTicketById")]
        public async Task<ActionResult<Ticket>> GetTicket(int id)
        {
            if (_context.Ticket == null)
            {
                  return NotFound();
            }

            var ticket = _context.Ticket.Include(a => a.Origin)
                                        .Include(a => a.Destiny)
                                        .Include(a => a.Origin.Id_City_Address)
                                        .Include(a => a.Destiny.Id_City_Address)
                                        .Include(a => a.ClientTicket)
                                        .Include(a => a.ClientTicket.AddressClient.Id_City_Address)
                                        .Where(a => a.Id == id).FirstOrDefault();

            if (ticket == null)
            {
                return NotFound();
            }

            return ticket;
        }

        // PUT: api/Tickets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}", Name = "PutTicket")]
        public async Task<IActionResult> PutTicket(int id, Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return BadRequest();
            }

            _context.Entry(ticket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketExists(id))
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

        // POST: api/Tickets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost( Name = "PostTicket")]
        public async Task<ActionResult<Ticket>> PostTicket(Ticket ticket)
        {
          if (_context.Ticket == null)
          {
              return Problem("Entity set 'AndreTurismoMicroServicoTicketServiceContext.Ticket'  is null.");
          }
            /*var origin = ticket.Origin.Id_Address;
            var destiny = ticket.Destiny.Id_Address;
            var client = ticket.ClientTicket.Id;*/


            _context.Entry(ticket).State = EntityState.Modified;

            _context.Ticket.Add(ticket);

            await _context.SaveChangesAsync();

            return ticket;
        }

        // DELETE: api/Tickets/5
        [HttpDelete("{id}", Name = "DeleteTicket")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            if (_context.Ticket == null)
            {
                return NotFound();
            }
            var ticket = await _context.Ticket.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }

            _context.Ticket.Remove(ticket);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TicketExists(int id)
        {
            return (_context.Ticket?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
