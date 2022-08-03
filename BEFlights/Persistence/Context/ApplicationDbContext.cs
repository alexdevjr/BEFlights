using BEFlights.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BEFlights.Persistence.Context
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Flight> Flight { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }
    }
}
