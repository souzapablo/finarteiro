using Finarteiro.Api.Features.Customers;
using Finarteiro.Api.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(cfg =>
    cfg.UseNpgsql(connectionString)
        .UseSnakeCaseNamingConvention());

var assembly = typeof(Program).Assembly;
builder.Services.AddMediatR(configuration =>
    configuration.RegisterServicesFromAssembly(assembly));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapCustomerEndpoints();

app.Run();
