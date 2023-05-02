using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace AndreTurismoMicroServico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketControllercs : ControllerBase
    {
        private readonly TicketService _ticketService;
        private readonly AddressService _addressService;
        private readonly ClientService _clientService;
        private readonly HttpClient _httpClient;

        public TicketControllercs()
        {
            _ticketService = new TicketService();
            _addressService = new AddressService();
            _clientService = new ClientService();
            _httpClient = new HttpClient();
        }


        [HttpGet(Name = "GetTicket")]
        public async Task<List<Ticket>> GetTicket()
        {
            return await _ticketService.GetTicket();
        }

        [HttpGet("{id}", Name = "GetTicketById")]
        public async Task<Ticket> GetTicketById(string id)
        {
            return await _ticketService.GetTicketById(id);
        }


        [HttpPost(Name = "PostTicket")]
        public async Task<Ticket> PostTicket(Ticket ticket)
        {
            var tOrigin = ticket.Origin.Id_Address.ToString();
            var tDestiny = ticket.Destiny.Id_City_Address.Id_City.ToString();
            var tClient = ticket.ClientTicket.Id.ToString();

            var origin = _addressService.GetAddressById(tOrigin);
            var destiny = _addressService.GetAddressById(tDestiny);
            var client = _clientService.GetClientById(tClient);

            ticket.Origin = origin.Result;
            ticket.Destiny = destiny.Result;
            ticket.ClientTicket = client.Result;


            return await _ticketService.PostTicket(ticket);
        }

        [HttpDelete("{id}", Name = "DeleteTicket")]
        public async Task<Ticket> DeleteTicket(string id)
        {
            return await _ticketService.DeleteTicket(id);
        }

        [HttpPut("{id}", Name = "UpdateTicket")]
        public async Task<Ticket> UpdateTicket(Ticket ticket)
        {
            return await _ticketService.UpdateTicket(ticket);
        }
    }
}
