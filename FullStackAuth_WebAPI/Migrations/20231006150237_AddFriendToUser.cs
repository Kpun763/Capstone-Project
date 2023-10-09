using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FullStackAuth_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddFriendToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7bfc8432-f320-4064-93bb-39affb42c90a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c098f007-fc6b-49bc-aa3a-502bf12db325");

            migrationBuilder.AddColumn<string>(
                name: "FriendId",
                table: "AspNetUsers",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FriendId",
                table: "AspNetUsers",
                column: "FriendId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_FriendId",
                table: "AspNetUsers",
                column: "FriendId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_FriendId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FriendId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FriendId",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7bfc8432-f320-4064-93bb-39affb42c90a", null, "Admin", "ADMIN" },
                    { "c098f007-fc6b-49bc-aa3a-502bf12db325", null, "User", "USER" }
                });
        }
    }
}
