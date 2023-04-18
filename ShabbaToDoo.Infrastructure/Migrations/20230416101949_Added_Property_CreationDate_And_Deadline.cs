using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShabbaToDoo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Added_Property_CreationDate_And_Deadline : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Details",
                table: "TodoItems");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "TodoComments",
                newName: "CreationDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "Deadline",
                table: "TodoItems",
                type: "timestamp with time zone",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TodoItems",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsImportant",
                table: "TodoItems",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Projects",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deadline",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "IsImportant",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "TodoComments",
                newName: "CreatedAt");

            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "TodoItems",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
