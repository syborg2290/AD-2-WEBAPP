using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AD2_WEB_APP.Migrations
{
    /// <inheritdoc />
    public partial class configuration_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "ItemConfiguration");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "ItemConfiguration",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ItemConfiguration");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "ItemConfiguration",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
