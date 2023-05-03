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
    public class PackageService
    {
        static readonly HttpClient packageClient = new HttpClient();

        public async Task<List<Package>> GetPackage()
        {
            try
            {
                HttpResponseMessage response = await PackageService.packageClient.GetAsync("https://localhost:7004/api/Packages");
                response.EnsureSuccessStatusCode();
                string package = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Package>>(package);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }

        public async Task<Package> GetPackageById(int id)
        {
            try
            {
                HttpResponseMessage response = await PackageService.packageClient.GetAsync("https://localhost:7004/api/Packages/" + id);
                response.EnsureSuccessStatusCode();
                string package = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Package>(package);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }

        public async Task<Package> PostPackage(Package package)
        {
            try
            {
                HttpResponseMessage resposta = await packageClient.PostAsJsonAsync("https://localhost:7004/api/Packages", package);
                resposta.EnsureSuccessStatusCode();
                string packageResposta = await resposta.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Package>(packageResposta);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }

        public async Task<Package> DeletePackage(int id)
        {
            try
            {
                HttpResponseMessage resposta = await packageClient.DeleteAsync("https://localhost:7004/api/Packages/" + id);
                resposta.EnsureSuccessStatusCode();
                string packageResposta = await resposta.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Package>(packageResposta);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }

        public async Task<Package> UpdatePackage(Package package)
        {
            try
            {
                HttpResponseMessage resposta = await packageClient.PutAsJsonAsync("https://localhost:7004/api/Packages", package);
                resposta.EnsureSuccessStatusCode();
                string packageResposta = await resposta.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Package>(packageResposta);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }
    }
}
