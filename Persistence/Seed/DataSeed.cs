using Domain.Models.Security;
using Elkood.Identity.Entities;
using Elkood.Identity.Mangers;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace Persistence.Seed;

public static class DataSeed
{
    public static async Task Seed(ApplicationDbContext context, IServiceProvider serviceProvider)
    {
        await ProductionSeed(context, serviceProvider);
    }

    private static async Task ProductionSeed(ApplicationDbContext context, IServiceProvider serviceProvider)
    {
        var userManager = serviceProvider.GetRequiredService<ElUserManager<User>>();
        var roleManager = serviceProvider.GetRequiredService<ElRoleManager<ElIdentityRole>>();
        var connectionMultiplexer = serviceProvider.GetRequiredService<IConnectionMultiplexer>();
        context.ChangeTracker.Clear();
        
        await SeedSecurity(userManager, roleManager, context);
    }

    private static async Task SeedSecurity(ElUserManager<User> userManager, ElRoleManager<ElIdentityRole> roleManager,
        ApplicationDbContext context)
    {
        if (context.Users.Any()) return;

        var role = new ElIdentityRole("default"); //seed default role
        await roleManager.CreateAsync(role);
    }
}