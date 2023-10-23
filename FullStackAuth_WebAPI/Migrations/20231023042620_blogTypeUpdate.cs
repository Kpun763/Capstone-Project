using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullStackAuth_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class blogTypeUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "BlogPosts",
                type: "longtext",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "BlogPosts");
        }
    }
}
