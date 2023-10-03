using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FullStackAuth_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FriendsLists_AspNetUsers_User1Id",
                table: "FriendsLists");

            migrationBuilder.DropForeignKey(
                name: "FK_FriendsLists_AspNetUsers_User2Id",
                table: "FriendsLists");

            migrationBuilder.DropForeignKey(
                name: "FK_UserContents_FriendsLists_FriendsListId",
                table: "UserContents");

            migrationBuilder.DropForeignKey(
                name: "FK_UserHomepages_UserContents_UserName",
                table: "UserHomepages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FriendsLists",
                table: "FriendsLists");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7765cda9-3826-4529-b3ba-d8dbc0606ef3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5b1c094-772f-4e83-948b-416b7cdc1c08");

            migrationBuilder.RenameTable(
                name: "FriendsLists",
                newName: "FriendsList");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "UserHomepages",
                newName: "UserContentId");

            migrationBuilder.RenameIndex(
                name: "IX_UserHomepages_UserName",
                table: "UserHomepages",
                newName: "IX_UserHomepages_UserContentId");

            migrationBuilder.RenameIndex(
                name: "IX_FriendsLists_User2Id",
                table: "FriendsList",
                newName: "IX_FriendsList_User2Id");

            migrationBuilder.RenameIndex(
                name: "IX_FriendsLists_User1Id",
                table: "FriendsList",
                newName: "IX_FriendsList_User1Id");

            migrationBuilder.AddColumn<string>(
                name: "ContentText",
                table: "UserContents",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "UserContents",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FriendsList",
                table: "FriendsList",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "115887dc-f80d-4415-9d82-058da97afcc2", null, "Admin", "ADMIN" },
                    { "5105d437-f280-4a03-9ce7-e9fef0d6bb2f", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_FriendsList_AspNetUsers_User1Id",
                table: "FriendsList",
                column: "User1Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FriendsList_AspNetUsers_User2Id",
                table: "FriendsList",
                column: "User2Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserContents_FriendsList_FriendsListId",
                table: "UserContents",
                column: "FriendsListId",
                principalTable: "FriendsList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserHomepages_UserContents_UserContentId",
                table: "UserHomepages",
                column: "UserContentId",
                principalTable: "UserContents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FriendsList_AspNetUsers_User1Id",
                table: "FriendsList");

            migrationBuilder.DropForeignKey(
                name: "FK_FriendsList_AspNetUsers_User2Id",
                table: "FriendsList");

            migrationBuilder.DropForeignKey(
                name: "FK_UserContents_FriendsList_FriendsListId",
                table: "UserContents");

            migrationBuilder.DropForeignKey(
                name: "FK_UserHomepages_UserContents_UserContentId",
                table: "UserHomepages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FriendsList",
                table: "FriendsList");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "115887dc-f80d-4415-9d82-058da97afcc2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5105d437-f280-4a03-9ce7-e9fef0d6bb2f");

            migrationBuilder.DropColumn(
                name: "ContentText",
                table: "UserContents");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "UserContents");

            migrationBuilder.RenameTable(
                name: "FriendsList",
                newName: "FriendsLists");

            migrationBuilder.RenameColumn(
                name: "UserContentId",
                table: "UserHomepages",
                newName: "UserName");

            migrationBuilder.RenameIndex(
                name: "IX_UserHomepages_UserContentId",
                table: "UserHomepages",
                newName: "IX_UserHomepages_UserName");

            migrationBuilder.RenameIndex(
                name: "IX_FriendsList_User2Id",
                table: "FriendsLists",
                newName: "IX_FriendsLists_User2Id");

            migrationBuilder.RenameIndex(
                name: "IX_FriendsList_User1Id",
                table: "FriendsLists",
                newName: "IX_FriendsLists_User1Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FriendsLists",
                table: "FriendsLists",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7765cda9-3826-4529-b3ba-d8dbc0606ef3", null, "User", "USER" },
                    { "f5b1c094-772f-4e83-948b-416b7cdc1c08", null, "Admin", "ADMIN" }
                });

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserContents_FriendsLists_FriendsListId",
                table: "UserContents",
                column: "FriendsListId",
                principalTable: "FriendsLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserHomepages_UserContents_UserName",
                table: "UserHomepages",
                column: "UserName",
                principalTable: "UserContents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
