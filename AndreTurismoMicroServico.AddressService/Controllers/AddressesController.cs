using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndreTurismoMicroServico.AddressService.Data;
using Models;
using Services;
using Models.DTO;
using System.Net;

namespace AndreTurismoMicroServico.AddressService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly AndreTurismoMicroServicoAddressServiceContext _context;
        private readonly PostOfficeService _address;

        public AddressesController(AndreTurismoMicroServicoAddressServiceContext context, PostOfficeService address)
        {
            _context = context;
            _address = address;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddress()
        {
            if (_context.Address == null)
            {
                return NotFound();
            }

            
            return await _context.Address.Include(a => a.Id_City_Address).ToListAsync();
        }
        // GET: api/Addresses/5
        [HttpGet("{id}", Name = "BuscarEndPorId")]
        public async Task<ActionResult<Address>> GetAddress(int id)
        {
          if (_context.Address == null)
          {
              return NotFound();
          }
            var address = await _context.Address.Include(a => a.Id_City_Address).Where(a => a.Id_City_Address.Id_City == id).FirstOrDefaultAsync();

            if (address == null)
            {
                return NotFound();
            }

            return address;
        }

        [HttpGet("{cep:length(8)}")]
        public ActionResult<AddressDTO> GetPostOffices(string cep)
        {
            //Exemplo de chamada de serviço - TESTE
            return _address.GetAddress(cep).Result;
        }

        // PUT: api/Addresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [HttpPut("{id}")]
        public async Task<ActionResult<Address>> PutAddress(int id, Address address)
        {
            if (id != address.Id_Address)
            {
                return BadRequest();
            }
            address = GetPostOffice(address);

            _context.Entry(address).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressExists(id))
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

        [HttpPost]
        public async Task<ActionResult<Address>> PostAddress(Address address)
        {
            if (_context.Address == null)
            {
                return Problem("Entity set 'AndreTurismoAppAddressServiceContext.Address'  is null.");
            }


                var ad = GetPostOffice(address);


            _context.Address.Add(ad);
            await _context.SaveChangesAsync();

            return  ad;
        }
        private Address GetPostOffice(Address address)
        {
            AddressDTO data = _address.GetAddress(address.Cep).Result; // comando Result devolve um retorno do mesmo tipo do parametro Task, no caso AddresDTO
            Address ad = new Address();
            City city = new();

            ad.Id_Address = address.Id_Address;
            ad.Street = data.Logradouro;
            city.Description = data.City;
            city.DtRegister_City = DateTime.Now;
            ad.Id_City_Address = city;
            ad.Number = address.Number;
            ad.Neighborhood = data.Bairro;
            ad.Complement = data.Complemento;
            ad.Cep = data.CEP;
            ad.DtRegister_Address = DateTime.Now;

            return ad;
        }

        // DELETE: api/Addresses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Address>> DeleteAddress(int id)
        {
            if (_context.Address == null)
            {
                return NotFound();
            }
            var address = await _context.Address.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }

            _context.Address.Remove(address);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AddressExists(int id)
        {
            return (_context.Address?.Any(e => e.Id_Address == id)).GetValueOrDefault();
        }
    }
}
