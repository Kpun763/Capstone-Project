using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FullStackAuth_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddBlogPosts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "115887dc-f80d-4415-9d82-058da97afcc2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5105d437-f280-4a03-9ce7-e9fef0d6bb2f");

            migrationBuilder.AddColumn<int>(
                name: "UserHomepageId",
                table: "Reviews",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserHomepageId",
                table: "Galleries",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BlogPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false),
                    Content = table.Column<string>(type: "longtext", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: true),
                    UserHomepageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogPosts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BlogPosts_UserHomepages_UserHomepageId",
                        column: x => x.UserHomepageId,
                        principalTable: "UserHomepages",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "36209f97-af73-4d4d-bd76-07f1f09924df", null, "User", "USER" },
                    { "ca47c5e1-8f98-463a-9c69-ce24f543af90", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserHomepageId",
                table: "Reviews",
                column: "UserHomepageId");

            migrationBuilder.CreateIndex(
                name: "IX_Galleries_UserHomepageId",
                table: "Galleries",
                column: "UserHomepageId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_UserHomepageId",
                table: "BlogPosts",
                column: "UserHomepageId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_UserId",
                table: "BlogPosts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Galleries_UserHomepages_UserHomepageId",
                table: "Galleries",
                column: "UserHomepageId",
                principalTable: "UserHomepages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_UserHomepages_UserHomepageId",
                table: "Reviews",
                column: "UserHomepageId",
                principalTable: "UserHomepages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Galleries_UserHomepages_UserHomepageId",
                table: "Galleries");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_UserHomepages_UserHomepageId",
                table: "Reviews");

            migrationBuilder.DropTable(
                name: "BlogPosts");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_UserHomepageId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Galleries_UserHomepageId",
                table: "Galleries");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36209f97-af73-4d4d-bd76-07f1f09924df");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca47c5e1-8f98-463a-9c69-ce24f543af90");

            migrationBuilder.DropColumn(
                name: "UserHomepageId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "UserHomepageId",
                table: "Galleries");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "115887dc-f80d-4415-9d82-058da97afcc2", null, "Admin", "ADMIN" },
                    { "5105d437-f280-4a03-9ce7-e9fef0d6bb2f", null, "User", "USER" }
                });
        }
    }
}
