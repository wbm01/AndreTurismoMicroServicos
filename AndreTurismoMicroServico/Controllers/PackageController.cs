using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using System.Xml.Linq;

namespace AndreTurismoMicroServico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController
    {
        private HotelService _hotelService;
        private TicketService _ticketService;
        private ClientService _clientService;
        private PackageService _packageService;
        public PackageController()
        {
            _hotelService = new HotelService();
            _ticketService = new TicketService();
            _clientService = new ClientService();
            _packageService = new PackageService();
        }

        [HttpGet(Name = "GetPackage")]
        public async Task<List<Package>> GetPackage()
        {
            return await _packageService.GetPackage();
        }


        [HttpPost(Name = "PostPackage")]
        public async Task<Package> PostPackage(Package package)
        {
            Hotel hotel = await _hotelService.GetHotelById(package.HotelPackage.Id_Hotel);
            Ticket ticket = await _ticketService.GetTicketById(package.TicketPackage.Id);
            Client client = await _clientService.GetClientById(package.ClientPackage.Id);

            return await _packageService.PostPackage(package);
        }

        [HttpGet("{id}", Name = "GetPackageById")]
        public async Task<Package> GetPackageById(int id)
        {
            return await _packageService.GetPackageById(id);
        }


        [HttpDelete("{id}", Name = "DeletePackage")]
        public async Task<Package> DeletePackage(int id)
        {
            return await _packageService.DeletePackage(id);
        }

        [HttpPut("{id}", Name = "UpdatePackage")]
        public async Task<Package> UpdatePackage(Package package)
        {
            return await _packageService.UpdatePackage(package);
        }
    }
}
