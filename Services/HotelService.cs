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
    public class HotelService
    {
        static readonly HttpClient hotelClient = new HttpClient();

        public async Task<List<Hotel>> GetHotel()
        {
            try
            {
                HttpResponseMessage response = await HotelService.hotelClient.GetAsync("https://localhost:7063/api/Hotels");
                response.EnsureSuccessStatusCode();
                string hotel = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Hotel>>(hotel);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }

        public async Task<Hotel> GetHotelById(int id)
        {
            try
            {
                HttpResponseMessage response = await HotelService.hotelClient.GetAsync("https://localhost:7063/api/Hotels/" + id);
                response.EnsureSuccessStatusCode();
                string hotel = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Hotel>(hotel);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }

        public async Task<Hotel> PostHotel(Hotel hotel)
        {
            try
            {
                HttpResponseMessage resposta = await hotelClient.PostAsJsonAsync("https://localhost:7063/api/Hotels", hotel);
                resposta.EnsureSuccessStatusCode();
                string hotelResposta = await resposta.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Hotel>(hotelResposta);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }

        public async Task<Hotel> DeleteHotel(int id)
        {
            try
            {
                HttpResponseMessage resposta = await hotelClient.DeleteAsync("https://localhost:7063/api/Hotels/" + id);
                resposta.EnsureSuccessStatusCode();
                string hotelResposta = await resposta.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Hotel>(hotelResposta);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }

        public async Task<Hotel> UpdateHotel(int id, Hotel hotel)
        {
            try
            {
                HttpResponseMessage resposta = await hotelClient.PutAsJsonAsync("https://localhost:7063/api/Hotels/" + id, hotel);
                resposta.EnsureSuccessStatusCode();
                string hotelResposta = await resposta.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Hotel>(hotelResposta);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }
    }
}
