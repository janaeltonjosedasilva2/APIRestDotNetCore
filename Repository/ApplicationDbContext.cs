using api_rest.Models;
using Microsoft.EntityFrameworkCore;

namespace api_rest.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options){}

        public DbSet<Client> Clients { get; set; }
    }
}