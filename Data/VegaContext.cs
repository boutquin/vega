namespace Vega.Data
{
    using System;
    using System.Linq;

    using Microsoft.EntityFrameworkCore;
    public class VegaContext : DbContext
    {
        public VegaContext(DbContextOptions options)
            : base(options)
        {            
        }

        public DbSet<Make> Makes { get; set; }
        public DbSet<Feature> Features { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Create composite key for Join table
            modelBuilder.Entity<ModelFeature>()
                .ForSqlServerToTable("ModelFeatures", "vega");
            modelBuilder.Entity<ModelFeature>()
                .HasKey(mf => new { mf.ModelId, mf.FeatureId });

            modelBuilder.Entity<Feature>()
                .ForSqlServerToTable("Features", "vega");
            modelBuilder.Entity<Feature>()
                .HasAlternateKey(f => f.Name)
                .HasName("UX_Features_Name");

            modelBuilder.Entity<Make>()
                .ForSqlServerToTable("Makes", "vega");
            modelBuilder.Entity<Make>()
                .HasAlternateKey(m => m.Name)
                .HasName("UX_Makes_Name");

            modelBuilder.Entity<Model>()
                .ForSqlServerToTable("Models", "vega");
            modelBuilder.Entity<Model>()
                .HasAlternateKey(m => m.Name)
                .HasName("UX_Models_Name");

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                modelBuilder.Entity(entityType.Name).Property<DateTime>("LastModified");
                modelBuilder.Entity(entityType.Name).Ignore("WasModified");
            }
        }

        public override int SaveChanges()
        {
            foreach (var entry in this.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                         e.State == EntityState.Modified))
            {
                entry.Property("LastModified").CurrentValue = DateTime.Now;
            }

            return base.SaveChanges();
        }
    }
}