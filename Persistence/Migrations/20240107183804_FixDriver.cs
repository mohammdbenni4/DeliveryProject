using System;
using System.Collections.Generic;
using Domain.Models;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixDriver : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MobileNumber",
                table: "Drivers");

            migrationBuilder.RenameColumn(
                name: "BornDate",
                table: "Drivers",
                newName: "BirthDate");

            migrationBuilder.AlterColumn<IReadOnlyCollection<ProductAddOne>>(
                name: "AddOnes",
                table: "Products",
                type: "jsonb",
                nullable: false,
                oldClrType: typeof(IReadOnlyCollection<ProductAddOne>),
                oldType: "jsonb",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BloodType",
                table: "Drivers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<List<string>>(
                name: "Documents",
                table: "Drivers",
                type: "jsonb",
                nullable: false);

            migrationBuilder.AddColumn<List<string>>(
                name: "MobileNumbers",
                table: "Drivers",
                type: "jsonb",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Drivers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<List<Dictionary<TimeOnly, TimeOnly>>>(
                name: "Times",
                table: "Drivers",
                type: "jsonb",
                nullable: false);

            migrationBuilder.AddColumn<List<string>>(
                name: "WorkingDays",
                table: "Drivers",
                type: "jsonb",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BloodType",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "Documents",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "MobileNumbers",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "Times",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "WorkingDays",
                table: "Drivers");

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "Drivers",
                newName: "BornDate");

            migrationBuilder.AlterColumn<IReadOnlyCollection<ProductAddOne>>(
                name: "AddOnes",
                table: "Products",
                type: "jsonb",
                nullable: true,
                oldClrType: typeof(IReadOnlyCollection<ProductAddOne>),
                oldType: "jsonb");

            migrationBuilder.AddColumn<string>(
                name: "MobileNumber",
                table: "Drivers",
                type: "text",
                nullable: true);
        }
    }
}
