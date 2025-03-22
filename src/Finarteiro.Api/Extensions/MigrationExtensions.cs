﻿using Finarteiro.Api.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Finarteiro.Api.Extensions;

public static class MigrationExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        using AppDbContext dbContext = 
            scope.ServiceProvider.GetRequiredService<AppDbContext>();

        dbContext.Database.Migrate();
    }
}
