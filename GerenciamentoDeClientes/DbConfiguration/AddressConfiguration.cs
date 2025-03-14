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
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(a => a.State).HasColumnType("CHAR(2)").IsRequired();
            builder.Property(a => a.City).HasColumnType("VARCHAR(60)").IsRequired();
            builder.Property(a => a.Street).HasColumnType("VARCHAR(200)").IsRequired();
            builder.Property(a => a.Number).HasColumnType("VARCHAR(8)").IsRequired();

            builder.HasOne(a => a.Client)
                .WithOne(a => a.Address)
                .HasForeignKey<Address>(a => a.ClientId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
