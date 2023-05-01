using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace AndreTurismoMicroServico.AddressService.Data
{
    public class AndreTurismoMicroServicoAddressServiceContext : DbContext
    {
        public AndreTurismoMicroServicoAddressServiceContext (DbContextOptions<AndreTurismoMicroServicoAddressServiceContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Address> Address { get; set; } = default!;
    }
}
