using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class ProductAddOneConfiguration : IEntityTypeConfiguration<ProductAddOne>
    {
        public void Configure(EntityTypeBuilder<ProductAddOne> builder)
        {
            builder.Property(x => x.Name).HasColumnType("jsonb");
         //   builder.OwnsOne(x => x.Product);
        }
    }
}
