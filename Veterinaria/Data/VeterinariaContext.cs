using Microsoft.EntityFrameworkCore;
using Veterinaria.Models;
namespace Veterinaria.Data
{   
   
        public class VeterinariaDBContext
        : DbContext
        {
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var connectionString = configuration.GetConnectionString("VeterinariaConnStr");
                optionsBuilder.UseSqlServer(connectionString);
            }
            public VeterinariaDBContext(DbContextOptions options)
                : base(options)
            {
                
            }

            public DbSet<Mascotas.Mascota> Mascotas { get; set; }
        }
    
}
