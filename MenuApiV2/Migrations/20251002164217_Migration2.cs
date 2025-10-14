using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MenuApiV2.Migrations
{
    /// <inheritdoc />
    public partial class Migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CPR",
                table: "Cook");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CPR",
                table: "Cook",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");
        }
    }
}
