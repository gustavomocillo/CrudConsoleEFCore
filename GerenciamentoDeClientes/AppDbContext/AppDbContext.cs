using ClientsManagement.DbConfiguration;
using ClientsManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientsManagement.AppDbContext
{
    public class ClientsManagementDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Address> Addresses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source=(localdb)\\mssqllocaldb;Initial Catalog=ClientsManagement; Integrated Security=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
        }
    }
}
