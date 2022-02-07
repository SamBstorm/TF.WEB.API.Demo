using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionStockCore.DAL.Migrations
{
    public partial class CreateViewVOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"             
                CREATE VIEW VOrders AS 
                SELECT o.*, COALESCE(Total, 0) AS Total FROM( 
                    SELECT ol.orderRef, 
                        SUM(quantity * COALESCE(unitPrice, p.Price)) Total
                    FROM OrderLines ol
                    INNER JOIN Products p ON p.reference = ol.productRef
                    GROUP BY ol.orderRef) j
                RIGHT JOIN Orders o ON reference = j.orderRef
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW VOrders");
        }
    }
}
