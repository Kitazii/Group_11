using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class secondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_stock_StockId",
                table: "comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_comments",
                table: "comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_stock",
                table: "stock");

            migrationBuilder.RenameTable(
                name: "comments",
                newName: "Comments");

            migrationBuilder.RenameTable(
                name: "stock",
                newName: "Stocks");

            migrationBuilder.RenameIndex(
                name: "IX_comments_StockId",
                table: "Comments",
                newName: "IX_Comments_StockId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stocks",
                table: "Stocks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Stocks_StockId",
                table: "Comments",
                column: "StockId",
                principalTable: "Stocks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Stocks_StockId",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stocks",
                table: "Stocks");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "comments");

            migrationBuilder.RenameTable(
                name: "Stocks",
                newName: "stock");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_StockId",
                table: "comments",
                newName: "IX_comments_StockId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_comments",
                table: "comments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_stock",
                table: "stock",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_comments_stock_StockId",
                table: "comments",
                column: "StockId",
                principalTable: "stock",
                principalColumn: "Id");
        }
    }
}
