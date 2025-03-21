using Finarteiro.Api.Features.Customers;
using Finarteiro.Api.Features.Customers.Create;
using Finarteiro.Api.Infrastructure;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidatorsFromAssemblyContaining(typeof(CreateCustomerCommandValidator));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(cfg =>
    cfg.UseNpgsql(connectionString)
        .UseSnakeCaseNamingConvention());

var assembly = typeof(Program).Assembly;
builder.Services.AddMediatR(configuration =>
    configuration.RegisterServicesFromAssembly(assembly));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Finarteiro API",
        Description = "An ASP.NET Core Web API for managing a small craft bussiness",
        Contact = new OpenApiContact
        {
            Name = "Pablo Souza",
            Email = "contato@souzapablo.dev.br",
            Url = new Uri("https://souzapablo.devd.br")
        }
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.MapCustomerEndpoints();

app.Run();
