using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(x => x.Name).HasColumnType("jsonb");
            builder.Property(x => x.Street).HasColumnType("jsonb");
            builder.Property(x => x.Floor).HasColumnType("jsonb");
            builder.Property(x => x.Building).HasColumnType("jsonb");
            builder.Property(x => x.MoreDetails).HasColumnType("jsonb");
        }
    }
}
