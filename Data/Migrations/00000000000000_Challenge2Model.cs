namespace Vega.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;
    using Microsoft.EntityFrameworkCore.Metadata;

    public partial class Challenge2Model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastModified",
                schema: "vega",
                table: "ModelFeatures",
                newName: "UpdatedOn");

            migrationBuilder.RenameColumn(
                name: "LastModified",
                schema: "vega",
                table: "Models",
                newName: "UpdatedOn");

            migrationBuilder.RenameColumn(
                name: "LastModified",
                schema: "vega",
                table: "Makes",
                newName: "UpdatedOn");

            migrationBuilder.RenameColumn(
                name: "LastModified",
                schema: "vega",
                table: "Features",
                newName: "UpdatedOn");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                schema: "vega",
                table: "ModelFeatures",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                schema: "vega",
                table: "Models",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                schema: "vega",
                table: "Makes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                schema: "vega",
                table: "Features",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Vehicles",
                schema: "vega",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContactEMail = table.Column<string>(maxLength: 50, nullable: false),
                    ContactName = table.Column<string>(maxLength: 50, nullable: false),
                    ContactPhone = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    IsRegistered = table.Column<bool>(nullable: false),
                    ModelId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.UniqueConstraint("UX_Vehicles_Name", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Vehicles_Models_ModelId",
                        column: x => x.ModelId,
                        principalSchema: "vega",
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleFeatures",
                schema: "vega",
                columns: table => new
                {
                    VehicleId = table.Column<int>(nullable: false),
                    FeatureId = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleFeatures", x => new { x.VehicleId, x.FeatureId });
                    table.ForeignKey(
                        name: "FK_VehicleFeatures_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalSchema: "vega",
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleFeatures_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalSchema: "vega",
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ModelId",
                schema: "vega",
                table: "Vehicles",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleFeatures_FeatureId",
                schema: "vega",
                table: "VehicleFeatures",
                column: "FeatureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleFeatures",
                schema: "vega");

            migrationBuilder.DropTable(
                name: "Vehicles",
                schema: "vega");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                schema: "vega",
                table: "ModelFeatures");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                schema: "vega",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                schema: "vega",
                table: "Makes");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                schema: "vega",
                table: "Features");

            migrationBuilder.RenameColumn(
                name: "UpdatedOn",
                schema: "vega",
                table: "ModelFeatures",
                newName: "LastModified");

            migrationBuilder.RenameColumn(
                name: "UpdatedOn",
                schema: "vega",
                table: "Models",
                newName: "LastModified");

            migrationBuilder.RenameColumn(
                name: "UpdatedOn",
                schema: "vega",
                table: "Makes",
                newName: "LastModified");

            migrationBuilder.RenameColumn(
                name: "UpdatedOn",
                schema: "vega",
                table: "Features",
                newName: "LastModified");
        }
    }
}
