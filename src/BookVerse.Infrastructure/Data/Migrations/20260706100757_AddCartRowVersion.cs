using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookVerse.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCartRowVersion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Carts",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1653) });

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 1, 2 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 2, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 3, 4 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 4, 5 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 4, 6 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 5, 7 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 5, 8 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 6, 9 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 6, 10 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 7, 11 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 8, 12 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 9, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 10, 14 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 11, 15 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 11, 16 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 12, 17 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 12, 18 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 16, 19 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 13, 20 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 13, 21 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 14, 22 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 15, 23 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 17, 24 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 18, 25 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 19, 26 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 20, 27 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 21, 28 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 22, 29 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 22, 30 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 23, 31 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 24, 32 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 25, 33 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 26, 34 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 27, 35 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 28, 36 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 28, 37 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 29, 38 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 30, 39 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 31, 40 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 32, 41 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 33, 42 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 34, 43 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 34, 44 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 35, 45 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 36, 46 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 37, 47 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 38, 48 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 39, 49 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 40, 50 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 1, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 1, 4 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 2, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 2, 4 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 3, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 3, 8 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 4, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 4, 5 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 5, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 5, 10 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 5, 14 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 6, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 6, 10 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 6, 14 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 7, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 7, 9 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 8, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 8, 8 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 8, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 9, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 9, 12 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 10, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 10, 9 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 11, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 11, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 12, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 12, 5 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 13, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 13, 8 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 13, 11 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 14, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 14, 8 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 14, 12 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 15, 2 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 15, 5 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 16, 2 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 16, 5 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 17, 2 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 17, 12 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 18, 2 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 18, 12 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 19, 2 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 19, 5 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 20, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 21, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 22, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 22, 5 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 23, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 24, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 24, 4 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 25, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 25, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 25, 4 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 26, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 27, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 28, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 28, 15 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 29, 8 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 29, 12 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 29, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 30, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 30, 15 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 31, 9 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 31, 11 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 31, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 32, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 32, 4 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 33, 4 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 33, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 34, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 34, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 35, 11 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 35, 14 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 36, 6 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 37, 6 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 37, 7 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 38, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 38, 6 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 39, 6 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 39, 7 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 40, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 40, 10 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 41, 10 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 42, 10 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 43, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 43, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 44, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 44, 9 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 45, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 45, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 46, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 46, 10 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 46, 11 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 47, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 47, 5 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 47, 14 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 48, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 48, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 49, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 49, 12 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 50, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 50, 12 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1868) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1803), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1803) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1803), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1803) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1803), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1803) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1803), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1803) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1803), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1803) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1803), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1803) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1803), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1803) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1803), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1803) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1803), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1803) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1803), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1803) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1803), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1803) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1803), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1803) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1803), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1803) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1803), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1803) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1803), new DateTime(2026, 7, 6, 10, 7, 56, 301, DateTimeKind.Utc).AddTicks(1803) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Carts");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7027) });

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 1, 2 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 2, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 3, 4 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 4, 5 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 4, 6 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 5, 7 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 5, 8 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 6, 9 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 6, 10 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 7, 11 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 8, 12 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 9, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 10, 14 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 11, 15 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 11, 16 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 12, 17 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 12, 18 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 16, 19 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 13, 20 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 13, 21 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 14, 22 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 15, 23 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 17, 24 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 18, 25 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 19, 26 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 20, 27 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 21, 28 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 22, 29 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 22, 30 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 23, 31 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 24, 32 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 25, 33 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 26, 34 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 27, 35 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 28, 36 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 28, 37 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 29, 38 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 30, 39 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 31, 40 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 32, 41 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 33, 42 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 34, 43 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 34, 44 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 35, 45 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 36, 46 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 37, 47 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 38, 48 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 39, 49 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 40, 50 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 1, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 1, 4 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 2, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 2, 4 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 3, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 3, 8 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 4, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 4, 5 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 5, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 5, 10 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 5, 14 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 6, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 6, 10 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 6, 14 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 7, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 7, 9 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 8, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 8, 8 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 8, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 9, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 9, 12 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 10, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 10, 9 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 11, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 11, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 12, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 12, 5 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 13, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 13, 8 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 13, 11 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 14, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 14, 8 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 14, 12 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 15, 2 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 15, 5 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 16, 2 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 16, 5 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 17, 2 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 17, 12 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 18, 2 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 18, 12 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 19, 2 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 19, 5 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 20, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 21, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 22, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 22, 5 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 23, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 24, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 24, 4 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 25, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 25, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 25, 4 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 26, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 27, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 28, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 28, 15 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 29, 8 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 29, 12 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 29, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 30, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 30, 15 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 31, 9 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 31, 11 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 31, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 32, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 32, 4 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 33, 4 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 33, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 34, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 34, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 35, 11 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 35, 14 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 36, 6 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 37, 6 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 37, 7 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 38, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 38, 6 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 39, 6 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 39, 7 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 40, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 40, 10 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 41, 10 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 42, 10 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 43, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 43, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 44, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 44, 9 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 45, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 45, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 46, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 46, 10 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 46, 11 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 47, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 47, 5 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 47, 14 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 48, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 48, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 49, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 49, 12 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 50, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 50, 12 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7183), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7183) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7183), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7183) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7183), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7183) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7183), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7183) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7183), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7183) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7183), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7183) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7183), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7183) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7183), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7183) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7183), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7183) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7183), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7183) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7183), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7183) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7183), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7183) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7183), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7183) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7183), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7183) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7183), new DateTime(2026, 6, 29, 19, 58, 10, 821, DateTimeKind.Utc).AddTicks(7183) });
        }
    }
}
