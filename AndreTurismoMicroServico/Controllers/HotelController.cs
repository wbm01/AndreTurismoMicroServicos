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


        [HttpPost(Name = "PostHotels")]
        public async Task<Hotel> PostHotel(Hotel hotel)
        {
            hotel.Id_Address_Hotel.Id_City_Address = _addressService.PostAddresses(hotel.Id_Address_Hotel.Id_City_Address);
            hotel.Id_Address_Hotel = _addressService.PostAddresses(hotel.Id_Address_Hotel);
            
      
            return await _hotelService.PostHotel(hotel);
        }

        [HttpDelete("{id}", Name = "DeleteHotel")]
        public async Task<Hotel> DeleteHotel(string id)
        {
            return await _hotelService.DeleteHotel(id);
        }
    }
}
