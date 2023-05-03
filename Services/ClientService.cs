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
    public class ClientService
    {
        static readonly HttpClient customerClient = new HttpClient();

        public async Task<List<Client>> GetClient()
        {
            try
            {
                HttpResponseMessage response = await ClientService.customerClient.GetAsync("https://localhost:7104/api/Clients");
                response.EnsureSuccessStatusCode();
                string client = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Client>>(client);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }

        public async Task<Client> GetClientById(int id)
        {
            try
            {
                HttpResponseMessage response = await ClientService.customerClient.GetAsync("https://localhost:7104/api/Clients/" + id);
                response.EnsureSuccessStatusCode();
                string client = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Client>(client);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }

        public async Task<Client> PostClient(Client client)
        {
            try
            {
                HttpResponseMessage resposta = await customerClient.PostAsJsonAsync("https://localhost:7104/api/Clients", client);
                resposta.EnsureSuccessStatusCode();
                string clientResposta = await resposta.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Client>(clientResposta);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }

        public async Task<Client> DeleteClient(int id)
        {
            try
            {
                HttpResponseMessage resposta = await customerClient.DeleteAsync("https://localhost:7104/api/Clients/" + id);
                resposta.EnsureSuccessStatusCode();
                string clientResposta = await resposta.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Client>(clientResposta);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }

        public async Task<Client> UpdateClient(Client client)
        {
            try
            {
                HttpResponseMessage resposta = await customerClient.PutAsJsonAsync("https://localhost:7104/api/Clients", client);
                resposta.EnsureSuccessStatusCode();
                string clientResposta = await resposta.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Client>(clientResposta);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }
    }
}
