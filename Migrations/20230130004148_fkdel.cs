using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClientManagement.Migrations
{
    /// <inheritdoc />
    public partial class fkdel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "InvoiceDetails");

            migrationBuilder.AddColumn<int>(
                name: "CustomerIdId",
                table: "InvoiceDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_CustomerIdId",
                table: "InvoiceDetails",
                column: "CustomerIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetails_Invoices_CustomerIdId",
                table: "InvoiceDetails",
                column: "CustomerIdId",
                principalTable: "Invoices",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetails_Invoices_CustomerIdId",
                table: "InvoiceDetails");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceDetails_CustomerIdId",
                table: "InvoiceDetails");

            migrationBuilder.DropColumn(
                name: "CustomerIdId",
                table: "InvoiceDetails");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "InvoiceDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
