using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class pendingmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_Author_AuthorID",
                table: "books");

            migrationBuilder.DropForeignKey(
                name: "FK_books_Genre_GenreID",
                table: "books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_books",
                table: "books");

            migrationBuilder.RenameTable(
                name: "books",
                newName: "Books");

            migrationBuilder.RenameIndex(
                name: "IX_books_GenreID",
                table: "Books",
                newName: "IX_Books_GenreID");

            migrationBuilder.RenameIndex(
                name: "IX_books_AuthorID",
                table: "Books",
                newName: "IX_Books_AuthorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "BookID");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Author_AuthorID",
                table: "Books",
                column: "AuthorID",
                principalTable: "Author",
                principalColumn: "AuthorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Genre_GenreID",
                table: "Books",
                column: "GenreID",
                principalTable: "Genre",
                principalColumn: "GenreID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Author_AuthorID",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Genre_GenreID",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "books");

            migrationBuilder.RenameIndex(
                name: "IX_Books_GenreID",
                table: "books",
                newName: "IX_books_GenreID");

            migrationBuilder.RenameIndex(
                name: "IX_Books_AuthorID",
                table: "books",
                newName: "IX_books_AuthorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_books",
                table: "books",
                column: "BookID");

            migrationBuilder.AddForeignKey(
                name: "FK_books_Author_AuthorID",
                table: "books",
                column: "AuthorID",
                principalTable: "Author",
                principalColumn: "AuthorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_books_Genre_GenreID",
                table: "books",
                column: "GenreID",
                principalTable: "Genre",
                principalColumn: "GenreID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
