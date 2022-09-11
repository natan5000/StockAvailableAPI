using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockAvailableAPI.Migrations
{
    public partial class operations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeOperationID",
                table: "typeOperations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "operations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codeBox = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    typeOperationID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_operations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_operations_typeOperations_typeOperationID",
                        column: x => x.typeOperationID,
                        principalTable: "typeOperations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_typeOperations_TypeOperationID",
                table: "typeOperations",
                column: "TypeOperationID");

            migrationBuilder.CreateIndex(
                name: "IX_operations_typeOperationID",
                table: "operations",
                column: "typeOperationID");

            migrationBuilder.AddForeignKey(
                name: "FK_typeOperations_typeOperations_TypeOperationID",
                table: "typeOperations",
                column: "TypeOperationID",
                principalTable: "typeOperations",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_typeOperations_typeOperations_TypeOperationID",
                table: "typeOperations");

            migrationBuilder.DropTable(
                name: "operations");

            migrationBuilder.DropIndex(
                name: "IX_typeOperations_TypeOperationID",
                table: "typeOperations");

            migrationBuilder.DropColumn(
                name: "TypeOperationID",
                table: "typeOperations");
        }
    }
}
