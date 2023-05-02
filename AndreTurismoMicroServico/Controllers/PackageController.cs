using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using System.Xml.Linq;

namespace AndreTurismoMicroServico.Controllers
{
    public class PackageController
    {
        private PackageService _packageService;
        public PackageController()
        {
            _packageService = new PackageService();
        }

        [HttpGet]
        public async Task<List<Package>> GetPackage()
        {
            return await _packageService.GetPackage();
        }


        [HttpPost(Name = "PostPackage")]
        public async Task<Package> PostPackage(Package package)
        {
            return await _packageService.PostPackage(package);
        }

        [HttpGet("{id}", Name = "BuscaPackagePorId")]
        public async Task<Package> GetPackageById(string id)
        {
            return await _packageService.GetPackageById(id);
        }


        [HttpDelete("{id}")]
        public async Task<Package> DeletePackage(string id)
        {
            return await _packageService.DeletePackage(id);
        }

        [HttpPut("{id}")]
        public async Task<Package> UpdatePackage(Package package)
        {
            return await _packageService.UpdatePackage(package);
        }
    }
}
