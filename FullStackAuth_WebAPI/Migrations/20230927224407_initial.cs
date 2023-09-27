using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FullStackAuth_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FriendsLists_AspNetUsers_User1Id1",
                table: "FriendsLists");

            migrationBuilder.DropForeignKey(
                name: "FK_FriendsLists_AspNetUsers_User2Id1",
                table: "FriendsLists");

            migrationBuilder.DropIndex(
                name: "IX_FriendsLists_User1Id1",
                table: "FriendsLists");

            migrationBuilder.DropIndex(
                name: "IX_FriendsLists_User2Id1",
                table: "FriendsLists");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e08b1c0-066d-4586-bf7c-6273c3aa6ec5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "780f240d-4c43-447c-a265-c2b158cc9e0f");

            migrationBuilder.DropColumn(
                name: "User1Id1",
                table: "FriendsLists");

            migrationBuilder.DropColumn(
                name: "User2Id1",
                table: "FriendsLists");

            migrationBuilder.AlterColumn<string>(
                name: "User2Id",
                table: "FriendsLists",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "User1Id",
                table: "FriendsLists",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ae1817ee-1771-4a3f-bb0b-cf17a0e80382", null, "Admin", "ADMIN" },
                    { "e4fe2e1f-af02-482d-8f02-ac4fe10fbc52", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FriendsLists_User1Id",
                table: "FriendsLists",
                column: "User1Id");

            migrationBuilder.CreateIndex(
                name: "IX_FriendsLists_User2Id",
                table: "FriendsLists",
                column: "User2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FriendsLists_AspNetUsers_User1Id",
                table: "FriendsLists",
                column: "User1Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FriendsLists_AspNetUsers_User2Id",
                table: "FriendsLists",
                column: "User2Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FriendsLists_AspNetUsers_User1Id",
                table: "FriendsLists");

            migrationBuilder.DropForeignKey(
                name: "FK_FriendsLists_AspNetUsers_User2Id",
                table: "FriendsLists");

            migrationBuilder.DropIndex(
                name: "IX_FriendsLists_User1Id",
                table: "FriendsLists");

            migrationBuilder.DropIndex(
                name: "IX_FriendsLists_User2Id",
                table: "FriendsLists");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae1817ee-1771-4a3f-bb0b-cf17a0e80382");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4fe2e1f-af02-482d-8f02-ac4fe10fbc52");

            migrationBuilder.AlterColumn<int>(
                name: "User2Id",
                table: "FriendsLists",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "User1Id",
                table: "FriendsLists",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "User1Id1",
                table: "FriendsLists",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "User2Id1",
                table: "FriendsLists",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1e08b1c0-066d-4586-bf7c-6273c3aa6ec5", null, "User", "USER" },
                    { "780f240d-4c43-447c-a265-c2b158cc9e0f", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FriendsLists_User1Id1",
                table: "FriendsLists",
                column: "User1Id1");

            migrationBuilder.CreateIndex(
                name: "IX_FriendsLists_User2Id1",
                table: "FriendsLists",
                column: "User2Id1");

            migrationBuilder.AddForeignKey(
                name: "FK_FriendsLists_AspNetUsers_User1Id1",
                table: "FriendsLists",
                column: "User1Id1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FriendsLists_AspNetUsers_User2Id1",
                table: "FriendsLists",
                column: "User2Id1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
