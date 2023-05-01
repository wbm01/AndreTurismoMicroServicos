using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace AndreTurismoMicroServico.CityService.Data
{
    public class AndreTurismoMicroServicoCityServiceContext : DbContext
    {
        public AndreTurismoMicroServicoCityServiceContext (DbContextOptions<AndreTurismoMicroServicoCityServiceContext> options)
            : base(options)
        {
        }

        public DbSet<Models.City> City { get; set; } = default!;
    }
}
