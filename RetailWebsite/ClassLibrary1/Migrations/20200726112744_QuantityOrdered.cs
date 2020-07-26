using Microsoft.EntityFrameworkCore.Migrations;

namespace CartDb.Migrations
{
    public partial class QuantityOrdered : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "CartSessionDetails",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "CartSessionDetails");
        }
    }
}
