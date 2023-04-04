using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AD2_WEB_APP.Migrations
{
    /// <inheritdoc />
    public partial class Compare_price : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ComparePrice",
                table: "ItemConfiguration",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComparePrice",
                table: "ItemConfiguration");
        }
    }
}
