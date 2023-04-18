using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShabbaToDoo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Edit_Property_In_TodoItem_From_User_To_Author : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_AspNetUsers_UserId",
                table: "TodoItems");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "TodoItems",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_TodoItems_UserId",
                table: "TodoItems",
                newName: "IX_TodoItems_AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_AspNetUsers_AuthorId",
                table: "TodoItems",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_AspNetUsers_AuthorId",
                table: "TodoItems");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "TodoItems",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TodoItems_AuthorId",
                table: "TodoItems",
                newName: "IX_TodoItems_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_AspNetUsers_UserId",
                table: "TodoItems",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
