using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndreTurismoMicroServico.PackageService.Data;
using Models;
using System.Net.Sockets;

namespace AndreTurismoMicroServico.PackageService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackagesController : ControllerBase
    {
        private readonly AndreTurismoMicroServicoPackageServiceContext _context;

        public PackagesController(AndreTurismoMicroServicoPackageServiceContext context)
        {
            _context = context;
        }

        // GET: api/Packages
        [HttpGet (Name = "GetPackage")]
        public async Task<ActionResult<IEnumerable<Package>>> GetPackage()
        {
          if (_context.Package == null)
          {
              return NotFound();
          }

            await _context.Package.Include(a => a.HotelPackage).ToListAsync();
            await _context.Package.Include(a => a.HotelPackage.Id_Address_Hotel).ToListAsync();
            await _context.Package.Include(a => a.HotelPackage.Id_Address_Hotel.Id_City_Address).ToListAsync();
            await _context.Package.Include(a => a.TicketPackage.Origin).ToListAsync();
            await _context.Package.Include(a => a.TicketPackage.Origin.Id_City_Address).ToListAsync();
            await _context.Package.Include(a => a.TicketPackage.Destiny).ToListAsync();
            await _context.Package.Include(a => a.TicketPackage.Destiny.Id_City_Address).ToListAsync();
            await _context.Package.Include(a => a.TicketPackage.ClientTicket).ToListAsync();
            await _context.Package.Include(a => a.TicketPackage.ClientTicket.AddressClient).ToListAsync();
            await _context.Package.Include(a => a.TicketPackage.ClientTicket.AddressClient.Id_City_Address).ToListAsync();

            return await _context.Package.ToListAsync();
        }

        // GET: api/Packages/5
        [HttpGet("{id}", Name = "GetPackageById")]
        public async Task<ActionResult<Package>> GetPackage(int id)
        {
          if (_context.Package == null)
          {
              return NotFound();
          }

            await _context.Package.Include(a => a.HotelPackage).ToListAsync();
            await _context.Package.Include(a => a.HotelPackage.Id_Address_Hotel).ToListAsync();
            await _context.Package.Include(a => a.HotelPackage.Id_Address_Hotel.Id_City_Address).ToListAsync();
            await _context.Package.Include(a => a.TicketPackage.Origin).ToListAsync();
            await _context.Package.Include(a => a.TicketPackage.Origin.Id_City_Address).ToListAsync();
            await _context.Package.Include(a => a.TicketPackage.Destiny).ToListAsync();
            await _context.Package.Include(a => a.TicketPackage.Destiny.Id_City_Address).ToListAsync();
            await _context.Package.Include(a => a.TicketPackage.ClientTicket).ToListAsync();
            await _context.Package.Include(a => a.TicketPackage.ClientTicket.AddressClient).ToListAsync();
            await _context.Package.Include(a => a.TicketPackage.ClientTicket.AddressClient.Id_City_Address).ToListAsync();

            var package = await _context.Package.FindAsync(id);

            if (package == null)
            {
                return NotFound();
            }

            return package;
        }

        // PUT: api/Packages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}" , Name = "UpdatePackage")]
        public async Task<IActionResult> PutPackage(int id, Package package)
        {
            if (id != package.Id)
            {
                return BadRequest();
            }

            _context.Entry(package).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PackageExists(id))
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

        // POST: api/Packages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost (Name = "PostPackage")]
        public async Task<ActionResult<Package>> PostPackage(Package package)
        {
          if (_context.Package == null)
          {
              return Problem("Entity set 'AndreTurismoMicroServicoPackageServiceContext.Package'  is null.");
          }
            _context.Entry(package).State = EntityState.Modified;

            _context.Package.Add(package);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPackage", new { id = package.Id }, package);
        }

        // DELETE: api/Packages/5
        [HttpDelete("{id}", Name = "DeletePackage")]
        public async Task<IActionResult> DeletePackage(int id)
        {
            if (_context.Package == null)
            {
                return NotFound();
            }
            var package = await _context.Package.FindAsync(id);
            if (package == null)
            {
                return NotFound();
            }

            _context.Package.Remove(package);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PackageExists(int id)
        {
            return (_context.Package?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
