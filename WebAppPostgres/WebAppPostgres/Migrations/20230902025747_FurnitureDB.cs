using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebAppPostgres.Migrations
{
    public partial class FurnitureDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Furniture",
                columns: table => new
                {
                    FurnitureId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FurnitureName = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    Brand = table.Column<string>(type: "text", nullable: true),
                    Cost = table.Column<decimal>(type: "numeric", nullable: false),
                    FurnitureTypeID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Furniture", x => x.FurnitureId);
                });

            migrationBuilder.CreateTable(
                name: "FurnitureType",
                columns: table => new
                {
                    FurnitureTypeID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FurnitureTypeName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FurnitureType", x => x.FurnitureTypeID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Furniture");

            migrationBuilder.DropTable(
                name: "FurnitureType");
        }
    }
}
