using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace AndreTurismoMicroServico.PackageService.Data
{
    public class AndreTurismoMicroServicoPackageServiceContext : DbContext
    {
        public AndreTurismoMicroServicoPackageServiceContext (DbContextOptions<AndreTurismoMicroServicoPackageServiceContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Package> Package { get; set; } = default!;
    }
}
