using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace AndreTurismoMicroServico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly AddressService _addressService;
        private readonly CityService _cityService;
        private readonly HotelService _hotelService;
        private readonly HttpClient _httpClient;

        public HotelController()
        {
            _addressService = new AddressService();
            _hotelService = new HotelService();
            _httpClient = new HttpClient();
        }


        [HttpGet(Name = "GetHotels")]
        public async Task<List<Hotel>> GetHotel()
        {
            return await _hotelService.GetHotel();
        }

        [HttpGet("{id}", Name = "GetHotelById")]
        public async Task<Hotel> GetHotelById(string id)
        {
            return await _hotelService.GetHotelById(id);
        }


        [HttpPost(Name = "PostHotels")]
        public async Task<Hotel> PostHotel(Hotel hotel)
        {
            var endereco = _addressService.PostAddresses(hotel.Id_Address_Hotel).Result;

            hotel.Id_Address_Hotel.Street = endereco.Street;
            hotel.Id_Address_Hotel.Number = endereco.Number;
            hotel.Id_Address_Hotel.Neighborhood = endereco.Neighborhood;
            hotel.Id_Address_Hotel.Cep = endereco.Cep;
            hotel.Id_Address_Hotel.Complement = endereco.Complement;
            hotel.Id_Address_Hotel.DtRegister_Address = DateTime.Now;
            hotel.Id_Address_Hotel.Id_City_Address.Description = endereco.Id_City_Address.Description;
            hotel.Id_Address_Hotel.Id_City_Address.DtRegister_City = DateTime.Now;
            
      
            return await _hotelService.PostHotel(hotel);
        }

        [HttpDelete("{id}", Name = "DeleteHotel")]
        public async Task<Hotel> DeleteHotel(string id)
        {
            return await _hotelService.DeleteHotel(id);
        }

        [HttpPut("{id}", Name = "UpdateHotel")]
        public async Task<Hotel> UpdateHotel(Hotel hotel)
        {
            return await _hotelService.UpdateHotel(hotel);
        }
    }
}
