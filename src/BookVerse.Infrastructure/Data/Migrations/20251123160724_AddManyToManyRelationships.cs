using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookVerse.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddManyToManyRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_CategoryId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_AuthorId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_CategoryId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Books",
                newName: "QuantityInStock");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ISBN",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BookAuthors",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthors", x => new { x.BookId, x.AuthorId });
                    table.ForeignKey(
                        name: "FK_BookAuthors_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAuthors_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookCategories",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCategories", x => new { x.BookId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_BookCategories_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4413), new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4417) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4423), new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4423) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4424), new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4425) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4426), new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4426) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4427), new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4428) });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "CreatedAtUtc", "CreatedBy", "FirstName", "LastName", "UpdatedAtUtc", "UpdatedBy" },
                values: new object[] { 6, new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4429), "System", "Leo", "Tolstoy", new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4429), "System" });

            migrationBuilder.InsertData(
                table: "BookAuthors",
                columns: new[] { "AuthorId", "BookId", "CreatedAtUtc" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4643) },
                    { 2, 2, new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4644) },
                    { 3, 3, new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4645) },
                    { 4, 4, new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4646) },
                    { 5, 5, new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4646) }
                });

            migrationBuilder.InsertData(
                table: "BookCategories",
                columns: new[] { "BookId", "CategoryId", "CreatedAtUtc" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4669) },
                    { 2, 2, new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4670) },
                    { 3, 3, new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4671) },
                    { 4, 3, new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4673) },
                    { 4, 4, new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4672) },
                    { 5, 5, new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4673) }
                });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4602), null, null, 0, new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4602) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4605), null, null, 0, new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4606) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4608), null, null, 0, new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4608) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4611), null, null, 0, new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4611) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4612), null, null, 0, new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4613) });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "CreatedAtUtc", "CreatedBy", "Description", "ISBN", "Price", "PublishDate", "QuantityInStock", "Title", "UpdatedAtUtc", "UpdatedBy" },
                values: new object[] { 6, new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4614), "System", null, null, 22.0m, new DateOnly(2025, 1, 1), 0, "Collaborative Novel", new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4615), "System" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4547), new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4547) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4551), new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4551) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4553), new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4553) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4554), new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4555) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4556), new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4556) });

            migrationBuilder.InsertData(
                table: "BookAuthors",
                columns: new[] { "AuthorId", "BookId", "CreatedAtUtc" },
                values: new object[,]
                {
                    { 2, 6, new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4647) },
                    { 3, 6, new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4648) }
                });

            migrationBuilder.InsertData(
                table: "BookCategories",
                columns: new[] { "BookId", "CategoryId", "CreatedAtUtc" },
                values: new object[,]
                {
                    { 6, 2, new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4674) },
                    { 6, 3, new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4675) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_AuthorId",
                table: "BookAuthors",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BookCategories_CategoryId",
                table: "BookCategories",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAuthors");

            migrationBuilder.DropTable(
                name: "BookCategories");

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ISBN",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "QuantityInStock",
                table: "Books",
                newName: "CategoryId");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(4957), new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(4960) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(4966), new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(4966) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(4968), new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(4968) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(4969), new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(4970) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(4971), new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(4971) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AuthorId", "CategoryId", "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { 1, 1, new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(5125), new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(5126) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AuthorId", "CategoryId", "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { 2, 2, new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(5130), new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(5130) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AuthorId", "CategoryId", "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { 3, 3, new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(5132), new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(5132) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AuthorId", "CategoryId", "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { 4, 4, new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(5135), new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(5135) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AuthorId", "CategoryId", "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { 5, 5, new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(5136), new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(5137) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(5171), new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(5172) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(5203), new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(5204) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(5205), new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(5206) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(5207), new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(5207) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(5208), new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(5209) });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_CategoryId",
                table: "Books",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
