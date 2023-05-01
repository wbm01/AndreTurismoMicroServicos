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
    public class CityService
    {
        static readonly HttpClient cityClient = new HttpClient();
        public async Task<List<City>> GetCities()
        {
            try
            {
                HttpResponseMessage response = await CityService.cityClient.GetAsync("https://localhost:7229/api/Cities");
                response.EnsureSuccessStatusCode();
                string city = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<City>>(city);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }

        public async Task<City> PostCity(City city)
        {
            try
            {
                HttpResponseMessage resposta = await cityClient.PostAsJsonAsync("https://localhost:7229/api/Cities", city);
                resposta.EnsureSuccessStatusCode();
                return city;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<City> DeleteCity(string id)
        {
            try
            {
                HttpResponseMessage resposta = await cityClient.DeleteAsync("https://localhost:7229/api/Cities/" + id);
                resposta.EnsureSuccessStatusCode();
                string cityResposta = await resposta.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<City>(cityResposta);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }
    }
}
