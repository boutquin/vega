namespace Vega
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    using Vega.Data;

    public static class DataSeeder
    {
        public static void SeedTables(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<VegaContext>();

                context.Database.Migrate();

                if (!context.Makes.Any())
                {
                    context.Makes.Add(new Make
                    {
                        Name = "Make 1",
                        Models = new List<Data.Model>
                            {
                                new Data.Model { Name = "Model1" },
                                new Data.Model { Name = "Model2" }
                            }
                    });

                    context.SaveChanges();
                }

                if (!context.Features.Any())
                {
                    context.Features.AddRange(
                        new Feature { Name = "Feature 1"}, 
                        new Feature { Name = "Feature 2"});

                    context.SaveChanges();
                }
            }
        }
    }
}