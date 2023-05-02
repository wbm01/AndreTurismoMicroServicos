using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace AndreTurismoMicroServico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly CityService _cityService;
        public CityController(CityService cityService)
        {
            _cityService = cityService;
        }


        [HttpGet(Name = "GetAllCities")]
        public async Task<List<City>> GetAll()
        {
            return await _cityService.GetCities();
        }

        [HttpGet("{id}", Name = "GetCitiesById")]
        public async Task<City> GetCityById(string id)
        {
            return await _cityService.GetCityById(id);
        }

        [HttpPost(Name = "PostCity")]
        public async Task<City> PostCity(City city)
        {
            return await _cityService.PostCity(city);
        }

        [HttpDelete("{id}", Name = "DeleteCity")]
        public async Task<City> DeleteCity(string id)
        {
            return await _cityService.DeleteCity(id);
        }

        [HttpPut("{id}", Name = "UpdateCity")]
        public async Task<City> UpdateCity(City city)
        {
            return await _cityService.UpdateCity(city);
        }
    }
}
