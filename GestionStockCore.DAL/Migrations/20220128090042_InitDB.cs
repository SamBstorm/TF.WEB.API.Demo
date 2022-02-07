using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionStockCore.DAL.Migrations
{
    public partial class InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    reference = table.Column<string>(type: "CHAR(8)", maxLength: 8, nullable: false),
                    lastName = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    firstName = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    phone = table.Column<string>(type: "VARCHAR(25)", maxLength: 25, nullable: true),
                    deleted = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.reference);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    reference = table.Column<string>(type: "CHAR(8)", maxLength: 8, nullable: false),
                    name = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "NVARCHAR(MAX)", nullable: true),
                    stock = table.Column<int>(type: "INT", nullable: false),
                    price = table.Column<decimal>(type: "MONEY", nullable: false),
                    deleted = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.reference);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    reference = table.Column<string>(type: "CHAR(10)", maxLength: 10, nullable: false),
                    updateDate = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    status = table.Column<int>(type: "INT", nullable: false),
                    customerRef = table.Column<string>(type: "CHAR(8)", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.reference);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_customerRef",
                        column: x => x.customerRef,
                        principalTable: "Customers",
                        principalColumn: "reference",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderLines",
                columns: table => new
                {
                    id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderRef = table.Column<string>(type: "CHAR(10)", maxLength: 10, nullable: false),
                    productRef = table.Column<string>(type: "CHAR(8)", maxLength: 8, nullable: false),
                    quantity = table.Column<int>(type: "INT", nullable: false),
                    unitPrice = table.Column<decimal>(type: "MONEY", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLines", x => x.id);
                    table.ForeignKey(
                        name: "FK_OrderLines_Orders_orderRef",
                        column: x => x.orderRef,
                        principalTable: "Orders",
                        principalColumn: "reference",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderLines_Products_productRef",
                        column: x => x.productRef,
                        principalTable: "Products",
                        principalColumn: "reference",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "reference", "deleted", "email", "firstName", "lastName", "phone" },
                values: new object[,]
                {
                    { "LYKH0001", false, "lykhun@gmail.com", "Khun", "Ly", null },
                    { "COJU0003", false, "jules@constant.be", "Jules", "Constant", null },
                    { "BALO0001", false, "loic.baudoux@bstorm.be", "Loïc", "Baudoux", null },
                    { "LAST0001", false, "steve.laurent@bstorm.be", "Steve", "Laurent", null },
                    { "OVFL0001", false, "flavian.ovyn@bstorm.be", "Flavian", "Ovyn", null },
                    { "STAU0001", false, "aurelien.strimelle@bstorm.be", "Aurélien", "Strimelle", null },
                    { "PEMI0002", false, "michel@pedro.be", "Michel", "Pedro", null },
                    { "COJU0001", false, "julien.coppin@bstorm.be", "Julien", "Coppin", null },
                    { "MOTH0001", false, "tierry.morre@cognitic.be", "Thierry", "Morre", null },
                    { "PEMI0001", false, "michael.person@cognitic.be", "Mike", "Person", null },
                    { "LYPI0001", false, "piv.ly@bstorm.be", "Piv", "Ly", null },
                    { "COJU0002", false, "julie@courtois.be", "Julie", "Courtois", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "reference", "deleted", "description", "name", "price", "stock" },
                values: new object[,]
                {
                    { "CHIM0001", false, "BOUT. 24X33cl", "Chimay Bleue 33cl", 45.6m, 1000 },
                    { "VITT0002", false, "BOUT. 24X50cl", "Vittel 50cl", 5.44m, 1000 },
                    { "VITT0001", false, "BOUT. 8X1l", "Vittel 1l", 8.72m, 1000 },
                    { "EVIA0002", false, "BOUT. 24X50cl", "Evian 50cl", 5.6m, 1000 },
                    { "EVIA0001", false, "BOUT. 8X1l", "Evian 1l", 8.96m, 1000 },
                    { "NALU0001", false, "CAN. 24X25cl", "Nalu Vert 25cl", 16.8m, 1000 },
                    { "CHIM0003", false, "BOUT. 24X33cl", "Chimay Blanche 33cl", 30.24m, 1000 },
                    { "CHIM0002", false, "BOUT. 24X33cl", "Chimay Rouge 33cl", 45.6m, 1000 },
                    { "CARL0001", false, "CAN. 24X33cl", "Carlsberg 33cl", 32.4m, 1000 },
                    { "FANT0001", false, "CAN. 24X33cl", "Fanta Orange 33cl", 16.8m, 1000 },
                    { "JUPI0001", false, "CAN. 24X33cl", "Jupiler 33cl", 29.04m, 1000 },
                    { "FANT0004", false, "CAN. 24X50cl", "Fanta Citron 50cl", 19.92m, 1000 },
                    { "FANT0003", false, "CAN. 24X50cl", "Fanta Orange 50cl", 16.8m, 1000 },
                    { "FANT0002", false, "CAN. 24X33cl", "Fanta Citron 33cl", 16.8m, 1000 },
                    { "OASI0001", false, "BOUT. 6X2l", "Oasis Orange 2l", 13.44m, 1000 },
                    { "COCA0003", false, "BOUT. 6X1l", "Coca Cola 1l", 10.92m, 1000 },
                    { "COCA0002", false, "CAN. 24X50cl", "Coca Cola 50cl", 19.92m, 1000 },
                    { "COCA0001", false, "CAN. 24X33cl", "Coca Cola 33cl", 16.8m, 1000 },
                    { "JUPI0002", false, "CAN. 24X50cl", "Jupiler 50cl", 35.52m, 1000 },
                    { "OASI0002", false, "BOUT. 6X2l", "Oasis Tropical 2l", 13.44m, 1000 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "reference", "customerRef", "status", "updateDate" },
                values: new object[,]
                {
                    { "2201310002", "PEMI0001", 3, new DateTime(2022, 1, 31, 0, 50, 0, 0, DateTimeKind.Unspecified) },
                    { "2201310001", "MOTH0001", 0, new DateTime(2022, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "2201310003", "COJU0001", 2, new DateTime(2022, 1, 31, 4, 2, 0, 0, DateTimeKind.Unspecified) },
                    { "2201310004", "COJU0001", 1, new DateTime(2022, 1, 31, 5, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "OrderLines",
                columns: new[] { "id", "orderRef", "productRef", "quantity", "unitPrice" },
                values: new object[,]
                {
                    { 2, "2201310002", "JUPI0001", 10, null },
                    { 1, "2201310001", "COCA0001", 50, null },
                    { 3, "2201310003", "COCA0002", 100, 19.92m },
                    { 4, "2201310004", "FANT0002", 25, 16.24m },
                    { 5, "2201310004", "COCA0001", 20, 16.24m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_email",
                table: "Customers",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_orderRef",
                table: "OrderLines",
                column: "orderRef");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_productRef",
                table: "OrderLines",
                column: "productRef");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_customerRef",
                table: "Orders",
                column: "customerRef");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderLines");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
