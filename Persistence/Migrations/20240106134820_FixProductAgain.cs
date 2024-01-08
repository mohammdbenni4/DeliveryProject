using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixProductAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<List<Guid>>(
                name: "AddOnesIds",
                table: "Products",
                type: "jsonb",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MainImage",
                table: "Products",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddOnesIds",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MainImage",
                table: "Products");
        }
    }
}
