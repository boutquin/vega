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
                    context.Makes.AddRange(
                        new Make
                            {
                                Name = "Make 1",
                                Models = new List<Data.Model>
                                    {
                                        new Data.Model { Name = "Make1-ModelA" },
                                        new Data.Model { Name = "Make1-ModelB" },
                                        new Data.Model { Name = "Make1-ModelC" }
                                    }
                            },
                        new Make
                            {
                                Name = "Make 2",
                                Models = new List<Data.Model>
                                    {
                                        new Data.Model { Name = "Make2-ModelA" },
                                        new Data.Model { Name = "Make2-ModelB" },
                                        new Data.Model { Name = "Make2-ModelC" }
                                    }
                            },
                        new Make
                            {
                                Name = "Make 3",
                                Models = new List<Data.Model>
                                    {
                                        new Data.Model { Name = "Make3-ModelA" },
                                        new Data.Model { Name = "Make3-ModelB" },
                                        new Data.Model { Name = "Make3-ModelC" }
                                    }
                            }
                    );

                    context.SaveChanges();
                }

                if (!context.Features.Any())
                {
                    context.Features.AddRange(
                            new Feature { Name = "Feature 1" }, 
                            new Feature { Name = "Feature 2" },
                            new Feature { Name = "Feature 3" },
                            new Feature { Name = "Feature 4" },
                            new Feature { Name = "Feature 5" },
                            new Feature { Name = "Feature 6" },
                            new Feature { Name = "Feature 7" }
                        );

                    context.SaveChanges();
                }

                if (!context.Set<ModelFeature>().Any())
                {
                    AddFeatureToModel(context, "Make1-ModelA", "Feature 1");
                    AddFeatureToModel(context, "Make1-ModelA", "Feature 2");
                    AddFeatureToModel(context, "Make1-ModelA", "Feature 3");

                    AddFeatureToModel(context, "Make1-ModelB", "Feature 4");
                    AddFeatureToModel(context, "Make1-ModelB", "Feature 5");
                    AddFeatureToModel(context, "Make1-ModelB", "Feature 6");

                    AddFeatureToModel(context, "Make1-ModelC", "Feature 7");
                    AddFeatureToModel(context, "Make1-ModelC", "Feature 1");
                    AddFeatureToModel(context, "Make1-ModelC", "Feature 2");

                    AddFeatureToModel(context, "Make2-ModelA", "Feature 3");
                    AddFeatureToModel(context, "Make2-ModelA", "Feature 4");
                    AddFeatureToModel(context, "Make2-ModelA", "Feature 5");

                    AddFeatureToModel(context, "Make2-ModelB", "Feature 6");
                    AddFeatureToModel(context, "Make2-ModelB", "Feature 7");
                    AddFeatureToModel(context, "Make2-ModelB", "Feature 1");

                    AddFeatureToModel(context, "Make2-ModelC", "Feature 2");
                    AddFeatureToModel(context, "Make2-ModelC", "Feature 3");
                    AddFeatureToModel(context, "Make2-ModelC", "Feature 4");

                    AddFeatureToModel(context, "Make3-ModelA", "Feature 5");
                    AddFeatureToModel(context, "Make3-ModelA", "Feature 6");
                    AddFeatureToModel(context, "Make3-ModelA", "Feature 7");

                    AddFeatureToModel(context, "Make3-ModelB", "Feature 1");
                    AddFeatureToModel(context, "Make3-ModelB", "Feature 2");
                    AddFeatureToModel(context, "Make3-ModelB", "Feature 3");

                    AddFeatureToModel(context, "Make3-ModelC", "Feature 4");
                    AddFeatureToModel(context, "Make3-ModelC", "Feature 5");
                    AddFeatureToModel(context, "Make3-ModelC", "Feature 6");
                }
            }            
        }

        private static void AddFeatureToModel(VegaContext context, string modelName, string featureName)
        {
            var feature = context.Features.FirstOrDefault(
                f => f.Name.ToLowerInvariant() == featureName.ToLowerInvariant());
            var model = context.Set<Data.Model>()
                .FirstOrDefault(m => m.Name.ToLowerInvariant() == modelName.ToLowerInvariant());

            if (feature != null && model != null)
            {
                context.Set<ModelFeature>().Add(new ModelFeature
                    {
                        ModelId = model.Id,
                        FeatureId = feature.Id
                    }
                );

                context.SaveChanges();
            }
        }
    }
}