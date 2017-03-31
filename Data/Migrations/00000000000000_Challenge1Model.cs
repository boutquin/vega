namespace Vega.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;
    using Microsoft.EntityFrameworkCore.Metadata;

    public partial class Challenge1Model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "vega");

            migrationBuilder.CreateTable(
                name: "Features",
                schema: "vega",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LastModified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                    table.UniqueConstraint("UX_Features_Name", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Makes",
                schema: "vega",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LastModified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Makes", x => x.Id);
                    table.UniqueConstraint("UX_Makes_Name", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                schema: "vega",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LastModified = table.Column<DateTime>(nullable: false),
                    MakeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                    table.UniqueConstraint("UX_Models_Name", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Models_Makes_MakeId",
                        column: x => x.MakeId,
                        principalSchema: "vega",
                        principalTable: "Makes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModelFeatures",
                schema: "vega",
                columns: table => new
                {
                    ModelId = table.Column<int>(nullable: false),
                    FeatureId = table.Column<int>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelFeatures", x => new { x.ModelId, x.FeatureId });
                    table.ForeignKey(
                        name: "FK_ModelFeatures_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalSchema: "vega",
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModelFeatures_Models_ModelId",
                        column: x => x.ModelId,
                        principalSchema: "vega",
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Models_MakeId",
                schema: "vega",
                table: "Models",
                column: "MakeId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelFeatures_FeatureId",
                schema: "vega",
                table: "ModelFeatures",
                column: "FeatureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModelFeatures",
                schema: "vega");

            migrationBuilder.DropTable(
                name: "Features",
                schema: "vega");

            migrationBuilder.DropTable(
                name: "Models",
                schema: "vega");

            migrationBuilder.DropTable(
                name: "Makes",
                schema: "vega");
        }
    }
}
