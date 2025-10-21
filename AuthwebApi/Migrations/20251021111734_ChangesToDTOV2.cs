using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthwebApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangesToDTOV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ActiveStatus",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepositLimit",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserNum",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActiveStatus",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DepositLimit",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserNum",
                table: "AspNetUsers");
        }
    }
}
