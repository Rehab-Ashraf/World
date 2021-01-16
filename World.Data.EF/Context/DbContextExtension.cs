﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Linq;


namespace World.Data.EF.Context
{
    public static class DbContextExtension
    {
        public static bool AllMigrationsApplied( this DbContext context)
        {
            var applied = context.GetService<IHistoryRepository>()
                 .GetAppliedMigrations()
                 .Select(m => m.MigrationId);

            var total = context.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !total.Except(applied).Any();
        }

        public static void EnsureSeeded(this WorldDbContext context)
        {
            context.Database.Migrate();
        }
    }
}
