using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace AndreTurismoMicroServico.TicketService.Data
{
    public class AndreTurismoMicroServicoTicketServiceContext : DbContext
    {
        public AndreTurismoMicroServicoTicketServiceContext (DbContextOptions<AndreTurismoMicroServicoTicketServiceContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Ticket> Ticket { get; set; } = default!;
    }
}
