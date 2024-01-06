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
    public class BrunchConfiguration : IEntityTypeConfiguration<Brunch>
    {
        public void Configure(EntityTypeBuilder<Brunch> builder)
        {
            builder.Property(x => x.Name).HasColumnType("jsonb");
            builder.Property(x => x.Address).HasColumnType("jsonb");
            builder.Property(x => x.ImageUrls).HasColumnType("jsonb");
        }
    }
}
