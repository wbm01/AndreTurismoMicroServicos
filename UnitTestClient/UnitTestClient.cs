using AndreTurismoMicroServico.ClientService.Controllers;
using AndreTurismoMicroServico.ClientService.Data;
using Microsoft.EntityFrameworkCore;
using Models;
using Xunit;

namespace UnitTestClient
{
    public class UnitTestClient
    {
        private DbContextOptions<AndreTurismoMicroServicoClientServiceContext> options;

        private void InitializeDataBase()
        {
            options = new DbContextOptionsBuilder<AndreTurismoMicroServicoClientServiceContext>()
                 .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                 .Options;

            using (var db = new AndreTurismoMicroServicoClientServiceContext(options))
            {
                db.Client.Add(new Client()
                {
                    Id = 1,
                    NameClient = "Willian",
                    Phone = "169999",
                    AddressClient = new Address()
                    {
                        Id_Address = 1,
                        Street = "Rua José Santos",
                        Number = 321,
                        Neighborhood = "Centro",
                        Cep = "1111",
                        Complement = "Casa 1",
                        DtRegister_Address = DateTime.Now,
                        Id_City_Address = new City()
                        { Id_City = 1, Description = "São Paulo", DtRegister_City = DateTime.Now }
                    }
                });

                db.SaveChanges();
            }
        }

        [Fact]
        public void GetClient()
        {
            InitializeDataBase();

            using (var db = new AndreTurismoMicroServicoClientServiceContext(options))
            {
                ClientsController controller = new ClientsController(db);

                IEnumerable<Client> clients = controller.GetClient().Result.Value;

                Assert.Equal(1, clients.Count());
            }
        }

        [Fact]
        public void GetClientById()
        {
            InitializeDataBase();

            using (var db = new AndreTurismoMicroServicoClientServiceContext(options))
            {
                int id = 1;

                ClientsController controller = new ClientsController(db);

                Client clients = controller.GetClient(id).Result.Value;

                Assert.Equal(1, clients.Id);
            }
        }

        [Fact]
        public void PostClient()
        {
            InitializeDataBase();

            Client client = new Client
            {
                Id = 2,
                NameClient = "José",
                Phone = "169999",
                AddressClient = new Address()
                {
                    Id_Address = 2,
                    Street = "Rua José e Maria",
                    Number = 432,
                    Neighborhood = "Centro",
                    Cep = "1111",
                    Complement = "Casa 2",
                    DtRegister_Address = DateTime.Now,
                    Id_City_Address = new City()
                    { Id_City = 2, Description = "São Pedro", DtRegister_City = DateTime.Now }
                }
            };

            using (var db = new AndreTurismoMicroServicoClientServiceContext(options))
            {
                ClientsController controller = new ClientsController(db);

                Client c = controller.PostClient(client).Result.Value;

                Assert.Equal("José", client.NameClient);
            }
        }

        [Fact]
        public void DeleteClient()
        {
            InitializeDataBase();

            int id = 1;

            using (var db = new AndreTurismoMicroServicoClientServiceContext(options))
            {
                ClientsController controller = new ClientsController(db);

                Client c = controller.DeleteClient(id).Result.Value;

                Assert.Null(c);
            }
        }

        [Fact]
        public void UpdateClient()
        {
            InitializeDataBase();

            Client client = new Client
            {
                Id = 2,
                NameClient = "Maria",
                Phone = "169999",
                AddressClient = new Address()
                {
                    Id_Address = 2,
                    Street = "Rua Maria e José",
                    Number = 231,
                    Neighborhood = "Centro",
                    Cep = "1111",
                    Complement = "Casa 3",
                    DtRegister_Address = DateTime.Now,
                    Id_City_Address = new City()
                    { Id_City = 2, Description = "São Bernardo", DtRegister_City = DateTime.Now }
                }
            };

            using (var db = new AndreTurismoMicroServicoClientServiceContext(options))
            {
                ClientsController controller = new ClientsController(db);

                Client c = controller.PutClient(2, client).Result.Value;

                Assert.Equal("Maria", client.NameClient);
            }
        }
    }
}