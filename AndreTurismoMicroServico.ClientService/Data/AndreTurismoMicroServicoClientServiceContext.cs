using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace AndreTurismoMicroServico.ClientService.Data
{
    public class AndreTurismoMicroServicoClientServiceContext : DbContext
    {
        public AndreTurismoMicroServicoClientServiceContext (DbContextOptions<AndreTurismoMicroServicoClientServiceContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Client> Client { get; set; } = default!;
    }
}
