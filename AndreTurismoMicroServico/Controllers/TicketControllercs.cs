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
        public async Task<Ticket> GetTicketById(int id)
        {
            return await _ticketService.GetTicketById(id);
        }


        [HttpPost(Name = "PostTicket")]
        public async Task<Ticket> PostTicket(Ticket ticket)
        {

            Address origin = await _addressService.GetAddressById(ticket.Origin.Id_Address);
            Address destiny = await _addressService.GetAddressById(ticket.Destiny.Id_Address);
            Client client = await _clientService.GetClientById(ticket.ClientTicket.Id);


            ticket.Origin = origin;
            ticket.Destiny = destiny;
            ticket.ClientTicket = client;


            return await _ticketService.PostTicket(ticket);
        }

        [HttpDelete("{id}", Name = "DeleteTicket")]
        public async Task<Ticket> DeleteTicket(int id)
        {
            return await _ticketService.DeleteTicket(id);
        }

        [HttpPut("{id}", Name = "UpdateTicket")]
        public async Task<Ticket> UpdateTicket(int id, Ticket ticket)
        {
            return await _ticketService.UpdateTicket(id, ticket);
        }
    }
}
