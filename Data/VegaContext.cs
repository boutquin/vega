namespace Vega.Data
{
    using System;
    using System.Linq;

    using Microsoft.EntityFrameworkCore;
    public class VegaContext : DbContext
    {
        private const string CreatedOnPropName = "CreatedOn";
        private const string UpdatedOnPropName = "UpdatedOn";

        public VegaContext(DbContextOptions options)
            : base(options)
        {            
        }

        public DbSet<Make> Makes { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Create composite key for ModelFeature Join table
            modelBuilder.Entity<ModelFeature>()
                .ForSqlServerToTable("ModelFeatures", "vega");
            modelBuilder.Entity<ModelFeature>()
                .HasKey(mf => new { mf.ModelId, mf.FeatureId });

            // Create composite key for VehicleFeature Join table
            modelBuilder.Entity<VehicleFeature>()
                .ForSqlServerToTable("VehicleFeatures", "vega");
            modelBuilder.Entity<VehicleFeature>()
                .HasKey(vf => new { vf.VehicleId, vf.FeatureId });

            modelBuilder.Entity<Feature>()
                .ForSqlServerToTable("Features", "vega");
            modelBuilder.Entity<Feature>()
                .Property(f => f.Name)
                .IsRequired()
                .HasMaxLength(25);
            modelBuilder.Entity<Feature>()
                .HasAlternateKey(f => f.Name)
                .HasName("UX_Features_Name");

            modelBuilder.Entity<Make>()
                .ForSqlServerToTable("Makes", "vega");
            modelBuilder.Entity<Make>()
                .Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(25);
            modelBuilder.Entity<Make>()
                .HasAlternateKey(m => m.Name)
                .HasName("UX_Makes_Name");

            modelBuilder.Entity<Model>()
                .ForSqlServerToTable("Models", "vega");
            modelBuilder.Entity<Model>()
                .Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(25);
            modelBuilder.Entity<Model>()
                .HasAlternateKey(m => m.Name)
                .HasName("UX_Models_Name");

            modelBuilder.Entity<Vehicle>()
                .ForSqlServerToTable("Vehicles", "vega");
            modelBuilder.Entity<Vehicle>()
                .Property(v => v.Name)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Vehicle>()
                .Property(v => v.ContactName)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Vehicle>()
                .Property(v => v.ContactPhone)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Vehicle>()
                .Property(v => v.ContactEMail)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Vehicle>()
                .HasAlternateKey(v => v.Name)
                .HasName("UX_Vehicles_Name");

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                modelBuilder.Entity(entityType.Name)
                    .Property<DateTime>(CreatedOnPropName)
                    .IsRequired();
                modelBuilder.Entity(entityType.Name)
                    .Property<DateTime>(UpdatedOnPropName);
                modelBuilder.Entity(entityType.Name)
                    .Ignore(nameof(SelfTracking.WasModified));
            }
        }

        public override int SaveChanges()
        {
            foreach (var entry in this.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added))
            {                
                entry.Property(CreatedOnPropName).CurrentValue = DateTime.Now;
                entry.Property(UpdatedOnPropName).CurrentValue = entry.Property(CreatedOnPropName).CurrentValue;
            }

            foreach (var entry in this.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Modified))
            {
                entry.Property(UpdatedOnPropName).CurrentValue = DateTime.Now;
            }

            return base.SaveChanges();
        }
    }
}