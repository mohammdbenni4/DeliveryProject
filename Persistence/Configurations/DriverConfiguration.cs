using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.Configurations
{
    public class DriverConfiguration : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.Property(x => x.Name).HasColumnType("jsonb");
            builder.Property(x => x.Address).HasColumnType("jsonb");
            builder.Property(x => x.MobileNumbers).HasColumnType("jsonb");
            builder.Property(x => x.WorkingDays).HasColumnType("jsonb");
            
            //builder.Property(c => c.Times).HasColumnType("jsonb");
            builder.Property(c => c.Documents).HasColumnType("jsonb");
        }
    }
}
