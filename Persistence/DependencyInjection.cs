using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Elkood.DependencyInjection;
using Elkood.Infrastructure.Languages;
using Microsoft.EntityFrameworkCore;
using Application.Core;
using Domain.Models.Security;
using Elkood.Application.Security.JWT.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Elkood.Domain.Core.Culture;
using Elkood.Identity.DependencyInjection;
using Elkood.Identity.Entities;

namespace Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration,
        IWebHostEnvironment environment)
    {
        services.AddElDbContext<IApplicationDbContext, ApplicationDbContext>
       (o =>
       {
           o.UseNpgsql(configuration.GetConnectionString("MyConnection"));
           if (environment.IsDevelopment())
           {
               o.EnableSensitiveDataLogging();
           }
       }, enableLegacyTimestampBehavior: true);
       
       
        services.ConfigureElLanguages(options =>
            options.DefaultLanguage(LanguageCode.ar).Languages(LanguageCode.ar, LanguageCode.en));
        
        services.ConfigureElRepository(o => { o.OrderByDescending("DateCreated"); });
      
        services.AddElIdentity<User, ElIdentityRole, ApplicationDbContext>(options =>
        {
            options.Password.RequiredLength = 4;
            options.Password.RequiredUniqueChars = 0;
            options.Password.RequireDigit = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;
        }).AddJwtBearerAuthentication(configuration);
        return services;

    }
}