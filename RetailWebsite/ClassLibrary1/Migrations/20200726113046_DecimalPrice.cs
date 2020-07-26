using Microsoft.EntityFrameworkCore.Migrations;

namespace CartDb.Migrations
{
    public partial class DecimalPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "CartSessionDetails",
                nullable: false,
                oldClrType: typeof(float));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "CartSessionDetails",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
