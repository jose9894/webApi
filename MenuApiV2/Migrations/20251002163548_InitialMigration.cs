using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MenuApiV2.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cook",
                columns: table => new
                {
                    C_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNr = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CPR = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cook__A9FDEC127251B792", x => x.C_ID);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    C_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNr = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PaymentOpt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__A9FDEC12938DD7D0", x => x.C_ID);
                });

            migrationBuilder.CreateTable(
                name: "Delivery_Cyclist",
                columns: table => new
                {
                    DC_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNr = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    BikeType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Delivery__46564CF923AA2834", x => x.DC_ID);
                });

            migrationBuilder.CreateTable(
                name: "Meal",
                columns: table => new
                {
                    M_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    QTY = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    TimeStart = table.Column<TimeOnly>(type: "time", nullable: false),
                    TimeEnd = table.Column<TimeOnly>(type: "time", nullable: false),
                    CookID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Meal__18B1A3178C6A276D", x => x.M_ID);
                    table.ForeignKey(
                        name: "FK__Meal__CookID__753864A1",
                        column: x => x.CookID,
                        principalTable: "Cook",
                        principalColumn: "C_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    O_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    O_DATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    C_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Order__5AAB0C183571FF88", x => x.O_ID);
                    table.ForeignKey(
                        name: "FK__Order__C_ID__7DCDAAA2",
                        column: x => x.C_ID,
                        principalTable: "Customer",
                        principalColumn: "C_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order_Details",
                columns: table => new
                {
                    O_ID = table.Column<int>(type: "int", nullable: false),
                    M_ID = table.Column<int>(type: "int", nullable: false),
                    QTY = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Order_De__3B201629AE535250", x => new { x.O_ID, x.M_ID });
                    table.ForeignKey(
                        name: "FK__Order_Deta__M_ID__019E3B86",
                        column: x => x.M_ID,
                        principalTable: "Meal",
                        principalColumn: "M_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Order_Deta__O_ID__00AA174D",
                        column: x => x.O_ID,
                        principalTable: "Order",
                        principalColumn: "O_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    R_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    C_ID = table.Column<int>(type: "int", nullable: false),
                    CookID = table.Column<int>(type: "int", nullable: true),
                    DC_ID = table.Column<int>(type: "int", nullable: true),
                    O_ID = table.Column<int>(type: "int", nullable: false),
                    C_STARS = table.Column<int>(type: "int", nullable: true),
                    DC_STARS = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Rating__DE152E8970A20A71", x => x.R_ID);
                    table.ForeignKey(
                        name: "FK__Rating__C_ID__0EF836A4",
                        column: x => x.C_ID,
                        principalTable: "Customer",
                        principalColumn: "C_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Rating__CookID__0E04126B",
                        column: x => x.CookID,
                        principalTable: "Cook",
                        principalColumn: "C_ID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK__Rating__DC_ID__0FEC5ADD",
                        column: x => x.DC_ID,
                        principalTable: "Delivery_Cyclist",
                        principalColumn: "DC_ID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK__Rating__O_ID__10E07F16",
                        column: x => x.O_ID,
                        principalTable: "Order",
                        principalColumn: "O_ID");
                });

            migrationBuilder.CreateTable(
                name: "Trip",
                columns: table => new
                {
                    T_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TripPay = table.Column<int>(type: "int", nullable: false),
                    DC_ID = table.Column<int>(type: "int", nullable: false),
                    O_ID = table.Column<int>(type: "int", nullable: false),
                    T_Time = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Trip__83BB1FB2666AB6D8", x => x.T_ID);
                    table.ForeignKey(
                        name: "FK__Trip__DC_ID__056ECC6A",
                        column: x => x.DC_ID,
                        principalTable: "Delivery_Cyclist",
                        principalColumn: "DC_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Trip__O_ID__047AA831",
                        column: x => x.O_ID,
                        principalTable: "Order",
                        principalColumn: "O_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trip_Details",
                columns: table => new
                {
                    T_ID = table.Column<int>(type: "int", nullable: false),
                    Time_Stamp = table.Column<TimeOnly>(type: "time", nullable: false),
                    TripType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Trip_Det__3881C38E1EBAD5DF", x => new { x.T_ID, x.Time_Stamp });
                    table.ForeignKey(
                        name: "FK__Trip_Detai__T_ID__084B3915",
                        column: x => x.T_ID,
                        principalTable: "Trip",
                        principalColumn: "T_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meal_CookID",
                table: "Meal",
                column: "CookID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_C_ID",
                table: "Order",
                column: "C_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Details_M_ID",
                table: "Order_Details",
                column: "M_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_C_ID",
                table: "Rating",
                column: "C_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_CookID",
                table: "Rating",
                column: "CookID");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_DC_ID",
                table: "Rating",
                column: "DC_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_O_ID",
                table: "Rating",
                column: "O_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Trip_DC_ID",
                table: "Trip",
                column: "DC_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Trip_O_ID",
                table: "Trip",
                column: "O_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order_Details");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "Trip_Details");

            migrationBuilder.DropTable(
                name: "Meal");

            migrationBuilder.DropTable(
                name: "Trip");

            migrationBuilder.DropTable(
                name: "Cook");

            migrationBuilder.DropTable(
                name: "Delivery_Cyclist");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
