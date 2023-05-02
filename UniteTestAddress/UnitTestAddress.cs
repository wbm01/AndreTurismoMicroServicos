using AndreTurismoMicroServico.AddressService.Controllers;
using AndreTurismoMicroServico.AddressService.Data;
using Microsoft.EntityFrameworkCore;
using Models;
using Services;
using Xunit;

namespace UniteTestAddress
{
    public class UnitTestAddress
    {
        private DbContextOptions<AndreTurismoMicroServicoAddressServiceContext> options;

        private void InitializeDataBase()
        {
            // Create a Temporary Database
            options = new DbContextOptionsBuilder<AndreTurismoMicroServicoAddressServiceContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            // Insert data into the database using one instance of the context
            using (var context = new AndreTurismoMicroServicoAddressServiceContext(options))
            {
                context.Address.Add(new Address { Id_Address = 1, Street = "Street 1", Cep = "123456789", Id_City_Address = new City() { Id_City = 1, Description = "City1" } });
                context.Address.Add(new Address { Id_Address = 2, Street = "Street 2", Cep = "987654321", Id_City_Address = new City() { Id_City = 2, Description = "City2" } });
                context.Address.Add(new Address { Id_Address = 3, Street = "Street 3", Cep = "159647841", Id_City_Address = new City() { Id_City = 3, Description = "City3" } });
                context.SaveChanges();
            }
        }

        [Fact]
        public void GetAll()
        {
            InitializeDataBase();

            // Use a clean instance of the context to run the test
            using (var context = new AndreTurismoMicroServicoAddressServiceContext(options))
            {
                AddressesController clientController = new AddressesController(context, null);
                IEnumerable<Address> clients = clientController.GetAddress().Result.Value;

                Assert.Equal(3, clients.Count());
            }
        }

        [Fact]
        public void GetbyId()
        {
            InitializeDataBase();

            // Use a clean instance of the context to run the test
            using (var context = new AndreTurismoMicroServicoAddressServiceContext(options))
            {
                int clientId = 2;
                AddressesController clientController = new AddressesController(context, null);
                Address client = clientController.GetAddress(clientId).Result.Value;
                Assert.Equal(2, client.Id_Address);
            }
        }

        [Fact]
        public void Create()
        {
            InitializeDataBase();

            Address address = new Address()
            {
                Id_Address = 4,
                Street = "Rua 10",
                Cep = "14804300",
                Id_City_Address = new() { Id_City = 10, Description = "City 10" }
            };

            // Use a clean instance of the context to run the test
            using (var context = new AndreTurismoMicroServicoAddressServiceContext(options))
            {
                AddressesController clientController = new AddressesController(context, new PostOfficeService());
                Address ad = clientController.PostAddress(address).Result.Value;
                Assert.Equal("Avenida Alberto Benassi", ad.Street);
            }
        }

        [Fact]
        public void Update()
        {
            InitializeDataBase();

            Address address = new Address()
            {
                Id_Address = 3,
                Street = "Rua 10 Alterada",
                Id_City_Address = new() { Id_City = 10, Description = "City 10 alterada" }
            };

            // Use a clean instance of the context to run the test
            using (var context = new AndreTurismoMicroServicoAddressServiceContext(options))
            {
                AddressesController clientController = new AddressesController(context, null);
                Address ad = clientController.PutAddress(3, address).Result.Value;
                Assert.Equal("Rua 10 Alterada", ad.Street);
            }
        }

        [Fact]
        public void Delete()
        {
            InitializeDataBase();

            // Use a clean instance of the context to run the test
            using (var context = new AndreTurismoMicroServicoAddressServiceContext(options))
            {
                AddressesController addressController = new AddressesController(context, null);
                Address address = addressController.DeleteAddress(2).Result.Value;
                Assert.Null(address);
            }
        }
    }
}