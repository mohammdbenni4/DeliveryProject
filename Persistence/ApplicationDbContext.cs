using Domain.Models;
using Domain.ValueObjects;
using Elkood.Application.Core.Abstractions.Common;
using Elkood.Application.Dispatchers.DomainEventDispatcher;
using Microsoft.EntityFrameworkCore;
using Application.Core;
using Elkood.Persistence.EntityFramework.Extensions;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;
using Domain.Models.Security;
using Elkood.Identity.EntityFramework.Context;

namespace Persistence
{
    public class ApplicationDbContext : ElIdentityDbContext<User> , IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options,
            IDateTime dateTime,
            IDomainEventDispatcher domainEvent): base(options,dateTime,domainEvent) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkTimeValueObject>().HasNoKey();
            base.OnModelCreating(modelBuilder);
            modelBuilder.ConfigurePrimaryKeyValueGenerated<Guid>(ValueGenerated.Never);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.ConfigureElDbFunctions();
        }


        public DbSet<Shop> Shops { get; set; }
        public DbSet<Brunch> Brunches { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ShopCategory> ShopCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductAddOne> ProductAddOnes { get; set; }
        public DbSet<OrdersBrunchesProduct> OrdersBrunchesProduct { get; set; }
        public DbSet<OrdersBrunches> OrdersBrunches { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Neighborhood> Neighborhoods { get; set; }




        


    }
}
