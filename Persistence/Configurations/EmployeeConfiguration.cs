using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class EmployeeConfiguration :  IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.Property(x => x.Name).HasColumnType("jsonb");
        builder.Property(x => x.MobileNumbers).HasColumnType("jsonb");
        builder.Property(x => x.Address).HasColumnType("jsonb");
        builder.Property(x => x.Documents).HasColumnType("jsonb");
    }
}