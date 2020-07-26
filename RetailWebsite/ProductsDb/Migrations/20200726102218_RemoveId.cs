using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductsDb.Migrations
{
    public partial class RemoveId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Products_LinkedProductId",
                table: "ProductImages");

            migrationBuilder.DropIndex(
                name: "IX_ProductImages_LinkedProductId",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "LinkedProductId",
                table: "ProductImages");

            migrationBuilder.AlterColumn<decimal>(
                name: "Width",
                table: "Products",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<decimal>(
                name: "Height",
                table: "Products",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<decimal>(
                name: "Depth",
                table: "Products",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_LinkedToProductId",
                table: "ProductImages",
                column: "LinkedToProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Products_LinkedToProductId",
                table: "ProductImages",
                column: "LinkedToProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Products_LinkedToProductId",
                table: "ProductImages");

            migrationBuilder.DropIndex(
                name: "IX_ProductImages_LinkedToProductId",
                table: "ProductImages");

            migrationBuilder.AlterColumn<float>(
                name: "Width",
                table: "Products",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "Products",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<float>(
                name: "Height",
                table: "Products",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<float>(
                name: "Depth",
                table: "Products",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AddColumn<Guid>(
                name: "LinkedProductId",
                table: "ProductImages",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_LinkedProductId",
                table: "ProductImages",
                column: "LinkedProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Products_LinkedProductId",
                table: "ProductImages",
                column: "LinkedProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
