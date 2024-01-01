using Microsoft.EntityFrameworkCore;

namespace PurchaseManagementSys.Models
{
    public class ConnectionStringClass:DbContext
    {
        public ConnectionStringClass(DbContextOptions<ConnectionStringClass>options):base(options)
        {

        }
        public DbSet<Item> items { get; set; }
        public DbSet<Issuance> issuances { get; set; }

        public DbSet<Purchase> purchases { get; set; }
        public DbSet<Vendor> vendors  { get; set; }
        public DbSet<Employee> employees { get; set; }
    }
}
