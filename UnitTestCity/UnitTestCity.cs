using AndreTurismoMicroServico.AddressService.Data;
using AndreTurismoMicroServico.CityService.Data;
using AndreTurismoMicroServico.CityService.Controllers;
using AndreTurismoMicroServico.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Models;
using Xunit;

namespace UnitTestCity
{
    public class UnitTestCity
    {
        private DbContextOptions<AndreTurismoMicroServicoCityServiceContext> options;

        private void InitializeDataBase()
        {
            options = new DbContextOptionsBuilder<AndreTurismoMicroServicoCityServiceContext>()
                 .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                 .Options;

            using (var db = new AndreTurismoMicroServicoCityServiceContext(options))
            {
                db.City.Add(new City { Id_City = 1, Description = "Ibitinga", DtRegister_City = DateTime.Now });
                db.City.Add(new City { Id_City = 2, Description = "Araraquara", DtRegister_City = DateTime.Now });
            }
        }

        [Fact]
        public void GetCity()
        {
            InitializeDataBase();

            using (var db = new AndreTurismoMicroServicoCityServiceContext(options))
            {
                CitiesController controller = new CitiesController(db);

                IEnumerable<City> cities = controller.GetCity().Result.Value;

                Assert.Equal(1, cities.Count());
            }
        }

        [Fact]
        public void GetCityById()
        {
            InitializeDataBase();

            using (var db = new AndreTurismoMicroServicoCityServiceContext(options))
            {
                int id = 2;

                CitiesController controller = new CitiesController(db);

                City cities = controller.GetCity(id).Result.Value;

                Assert.Equal(1, cities.Id_City);
            }
        }

        [Fact]
        public void PostCity()
        {
            InitializeDataBase();

            City city = new City();

            city.Id_City = 1;
            city.Description = "Bauru";
            city.DtRegister_City = DateTime.Now;

            using (var db = new AndreTurismoMicroServicoCityServiceContext(options))
            {
                CitiesController controller = new CitiesController(db);

                City c = controller.PostCity(city).Result.Value;

                Assert.Equal("Bauru", city.Description);
            }
        }

        [Fact]
        public void DeleteCity()
        {
            InitializeDataBase();

            int id = 1;

            using(var db = new AndreTurismoMicroServicoCityServiceContext(options))
            {
                CitiesController controller = new CitiesController(db);

                City c = controller.DeleteCity(id).Result.Value;

                Assert.Null(c);
            }
        }

        [Fact]
        public void UpdateCity()
        {
            InitializeDataBase();

            City city = new City();
            city.Id_City = 1;
            city.Description = "Bariri";
            city.DtRegister_City = DateTime.Now;

            using(var db = new AndreTurismoMicroServicoCityServiceContext(options))
            {
                CitiesController controller = new CitiesController(db);

                City c = controller.PutCity(1, city).Result.Value;

                Assert.Equal("Bariri", city.Description);
            }
        }
    }
}