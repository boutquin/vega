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

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25);

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

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25);

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

                    b.Property<DateTime>("LastModified");

                    b.Property<int>("MakeId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25);

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

                    b.Property<DateTime>("LastModified");

                    b.HasKey("ModelId", "FeatureId");

                    b.HasIndex("FeatureId");

                    b.ToTable("ModelFeature");

                    b.HasAnnotation("SqlServer:Schema", "vega");

                    b.HasAnnotation("SqlServer:TableName", "ModelFeatures");
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
        }
    }
}