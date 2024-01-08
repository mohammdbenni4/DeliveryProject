using System;
using System.Collections.Generic;
using Elkood.Domain.Primitives;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<LanguageProperty>(
                name: "Address",
                table: "AspNetUsers",
                type: "jsonb",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Customer_CityId",
                table: "AspNetUsers",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<LanguageProperty>(
                name: "Customer_Name",
                table: "AspNetUsers",
                type: "jsonb",
                nullable: true);

            migrationBuilder.AddColumn<List<string>>(
                name: "Documents",
                table: "AspNetUsers",
                type: "jsonb",
                nullable: true);

            migrationBuilder.AddColumn<List<string>>(
                name: "MobileNumbers",
                table: "AspNetUsers",
                type: "jsonb",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Customer_CityId",
                table: "AspNetUsers",
                column: "Customer_CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Cities_Customer_CityId",
                table: "AspNetUsers",
                column: "Customer_CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Cities_Customer_CityId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Customer_CityId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Customer_CityId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Customer_Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Documents",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MobileNumbers",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "AspNetUsers");
        }
    }
}
