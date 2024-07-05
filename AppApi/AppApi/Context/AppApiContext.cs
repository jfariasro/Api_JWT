using AppApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AppApi.Context
{
    public class AppApiContext : DbContext
    {
        public AppApiContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
