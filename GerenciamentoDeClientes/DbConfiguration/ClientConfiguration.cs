using ClientsManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientsManagement.DbConfiguration
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.Property(c => c.Name).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(c => c.Email).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(c => c.Phone).HasColumnType("CHAR(11)").IsRequired();

            builder.HasOne(c => c.Address)
                .WithOne(c => c.Client)
                .HasForeignKey<Address>(a => a.ClientId)
                .IsRequired();
        }
    }
}
