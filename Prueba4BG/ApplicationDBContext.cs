using Microsoft.EntityFrameworkCore;
using Prueba4BG.Models;

namespace Prueba4BG
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
        : base(options) { }


        public DbSet<Operaciones> Operaciones { get; set; }
    }
    
}
