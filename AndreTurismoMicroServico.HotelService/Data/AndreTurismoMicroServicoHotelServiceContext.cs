using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace AndreTurismoMicroServico.HotelService.Data
{
    public class AndreTurismoMicroServicoHotelServiceContext : DbContext
    {
        public AndreTurismoMicroServicoHotelServiceContext (DbContextOptions<AndreTurismoMicroServicoHotelServiceContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Hotel> Hotel { get; set; } = default!;
    }
}
