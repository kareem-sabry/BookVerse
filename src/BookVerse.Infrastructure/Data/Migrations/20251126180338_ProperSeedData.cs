using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookVerse.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProperSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "FirstName", "LastName", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "Jane", "Austen", new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "FirstName", "LastName", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "Mark", "Twain", new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAtUtc", "FirstName", "LastName", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "Fyodor", "Dostoevsky", new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAtUtc", "FirstName", "LastName", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "Leo", "Tolstoy", new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAtUtc", "FirstName", "LastName", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "Charles", "Dickens", new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850) });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "CreatedAtUtc", "CreatedBy", "FirstName", "LastName", "UpdatedAtUtc", "UpdatedBy" },
                values: new object[,]
                {
                    { 7, new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System", "F. Scott", "Fitzgerald", new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System" },
                    { 8, new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System", "Herman", "Melville", new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System" },
                    { 9, new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System", "Emily", "Brontë", new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System" },
                    { 10, new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System", "Charlotte", "Brontë", new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System" },
                    { 11, new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System", "J.R.R.", "Tolkien", new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System" },
                    { 12, new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System", "J.K.", "Rowling", new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System" },
                    { 13, new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System", "Isaac", "Asimov", new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System" },
                    { 14, new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System", "Frank", "Herbert", new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System" },
                    { 15, new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System", "Douglas", "Adams", new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System" },
                    { 16, new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System", "C.S.", "Lewis", new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System" },
                    { 17, new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System", "Ray", "Bradbury", new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System" },
                    { 18, new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System", "Aldous", "Huxley", new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System" },
                    { 19, new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System", "Philip K.", "Dick", new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System" },
                    { 20, new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System", "Ursula K.", "Le Guin", new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System" },
                    { 21, new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System", "Gabriel García", "Márquez", new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System" },
                    { 22, new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System", "Haruki", "Murakami", new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System" },
                    { 23, new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System", "Toni", "Morrison", new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System" },
                    { 24, new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System", "Margaret", "Atwood", new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System" },
                    { 25, new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System", "Cormac", "McCarthy", new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System" },
                    { 26, new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System", "Kurt", "Vonnegut", new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System" },
                    { 27, new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System", "Stephen", "King", new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System" },
                    { 28, new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System", "Agatha", "Christie", new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System" },
                    { 29, new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System", "Arthur Conan", "Doyle", new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System" },
                    { 30, new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System", "Dan", "Brown", new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System" },
                    { 31, new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System", "Albert", "Camus", new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System" },
                    { 32, new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System", "Viktor", "Frankl", new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System" },
                    { 33, new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System", "Sun", "Tzu", new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System" },
                    { 34, new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System", "Ernest", "Hemingway", new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System" },
                    { 35, new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System", "Virginia", "Woolf", new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System" },
                    { 36, new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System", "Oscar", "Wilde", new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System" },
                    { 37, new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System", "William", "Golding", new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System" },
                    { 38, new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System", "John", "Steinbeck", new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System" },
                    { 39, new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System", "Harper", "Lee", new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System" },
                    { 40, new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System", "J.D.", "Salinger", new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), "System" }
                });

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.InsertData(
                table: "BookAuthors",
                columns: new[] { "AuthorId", "BookId", "CreatedAtUtc" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247) },
                    { 2, 3, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247) },
                    { 3, 4, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247) },
                    { 4, 5, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247) },
                    { 4, 6, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247) }
                });

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.InsertData(
                table: "BookCategories",
                columns: new[] { "BookId", "CategoryId", "CreatedAtUtc" },
                values: new object[,]
                {
                    { 1, 3, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 1, 4, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 2, 1, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 2, 4, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 3, 1, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 4, 1, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 4, 5, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 5, 1, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 6, 1, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) }
                });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "Price", "PublishDate", "Title", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), 12.99m, new DateOnly(1945, 8, 17), "Animal Farm", new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "Price", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), 11.99m, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAtUtc", "Price", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), 13.50m, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAtUtc", "Price", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), 16.75m, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAtUtc", "Price", "PublishDate", "Title", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), 18.99m, new DateOnly(1880, 1, 1), "The Brothers Karamazov", new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "CreatedAtUtc", "CreatedBy", "Description", "ISBN", "Price", "PublishDate", "QuantityInStock", "Title", "UpdatedAtUtc", "UpdatedBy" },
                values: new object[,]
                {
                    { 7, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System", null, null, 22.50m, new DateOnly(1869, 1, 1), 0, "War and Peace", new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System" },
                    { 8, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System", null, null, 17.99m, new DateOnly(1878, 1, 1), 0, "Anna Karenina", new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System" },
                    { 9, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System", null, null, 14.25m, new DateOnly(1861, 1, 1), 0, "Great Expectations", new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System" },
                    { 10, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System", null, null, 13.99m, new DateOnly(1859, 4, 30), 0, "A Tale of Two Cities", new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System" },
                    { 11, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System", null, null, 14.99m, new DateOnly(1925, 4, 10), 0, "The Great Gatsby", new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System" },
                    { 12, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System", null, null, 16.50m, new DateOnly(1851, 10, 18), 0, "Moby-Dick", new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System" },
                    { 13, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System", null, null, 12.75m, new DateOnly(1847, 12, 1), 0, "Wuthering Heights", new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System" },
                    { 14, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System", null, null, 13.50m, new DateOnly(1847, 10, 16), 0, "Jane Eyre", new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System" },
                    { 15, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System", null, null, 29.99m, new DateOnly(1954, 7, 29), 0, "The Lord of the Rings", new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System" },
                    { 16, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System", null, null, 18.99m, new DateOnly(1937, 9, 21), 0, "The Hobbit", new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System" },
                    { 17, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System", null, null, 19.99m, new DateOnly(1997, 6, 26), 0, "Harry Potter and the Philosopher's Stone", new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System" },
                    { 18, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System", null, null, 19.99m, new DateOnly(1998, 7, 2), 0, "Harry Potter and the Chamber of Secrets", new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System" },
                    { 19, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System", null, null, 24.99m, new DateOnly(1950, 10, 16), 0, "The Chronicles of Narnia", new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System" },
                    { 20, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System", null, null, 15.99m, new DateOnly(1951, 6, 1), 0, "Foundation", new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System" },
                    { 21, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System", null, null, 14.50m, new DateOnly(1950, 12, 2), 0, "I, Robot", new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System" },
                    { 22, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System", null, null, 21.99m, new DateOnly(1965, 8, 1), 0, "Dune", new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System" },
                    { 23, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System", null, null, 16.99m, new DateOnly(1979, 10, 12), 0, "The Hitchhiker's Guide to the Galaxy", new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System" },
                    { 24, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System", null, null, 14.99m, new DateOnly(1953, 10, 19), 0, "Fahrenheit 451", new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System" },
                    { 25, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System", null, null, 15.50m, new DateOnly(1932, 1, 1), 0, "Brave New World", new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System" },
                    { 26, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System", null, null, 14.99m, new DateOnly(1968, 1, 1), 0, "Do Androids Dream of Electric Sheep?", new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System" },
                    { 27, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System", null, null, 15.99m, new DateOnly(1969, 3, 1), 0, "The Left Hand of Darkness", new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System" },
                    { 28, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System", null, null, 17.99m, new DateOnly(1967, 5, 30), 0, "One Hundred Years of Solitude", new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System" },
                    { 29, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System", null, null, 16.50m, new DateOnly(1987, 9, 4), 0, "Norwegian Wood", new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System" },
                    { 30, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System", null, null, 17.25m, new DateOnly(2002, 9, 12), 0, "Kafka on the Shore", new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System" },
                    { 31, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System", null, null, 15.99m, new DateOnly(1987, 9, 1), 0, "Beloved", new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System" },
                    { 32, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System", null, null, 16.99m, new DateOnly(1985, 8, 1), 0, "The Handmaid's Tale", new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System" },
                    { 33, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System", null, null, 15.50m, new DateOnly(2006, 9, 26), 0, "The Road", new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System" },
                    { 34, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System", null, null, 14.99m, new DateOnly(1969, 3, 31), 0, "Slaughterhouse-Five", new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System" },
                    { 35, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System", null, null, 18.99m, new DateOnly(1977, 1, 28), 0, "The Shining", new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System" },
                    { 36, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System", null, null, 14.50m, new DateOnly(1934, 1, 1), 0, "Murder on the Orient Express", new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System" },
                    { 37, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System", null, null, 13.99m, new DateOnly(1939, 11, 6), 0, "And Then There Were None", new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System" },
                    { 38, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System", null, null, 12.99m, new DateOnly(1902, 4, 1), 0, "The Hound of the Baskervilles", new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System" },
                    { 39, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System", null, null, 16.99m, new DateOnly(2003, 3, 18), 0, "The Da Vinci Code", new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System" },
                    { 40, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System", null, null, 13.50m, new DateOnly(1942, 1, 1), 0, "The Stranger", new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System" },
                    { 41, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System", null, null, 14.99m, new DateOnly(1946, 1, 1), 0, "Man's Search for Meaning", new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System" },
                    { 42, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System", null, null, 11.99m, new DateOnly(1910, 1, 1), 0, "The Art of War", new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System" },
                    { 43, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System", null, null, 12.99m, new DateOnly(1952, 9, 1), 0, "The Old Man and the Sea", new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System" },
                    { 44, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System", null, null, 15.99m, new DateOnly(1940, 10, 21), 0, "For Whom the Bell Tolls", new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System" },
                    { 45, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System", null, null, 13.50m, new DateOnly(1925, 5, 14), 0, "Mrs Dalloway", new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System" },
                    { 46, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System", null, null, 12.99m, new DateOnly(1890, 7, 1), 0, "The Picture of Dorian Gray", new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System" },
                    { 47, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System", null, null, 13.99m, new DateOnly(1954, 9, 17), 0, "Lord of the Flies", new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System" },
                    { 48, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System", null, null, 11.99m, new DateOnly(1937, 2, 25), 0, "Of Mice and Men", new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System" },
                    { 49, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System", null, null, 14.99m, new DateOnly(1960, 7, 11), 0, "To Kill a Mockingbird", new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System" },
                    { 50, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System", null, null, 13.99m, new DateOnly(1951, 7, 16), 0, "The Catcher in the Rye", new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), "System" }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "Name", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993), "Classic Literature", new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993), new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "Name", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993), "Science Fiction", new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAtUtc", "Name", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993), "Dystopian", new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAtUtc", "Name", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993), "Adventure", new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAtUtc", "CreatedBy", "Name", "UpdatedAtUtc", "UpdatedBy" },
                values: new object[,]
                {
                    { 6, new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993), "System", "Mystery", new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993), "System" },
                    { 7, new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993), "System", "Thriller", new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993), "System" },
                    { 8, new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993), "System", "Romance", new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993), "System" },
                    { 9, new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993), "System", "Historical Fiction", new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993), "System" },
                    { 10, new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993), "System", "Philosophy", new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993), "System" },
                    { 11, new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993), "System", "Horror", new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993), "System" },
                    { 12, new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993), "System", "Coming of Age", new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993), "System" },
                    { 13, new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993), "System", "Literary Fiction", new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993), "System" },
                    { 14, new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993), "System", "Psychological Fiction", new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993), "System" },
                    { 15, new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993), "System", "Magical Realism", new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993), "System" }
                });

            migrationBuilder.InsertData(
                table: "BookAuthors",
                columns: new[] { "AuthorId", "BookId", "CreatedAtUtc" },
                values: new object[,]
                {
                    { 5, 7, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247) },
                    { 5, 8, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247) },
                    { 6, 9, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247) },
                    { 6, 10, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247) },
                    { 7, 11, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247) },
                    { 8, 12, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247) },
                    { 9, 13, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247) },
                    { 10, 14, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247) },
                    { 11, 15, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247) },
                    { 11, 16, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247) },
                    { 12, 17, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247) },
                    { 12, 18, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247) },
                    { 16, 19, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247) },
                    { 13, 20, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247) },
                    { 13, 21, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247) },
                    { 14, 22, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247) },
                    { 15, 23, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247) },
                    { 17, 24, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247) },
                    { 18, 25, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247) },
                    { 19, 26, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247) },
                    { 20, 27, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247) },
                    { 21, 28, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247) },
                    { 22, 29, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247) },
                    { 22, 30, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247) },
                    { 23, 31, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247) },
                    { 24, 32, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247) },
                    { 25, 33, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247) },
                    { 26, 34, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247) },
                    { 27, 35, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247) },
                    { 28, 36, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247) },
                    { 28, 37, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247) },
                    { 29, 38, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247) },
                    { 30, 39, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247) },
                    { 31, 40, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247) },
                    { 32, 41, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247) },
                    { 33, 42, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247) },
                    { 34, 43, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247) },
                    { 34, 44, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247) },
                    { 35, 45, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247) },
                    { 36, 46, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247) },
                    { 37, 47, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247) },
                    { 38, 48, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247) },
                    { 39, 49, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247) },
                    { 40, 50, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247) }
                });

            migrationBuilder.InsertData(
                table: "BookCategories",
                columns: new[] { "BookId", "CategoryId", "CreatedAtUtc" },
                values: new object[,]
                {
                    { 3, 8, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 5, 10, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 5, 14, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 6, 10, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 6, 14, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 7, 1, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 7, 9, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 8, 1, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 8, 8, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 8, 13, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 9, 1, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 9, 12, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 10, 1, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 10, 9, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 11, 1, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 11, 13, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 12, 1, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 12, 5, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 13, 1, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 13, 8, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 13, 11, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 14, 1, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 14, 8, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 14, 12, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 15, 2, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 15, 5, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 16, 2, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 16, 5, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 17, 2, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 17, 12, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 18, 2, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 18, 12, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 19, 2, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 19, 5, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 20, 3, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 21, 3, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 22, 3, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 22, 5, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 23, 3, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 24, 3, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 24, 4, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 25, 1, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 25, 3, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 25, 4, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 26, 3, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 27, 3, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 28, 13, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 28, 15, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 29, 8, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 29, 12, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 29, 13, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 30, 13, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 30, 15, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 31, 9, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 31, 11, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 31, 13, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 32, 3, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 32, 4, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 33, 4, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 33, 13, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 34, 3, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 34, 13, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 35, 11, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 35, 14, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 36, 6, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 37, 6, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 37, 7, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 38, 1, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 38, 6, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 39, 6, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 39, 7, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 40, 1, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 40, 10, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 41, 10, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 42, 10, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 43, 1, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 43, 13, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 44, 1, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 44, 9, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 45, 1, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 45, 13, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 46, 1, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 46, 10, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 46, 11, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 47, 1, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 47, 5, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 47, 14, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 48, 1, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 48, 13, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 49, 1, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 49, 12, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 50, 1, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) },
                    { 50, 12, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 5, 7 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 5, 8 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 6, 9 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 6, 10 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 7, 11 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 8, 12 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 9, 13 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 10, 14 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 11, 15 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 11, 16 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 12, 17 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 12, 18 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 16, 19 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 13, 20 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 13, 21 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 14, 22 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 15, 23 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 17, 24 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 18, 25 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 19, 26 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 20, 27 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 21, 28 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 22, 29 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 22, 30 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 23, 31 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 24, 32 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 25, 33 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 26, 34 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 27, 35 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 28, 36 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 28, 37 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 29, 38 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 30, 39 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 31, 40 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 32, 41 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 33, 42 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 34, 43 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 34, 44 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 35, 45 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 36, 46 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 37, 47 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 38, 48 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 39, 49 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 40, 50 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 3, 8 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 5, 10 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 5, 14 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 6, 10 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 6, 14 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 7, 9 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 8, 1 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 8, 8 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 8, 13 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 9, 1 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 9, 12 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 10, 1 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 10, 9 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 11, 1 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 11, 13 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 12, 1 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 12, 5 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 13, 1 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 13, 8 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 13, 11 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 14, 1 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 14, 8 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 14, 12 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 15, 2 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 15, 5 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 16, 2 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 16, 5 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 17, 2 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 17, 12 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 18, 2 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 18, 12 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 19, 2 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 19, 5 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 20, 3 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 21, 3 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 22, 3 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 22, 5 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 23, 3 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 24, 3 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 24, 4 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 25, 1 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 25, 3 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 25, 4 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 26, 3 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 27, 3 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 28, 13 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 28, 15 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 29, 8 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 29, 12 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 29, 13 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 30, 13 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 30, 15 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 31, 9 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 31, 11 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 31, 13 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 32, 3 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 32, 4 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 33, 4 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 33, 13 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 34, 3 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 34, 13 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 35, 11 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 35, 14 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 36, 6 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 37, 6 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 37, 7 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 38, 1 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 38, 6 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 39, 6 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 39, 7 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 40, 1 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 40, 10 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 41, 10 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 42, 10 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 43, 1 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 43, 13 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 44, 1 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 44, 9 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 45, 1 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 45, 13 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 46, 1 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 46, 10 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 46, 11 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 47, 1 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 47, 5 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 47, 14 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 48, 1 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 48, 13 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 49, 1 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 49, 12 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 50, 1 });

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 50, 12 });

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15);

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
                columns: new[] { "CreatedAtUtc", "FirstName", "LastName", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4423), "J.K.", "Rowling", new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4423) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "FirstName", "LastName", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4424), "Jane", "Austen", new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4425) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAtUtc", "FirstName", "LastName", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4426), "Mark", "Twain", new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4426) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAtUtc", "FirstName", "LastName", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4427), "Fyodor", "Dostoevsky", new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4428) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAtUtc", "FirstName", "LastName", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4429), "Leo", "Tolstoy", new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4429) });

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4643));

            migrationBuilder.InsertData(
                table: "BookAuthors",
                columns: new[] { "AuthorId", "BookId", "CreatedAtUtc" },
                values: new object[,]
                {
                    { 2, 2, new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4644) },
                    { 3, 3, new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4645) },
                    { 4, 4, new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4646) },
                    { 5, 5, new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4646) },
                    { 2, 6, new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4647) },
                    { 3, 6, new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4648) }
                });

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4669));

            migrationBuilder.InsertData(
                table: "BookCategories",
                columns: new[] { "BookId", "CategoryId", "CreatedAtUtc" },
                values: new object[,]
                {
                    { 2, 2, new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4670) },
                    { 3, 3, new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4671) },
                    { 4, 3, new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4673) },
                    { 4, 4, new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4672) },
                    { 5, 5, new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4673) },
                    { 6, 2, new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4674) },
                    { 6, 3, new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4675) }
                });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4602), new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4602) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "Price", "PublishDate", "Title", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4605), 19.99m, new DateOnly(1997, 6, 26), "Harry Potter and the Sorcerer's Stone", new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4606) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "Price", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4608), 12.5m, new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4608) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAtUtc", "Price", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4611), 14.2m, new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4611) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAtUtc", "Price", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4612), 17.75m, new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4613) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAtUtc", "Price", "PublishDate", "Title", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4614), 22.0m, new DateOnly(2025, 1, 1), "Collaborative Novel", new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4615) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "Name", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4547), "Dystopian", new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4547) });

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
                columns: new[] { "CreatedAtUtc", "Name", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4553), "Classic", new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4553) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAtUtc", "Name", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4554), "Adventure", new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4555) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAtUtc", "Name", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4556), "Philosophical Fiction", new DateTime(2025, 11, 23, 16, 7, 23, 402, DateTimeKind.Utc).AddTicks(4556) });
        }
    }
}
