namespace Vega.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using Microsoft.EntityFrameworkCore.Metadata;

    [DbContext(typeof(VegaContext))]
    partial class VegaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Vega.Data.Feature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("Id");

                    b.HasAlternateKey("Name")
                        .HasName("UX_Features_Name");

                    b.ToTable("Features");

                    b.HasAnnotation("SqlServer:Schema", "vega");

                    b.HasAnnotation("SqlServer:TableName", "Features");
                });

            modelBuilder.Entity("Vega.Data.Make", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("Id");

                    b.HasAlternateKey("Name")
                        .HasName("UX_Makes_Name");

                    b.ToTable("Makes");

                    b.HasAnnotation("SqlServer:Schema", "vega");

                    b.HasAnnotation("SqlServer:TableName", "Makes");
                });

            modelBuilder.Entity("Vega.Data.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int>("MakeId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("Id");

                    b.HasAlternateKey("Name")
                        .HasName("UX_Models_Name");

                    b.HasIndex("MakeId");

                    b.ToTable("Model");

                    b.HasAnnotation("SqlServer:Schema", "vega");

                    b.HasAnnotation("SqlServer:TableName", "Models");
                });

            modelBuilder.Entity("Vega.Data.ModelFeature", b =>
                {
                    b.Property<int>("ModelId");

                    b.Property<int>("FeatureId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("ModelId", "FeatureId");

                    b.HasIndex("FeatureId");

                    b.ToTable("ModelFeature");

                    b.HasAnnotation("SqlServer:Schema", "vega");

                    b.HasAnnotation("SqlServer:TableName", "ModelFeatures");
                });

            modelBuilder.Entity("Vega.Data.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContactEMail")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("ContactPhone")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("IsRegistered");

                    b.Property<int>("ModelId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("Id");

                    b.HasAlternateKey("Name")
                        .HasName("UX_Vehicles_Name");

                    b.HasIndex("ModelId");

                    b.ToTable("Vehicles");

                    b.HasAnnotation("SqlServer:Schema", "vega");

                    b.HasAnnotation("SqlServer:TableName", "Vehicles");
                });

            modelBuilder.Entity("Vega.Data.VehicleFeature", b =>
                {
                    b.Property<int>("VehicleId");

                    b.Property<int>("FeatureId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("VehicleId", "FeatureId");

                    b.HasIndex("FeatureId");

                    b.ToTable("VehicleFeature");

                    b.HasAnnotation("SqlServer:Schema", "vega");

                    b.HasAnnotation("SqlServer:TableName", "VehicleFeatures");
                });

            modelBuilder.Entity("Vega.Data.Model", b =>
                {
                    b.HasOne("Vega.Data.Make", "Make")
                        .WithMany("Models")
                        .HasForeignKey("MakeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Vega.Data.ModelFeature", b =>
                {
                    b.HasOne("Vega.Data.Feature", "Feature")
                        .WithMany("ModelFeatures")
                        .HasForeignKey("FeatureId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Vega.Data.Model", "Model")
                        .WithMany("ModelFeatures")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Vega.Data.Vehicle", b =>
                {
                    b.HasOne("Vega.Data.Model", "Model")
                        .WithMany()
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Vega.Data.VehicleFeature", b =>
                {
                    b.HasOne("Vega.Data.Feature", "Feature")
                        .WithMany()
                        .HasForeignKey("FeatureId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Vega.Data.Vehicle", "Vehicle")
                        .WithMany("VehicleFeatures")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
