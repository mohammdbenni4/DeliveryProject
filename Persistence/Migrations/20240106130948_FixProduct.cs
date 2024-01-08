using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_Products_ProductId",
                table: "ProductCategories");

            migrationBuilder.DropIndex(
                name: "IX_ProductCategories_ProductId",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductCategories");

            migrationBuilder.AddColumn<Guid>(
                name: "productCategoryId",
                table: "Products",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<List<Guid>>(
                name: "ProductIds",
                table: "ProductCategories",
                type: "jsonb",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_productCategoryId",
                table: "Products",
                column: "productCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_productCategoryId",
                table: "Products",
                column: "productCategoryId",
                principalTable: "ProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_productCategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_productCategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "productCategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductIds",
                table: "ProductCategories");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "ProductCategories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_ProductId",
                table: "ProductCategories",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_Products_ProductId",
                table: "ProductCategories",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
