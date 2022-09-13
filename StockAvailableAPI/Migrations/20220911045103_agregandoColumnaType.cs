using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockAvailableAPI.Migrations
{
    public partial class agregandoColumnaType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "type",
                table: "typeOperations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "type",
                table: "typeOperations");
        }
    }
}
