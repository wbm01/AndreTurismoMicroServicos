using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace AndreTurismoMicroServico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ClientService _clientService;
        private readonly AddressService _addressService;
        private readonly HttpClient _httpClient;

        public ClientController()
        {
            _clientService = new ClientService();
            _addressService = new AddressService();
            _httpClient = new HttpClient();
        }


        [HttpGet(Name = "GetClient")]
        public async Task<List<Client>> GetClient()
        {
            return await _clientService.GetClient();
        }

        [HttpGet("{id}", Name = "GetClientById")]
        public async Task<Client> GetClientById(int id)
        {
            return await _clientService.GetClientById(id);
        }


        [HttpPost(Name = "PostClient")]
        public async Task<Client> PostClient(Client client)
        {
            var endereco = _addressService.PostAddresses(client.AddressClient).Result;

            client.AddressClient.Street = endereco.Street;
            client.AddressClient.Number = endereco.Number;
            client.AddressClient.Neighborhood = endereco.Neighborhood;
            client.AddressClient.Cep = endereco.Cep;
            client.AddressClient.Complement = endereco.Complement;
            client.AddressClient.DtRegister_Address = DateTime.Now;
            client.AddressClient.Id_City_Address.Description = endereco.Id_City_Address.Description;
            client.AddressClient.Id_City_Address.DtRegister_City = DateTime.Now;

            return await _clientService.PostClient(client);
        }

        [HttpDelete("{id}", Name = "DeleteClient")]
        public async Task<Client> DeleteClient(int id)
        {
            return await _clientService.DeleteClient(id);
        }

        [HttpPut("{id}", Name = "UpdateClient")]
        public async Task<Client> UpdateClient(int id, Client client)
        {
            return await _clientService.UpdateClient(id, client);
        }
    }
}
