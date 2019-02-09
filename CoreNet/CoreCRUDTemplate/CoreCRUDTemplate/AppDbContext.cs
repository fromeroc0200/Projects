using CoreCRUDTemplate.Pages;
using Microsoft.EntityFrameworkCore;

namespace CoreCRUDTemplate
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base (options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}