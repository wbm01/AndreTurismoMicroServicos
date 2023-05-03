using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Models;
using Newtonsoft.Json;

namespace Services
{
    public class TicketService
    {
        static readonly HttpClient ticketClient = new HttpClient();

        public async Task<List<Ticket>> GetTicket()
        {
            try
            {
                HttpResponseMessage response = await TicketService.ticketClient.GetAsync("https://localhost:7268/api/Tickets");
                response.EnsureSuccessStatusCode();
                string ticket = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Ticket>>(ticket);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }

        public async Task<Ticket> GetTicketById(int id)
        {
            try
            {
                HttpResponseMessage response = await TicketService.ticketClient.GetAsync("https://localhost:7268/api/Tickets/" + id);
                response.EnsureSuccessStatusCode();
                string ticket = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Ticket>(ticket);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }

        public async Task<Ticket> PostTicket(Ticket ticket)
        {
            try
            {
                HttpResponseMessage resposta = await ticketClient.PostAsJsonAsync("https://localhost:7268/api/Tickets", ticket);
                resposta.EnsureSuccessStatusCode();
                string ticketResposta = await resposta.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Ticket>(ticketResposta);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }

        public async Task<Ticket> DeleteTicket(int id)
        {
            try
            {
                HttpResponseMessage resposta = await ticketClient.DeleteAsync("https://localhost:7268/api/Tickets/" + id);
                resposta.EnsureSuccessStatusCode();
                string ticketResposta = await resposta.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Ticket>(ticketResposta);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }

        public async Task<Ticket> UpdateTicket(int id, Ticket ticket)
        {
            try
            {
                HttpResponseMessage resposta = await ticketClient.PutAsJsonAsync("https://localhost:7268/api/Tickets/" + id, ticket);
                resposta.EnsureSuccessStatusCode();
                string ticketResposta = await resposta.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Ticket>(ticketResposta);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }
    }
}
