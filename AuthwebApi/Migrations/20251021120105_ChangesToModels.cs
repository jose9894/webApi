using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthwebApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangesToModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActiveStatus",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserNum",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "DepositLimit",
                table: "AspNetUsers",
                newName: "UserAccountId");

            migrationBuilder.CreateTable(
                name: "UserAccounts",
                columns: table => new
                {
                    UserAccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    DepositLimit = table.Column<int>(type: "int", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccounts", x => x.UserAccountId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserAccountId",
                table: "AspNetUsers",
                column: "UserAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserAccounts_UserAccountId",
                table: "AspNetUsers",
                column: "UserAccountId",
                principalTable: "UserAccounts",
                principalColumn: "UserAccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserAccounts_UserAccountId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "UserAccounts");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserAccountId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "UserAccountId",
                table: "AspNetUsers",
                newName: "DepositLimit");

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
                name: "UserNum",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");
        }
    }
}
