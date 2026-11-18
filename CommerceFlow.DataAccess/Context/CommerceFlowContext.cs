using CommerceFlow.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace CommerceFlow.DataAccess.Context
{
    public class CommerceFlowContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-R7AR1ND;initial catalog=CommerceFlowDb;integrated Security=true;trust server certificate=true");
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
