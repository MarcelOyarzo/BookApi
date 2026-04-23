using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookApi.Migrations
{
    /// <inheritdoc />
    public partial class RemoveBookIdFromQuotes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quotes_Books_BookId",
                table: "Quotes");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "Quotes",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Quotes_BookId",
                table: "Quotes",
                newName: "IX_Quotes_UserId");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Quotes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Quotes_Users_UserId",
                table: "Quotes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quotes_Users_UserId",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "Author",
                table: "Quotes");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Quotes",
                newName: "BookId");

            migrationBuilder.RenameIndex(
                name: "IX_Quotes_UserId",
                table: "Quotes",
                newName: "IX_Quotes_BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quotes_Books_BookId",
                table: "Quotes",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
