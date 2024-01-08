using Application;
using System.Text.Json.Serialization;
using Elkood.DependencyInjection;
using Elkood.API.Swagger;
using Autofac.Extensions.DependencyInjection;
using Infrastructure;
using StackExchange.Redis;
using Persistence;
using DeliveryProjectApi;
using Elkood.API.Middlewares.SeedMiddleware;
using Elkood.Identity.Middlewares.ElIdentityMiddleware;
using Persistence.Seed;

var builder = WebApplication.CreateBuilder(args);


builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());


builder.Services.AddControllers().AddJsonOptions(o =>
{
    o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    o.JsonSerializerOptions.WriteIndented = true;
    o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSingleton<IConnectionMultiplexer>(provider =>
{
    var options =
        ConfigurationOptions.Parse(builder.Environment.IsDevelopment()
            ? "localhost"
            : "localhost:6380,password=testredis");
    options.ConnectRetry = 5;
    options.AllowAdmin = true;
    options.ClientName = "Delivery";
    options.AbortOnConnectFail = false;
    return ConnectionMultiplexer.Connect(options);
});

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Environment.IsDevelopment() ? "localhost" : "localhost:6380,password=testredis";
    options.InstanceName = "Delivery";
});


builder.Services
    .AddInfrastructure(builder.Configuration)
    .AddPersistence(builder.Configuration, builder.Environment)
    .AddElkood(
        Application.AssemblyReference.Assembly,
        Persistence.AssemblyReference.Assembly,
        Infrastructure.AssemblyReference.Assembly
    );


/*builder.Services.AddDbContext<ApplicationDbContext>(o =>
        o.UseNpgsql(builder.Configuration.GetConnectionString("MyConnection"), b => b.MigrationsAssembly("DeliveryProjectApi"))
    );
*/
//builder.Services.AddMediatR(o => o.RegisterServicesFromAssemblies(typeof(Program).Assembly));
builder.Services.AddApplication();
builder.Services.AddElSawgger(builder.Environment)
    .AddApiGroupNames<ElApiGroupNames>(true)
    .AddLagHeader();


var app = builder.Build();

await app.CreateDbFunctions<ApplicationDbContext>();

//await app.MigrationAsync<ApplicationDbContext>(DataSeed.Seed, app.Environment.IsDevelopment());
// app.Use(async (context, next) =>
// {
//     context.Request.Body.Seek(0, SeekOrigin.Begin);
//
//     using (StreamReader stream = new StreamReader(context.Request.Body))
//     {
//         string body = stream.ReadToEnd();
//         // body = "param=somevalue&param2=someothervalue"
//         Console.WriteLine(body);
//     }
//
//     await next();
// });
app.UseElSawgger<ElApiGroupNames>();
app.UseCors(policyBuilder =>
{
    policyBuilder
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials()
        .SetIsOriginAllowed(_ => true);
});
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//app.UseElIdentity();
//app.UseEndpoints(endpoints =>
//   endpoints.MapControllers());

app.UseElIdentity();
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
//ElProtoBuf.Initial();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

public partial class Startup
{
}