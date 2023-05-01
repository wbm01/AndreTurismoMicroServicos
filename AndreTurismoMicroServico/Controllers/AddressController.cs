using System.Net;
using System.Net.Http;
using System.Runtime.ConstrainedExecution;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTO;
using Newtonsoft.Json;
using Services;

namespace AndreTurismoMicroServico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly AddressService _addressService;
        private readonly CityService _cityService;
        private readonly HttpClient _httpClient;

        public AddressController()
        {
            _addressService = new AddressService();
            _cityService = new CityService();
            _httpClient = new HttpClient();
        }


        [HttpGet(Name = "GetAddresses")]
        public async Task<List<Address>> GetAddress()
        {
            return await _addressService.GetAddress();
        }


        [HttpPost(Name = "PostAddresses")]
        public async Task<Address> PostAddress(Address address)
        {
            return await _addressService.PostAddresses(address);
        }

        [HttpDelete("{id}", Name = "DeleteAddress")]
        public async Task<Address> DeleteAddress(string id)
        {
            return await _addressService.DeleteAddress(id);
        }

        [HttpPut("{id}", Name = "UpdateAddress")]
        public async Task<Address> UpdateAddress(Address address)
        {
            return await _addressService.UpdateAddress(address);
        }
    }
}

