using Elkood.Domain.Primitives;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixBrunchModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<LanguageProperty>(
                name: "Description",
                table: "Brunches",
                type: "jsonb",
                nullable: false);

            migrationBuilder.AddColumn<float>(
                name: "FeeValue",
                table: "Brunches",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<bool>(
                name: "IsFeePercentage",
                table: "Brunches",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MainImage",
                table: "Brunches",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Brunches");

            migrationBuilder.DropColumn(
                name: "FeeValue",
                table: "Brunches");

            migrationBuilder.DropColumn(
                name: "IsFeePercentage",
                table: "Brunches");

            migrationBuilder.DropColumn(
                name: "MainImage",
                table: "Brunches");
        }
    }
}
