using Microsoft.EntityFrameworkCore;

namespace cursoInduccion.backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<cursoInduccion.backend.Model.Accesos> Accesos { get; set; } = default!;
    }
}
