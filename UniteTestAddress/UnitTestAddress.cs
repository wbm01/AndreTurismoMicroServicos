using AndreTurismoMicroServico.AddressService.Controllers;
using AndreTurismoMicroServico.AddressService.Data;
using Microsoft.EntityFrameworkCore;
using Models;
using Services;
using Xunit;

namespace UnitTestAddress
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
                context.Address.Add(new Address { Id_Address = 1, Street = "Street 1", Number = 321, Neighborhood = "São José", Cep = "11111", Complement = "Casa", Id_City_Address = new City() { Id_City = 1, Description = "City1", DtRegister_City = DateTime.Now }, DtRegister_Address = DateTime.Now,  });
                context.Address.Add(new Address { Id_Address = 2, Street = "Street 2", Number = 111, Neighborhood = "Centro", Cep = "22222", Complement = "Casa", Id_City_Address = new City() { Id_City = 2, Description = "City2", DtRegister_City = DateTime.Now }, DtRegister_Address = DateTime.Now,  });
                context.Address.Add(new Address { Id_Address = 3, Street = "Street 3", Number = 222, Neighborhood = "São José", Cep = "33333", Complement = "Casa", Id_City_Address = new City() { Id_City = 3, Description = "City3", DtRegister_City = DateTime.Now }, DtRegister_Address = DateTime.Now,  });
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
        public void PostAddress()
        {
            InitializeDataBase();

            Address address = new Address
            {
                Id_Address = 1,
                Street = "Rua José Santos",
                Number = 321,
                Neighborhood = "Centro",
                Cep = "1111",
                Complement = "Casa 1",
                Id_City_Address = new City()
                { Id_City = 1, Description = "São Paulo", DtRegister_City = DateTime.Now },
                DtRegister_Address = DateTime.Now
            };

            // Use a clean instance of the context to run the test
            using (var context = new AndreTurismoMicroServicoAddressServiceContext(options))
            {
                AddressesController clientController = new AddressesController(context, new PostOfficeService());
                Address ad = clientController.PostAddress(address).Result.Value;
                Assert.Equal("Rua José Santos", ad.Street);
            }
        }

        [Fact]
        public void PutAddress()
        {
            InitializeDataBase();

            Address address = new Address
            {
                Id_Address = 3,
                Street = "Rua José",
                Number = 444,
                Neighborhood = "Selmi Dei",
                Cep = "2222",
                Complement = "Casa 2",
                DtRegister_Address = DateTime.Now,
                Id_City_Address = new City()
                { Id_City = 3, Description = "São Pedro", DtRegister_City = DateTime.Now }
            };

            // Use a clean instance of the context to run the test
            using (var context = new AndreTurismoMicroServicoAddressServiceContext(options))
            {
                AddressesController clientController = new AddressesController(context, null);
                Address ad = clientController.PutAddress(3, address).Result.Value;
                Assert.Equal("Rua José", ad.Street);
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