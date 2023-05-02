using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Models;
using Newtonsoft.Json;

namespace Services
{
    public class AddressService
    {
        static readonly HttpClient addressClient = new HttpClient();

        public async Task<List<Address>> GetAddress()
        {
            try
            {
                HttpResponseMessage response = await AddressService.addressClient.GetAsync("https://localhost:7211/api/Addresses");
                response.EnsureSuccessStatusCode();
                string address = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Address>>(address);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }

        public async Task<Address> GetAddressById(string id)
        {
            try
            {
                HttpResponseMessage response = await AddressService.addressClient.GetAsync("https://localhost:7211/api/Addresses/" + id);
                response.EnsureSuccessStatusCode();
                string address = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Address>(address);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }

        public async Task<Address>PostAddresses(Address address)
        {
            try
            {
                HttpResponseMessage resposta = await addressClient.PostAsJsonAsync("https://localhost:7211/api/Addresses", address);
                resposta.EnsureSuccessStatusCode();
                string addressResposta = await resposta.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Address>(addressResposta);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }

        public async Task<Address> DeleteAddress(string id)
        {
            try
            {
                HttpResponseMessage resposta = await addressClient.DeleteAsync("https://localhost:7211/api/Addresses/" + id);
                resposta.EnsureSuccessStatusCode();
                string addressResposta = await resposta.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Address>(addressResposta);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }

        public async Task<Address> UpdateAddress(Address address)
        {
            try
            {
                HttpResponseMessage resposta = await addressClient.PutAsJsonAsync("https://localhost:7211/api/Addresses", address);
                resposta.EnsureSuccessStatusCode();
                string addressResposta = await resposta.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Address>(addressResposta);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }
    }
}
