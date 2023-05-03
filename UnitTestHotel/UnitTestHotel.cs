using System.Security.Cryptography.X509Certificates;
using AndreTurismoMicroServico.HotelService.Controllers;
using AndreTurismoMicroServico.HotelService.Data;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Models;
using Xunit;

namespace UnitTestHotel
{
    public class UnitTestHotel
    {
        private DbContextOptions<AndreTurismoMicroServicoHotelServiceContext>options;

        private void InitializeDataBase()
        {
            options = new DbContextOptionsBuilder<AndreTurismoMicroServicoHotelServiceContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            using(var db = new AndreTurismoMicroServicoHotelServiceContext(options))
            {
                db.Hotel.Add(new Hotel()
                {
                    Id_Hotel = 1,
                    Name_Hotel = "Novo Hotel",
                    Id_Address_Hotel = new Address()
                    {
                        Id_Address = 1,
                        Street = "Rua José Santos",
                        Number = 121,
                        Neighborhood = "Centro",
                        Cep = "22222",
                        Complement = "Rua Nova",
                        Id_City_Address = new City()
                        {
                            Id_City = 1,
                            Description = "Araraquara",
                            DtRegister_City = DateTime.Now,
                        }
                    },
                    DtRegister_Hotel = DateTime.Now,
                    Hotel_Value = 150
                });
                db.SaveChanges();
            }
        }

        [Fact]
        public void GetHotel()
        {
            InitializeDataBase();

            using(var db = new AndreTurismoMicroServicoHotelServiceContext(options))
            {
                HotelsController controller = new HotelsController(db);
                IEnumerable<Hotel> hotels = controller.GetHotel().Result.Value;
                Assert.Equal(1, hotels.Count());
            }
        }

        [Fact]
        public void GetHotelById()
        {

            int id = 1;

            InitializeDataBase();

            using(var db = new AndreTurismoMicroServicoHotelServiceContext(options))
            {
                HotelsController controller = new HotelsController(db);
                Hotel hotel = controller.GetHotel(id).Result.Value;
                Assert.Equal(1, hotel.Id_Hotel);
            }
        }

        [Fact]
        public void PostHotel()
        {
            InitializeDataBase();

            Hotel hotel = new Hotel
            {
                Id_Hotel = 2,
                Name_Hotel = "Hotel da Cidade",
                Id_Address_Hotel = new Address()
                {
                    Id_Address = 2,
                    Street = "Rua José e Maria",
                    Number = 122,
                    Neighborhood = "Centro",
                    Cep = "3333",
                    Complement = "Rua 0",
                    Id_City_Address = new City()
                    {
                        Id_City = 2,
                        Description = "Ibitinga",
                        DtRegister_City = DateTime.Now,
                    }
                },
                DtRegister_Hotel = DateTime.Now,
                Hotel_Value = 200
            };

            using(var db = new AndreTurismoMicroServicoHotelServiceContext(options))
            {
                HotelsController controller = new HotelsController(db);
                Hotel h = controller.PostHotel(hotel).Result.Value;
                Assert.Equal("Hotel da Cidade", hotel.Name_Hotel);
            }
        }

        [Fact]
        public void DeleteHotel()
        {
            InitializeDataBase();

            int id = 1;

            using (var db = new AndreTurismoMicroServicoHotelServiceContext(options))
            {
                HotelsController controller = new HotelsController(db);

                Hotel h = controller.DeleteHotel(id).Result.Value;

                Assert.Null(h);
            }
        }

        [Fact]
        public void UpdateHotel()
        {
            InitializeDataBase();

            Hotel hotel = new Hotel
            {
                Id_Hotel = 2,
                Name_Hotel = "New Hotel",
                Id_Address_Hotel = new Address()
                {
                    Id_Address = 2,
                    Street = "Rua José Fernandes",
                    Number = 321,
                    Neighborhood = "Centro",
                    Cep = "11111",
                    Complement = "Rua 1",
                    Id_City_Address = new City()
                    {
                        Id_City = 2,
                        Description = "Tabatinga",
                        DtRegister_City = DateTime.Now,
                    }
                },
                DtRegister_Hotel = DateTime.Now,
                Hotel_Value = 300
            };

            using (var db = new AndreTurismoMicroServicoHotelServiceContext(options))
            {
                HotelsController controller = new HotelsController(db);

                Hotel h = controller.PutHotel(2, hotel).Result.Value;

                Assert.Equal("New Hotel", hotel.Name_Hotel);
            }
        }
    }
}