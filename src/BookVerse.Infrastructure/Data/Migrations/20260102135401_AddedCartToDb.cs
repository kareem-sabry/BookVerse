using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookVerse.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedCartToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Categories",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Categories",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Books",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Books",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Books",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "ISBN",
                table: "Books",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Books",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Books",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Authors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Authors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Authors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Authors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PriceAtAdd = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426), new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426), new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426), new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426), new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426), new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426), new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426), new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426), new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426), new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426), new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426), new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426), new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426), new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426), new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426), new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426), new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426), new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426), new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426), new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426), new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426), new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426), new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426), new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426), new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426), new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426), new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426), new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426), new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426), new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426), new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426), new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426), new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426), new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426), new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426), new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426), new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426), new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426), new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426), new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426), new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(426) });

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 1, 2 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 2, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 3, 4 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 4, 5 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 4, 6 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 5, 7 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 5, 8 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 6, 9 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 6, 10 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 7, 11 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 8, 12 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 9, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 10, 14 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 11, 15 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 11, 16 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 12, 17 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 12, 18 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 16, 19 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 13, 20 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 13, 21 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 14, 22 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 15, 23 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 17, 24 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 18, 25 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 19, 26 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 20, 27 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 21, 28 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 22, 29 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 22, 30 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 23, 31 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 24, 32 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 25, 33 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 26, 34 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 27, 35 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 28, 36 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 28, 37 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 29, 38 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 30, 39 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 31, 40 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 32, 41 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 33, 42 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 34, 43 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 34, 44 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 35, 45 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 36, 46 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 37, 47 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 38, 48 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 39, 49 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 40, 50 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 1, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 1, 4 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 2, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 2, 4 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 3, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 3, 8 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 4, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 4, 5 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 5, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 5, 10 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 5, 14 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 6, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 6, 10 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 6, 14 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 7, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 7, 9 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 8, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 8, 8 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 8, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 9, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 9, 12 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 10, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 10, 9 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 11, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 11, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 12, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 12, 5 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 13, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 13, 8 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 13, 11 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 14, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 14, 8 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 14, 12 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 15, 2 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 15, 5 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 16, 2 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 16, 5 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 17, 2 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 17, 12 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 18, 2 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 18, 12 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 19, 2 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 19, 5 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 20, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 21, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 22, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 22, 5 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 23, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 24, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 24, 4 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 25, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 25, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 25, 4 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 26, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 27, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 28, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 28, 15 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 29, 8 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 29, 12 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 29, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 30, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 30, 15 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 31, 9 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 31, 11 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 31, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 32, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 32, 4 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 33, 4 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 33, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 34, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 34, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 35, 11 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 35, 14 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 36, 6 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 37, 6 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 37, 7 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 38, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 38, 6 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 39, 6 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 39, 7 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 40, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 40, 10 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 41, 10 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 42, 10 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 43, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 43, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 44, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 44, 9 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 45, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 45, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 46, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 46, 10 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 46, 11 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 47, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 47, 5 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 47, 14 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 48, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 48, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 49, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 49, 12 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 50, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 50, 12 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), 10, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), 10, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), 10, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), 10, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), 10, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), 10, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), 10, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), 10, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), 10, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), 10, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), 10, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), 10, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), 10, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), 10, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), 10, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), 10, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), 10, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), 10, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), 10, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), 10, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), 10, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), 10, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), 10, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), 10, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), 10, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), 10, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), 10, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), 10, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), 10, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), 10, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), 10, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), 10, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), 10, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), 10, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), 10, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), 10, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), 10, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), 10, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), 10, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), 10, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), 10, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), 10, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), 10, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), 10, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), 10, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), 10, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), 10, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), 10, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), 10, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), 10, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(588), new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(588) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(588), new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(588) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(588), new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(588) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(588), new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(588) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(588), new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(588) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(588), new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(588) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(588), new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(588) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(588), new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(588) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(588), new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(588) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(588), new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(588) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(588), new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(588) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(588), new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(588) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(588), new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(588) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(588), new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(588) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(588), new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(588) });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_BookId",
                table: "CartItems",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Books",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldPrecision: 18,
                oldScale: 4);

            migrationBuilder.AlterColumn<string>(
                name: "ISBN",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

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
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850), new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 1, 2 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 2, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 3, 4 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 4, 5 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 4, 6 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 5, 7 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 5, 8 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 6, 9 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 6, 10 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 7, 11 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 8, 12 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 9, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 10, 14 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 11, 15 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 11, 16 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 12, 17 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 12, 18 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 16, 19 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 13, 20 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 13, 21 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 14, 22 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 15, 23 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 17, 24 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 18, 25 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 19, 26 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 20, 27 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 21, 28 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 22, 29 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 22, 30 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 23, 31 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 24, 32 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 25, 33 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 26, 34 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 27, 35 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 28, 36 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 28, 37 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 29, 38 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 30, 39 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 31, 40 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 32, 41 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 33, 42 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 34, 43 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 34, 44 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 35, 45 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 36, 46 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 37, 47 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 38, 48 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 39, 49 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 40, 50 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 1, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 1, 4 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 2, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 2, 4 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 3, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 3, 8 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 4, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 4, 5 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 5, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 5, 10 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 5, 14 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 6, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 6, 10 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 6, 14 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 7, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 7, 9 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 8, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 8, 8 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 8, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 9, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 9, 12 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 10, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 10, 9 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 11, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 11, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 12, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 12, 5 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 13, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 13, 8 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 13, 11 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 14, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 14, 8 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 14, 12 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 15, 2 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 15, 5 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 16, 2 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 16, 5 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 17, 2 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 17, 12 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 18, 2 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 18, 12 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 19, 2 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 19, 5 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 20, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 21, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 22, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 22, 5 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 23, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 24, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 24, 4 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 25, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 25, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 25, 4 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 26, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 27, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 28, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 28, 15 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 29, 8 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 29, 12 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 29, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 30, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 30, 15 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 31, 9 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 31, 11 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 31, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 32, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 32, 4 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 33, 4 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 33, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 34, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 34, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 35, 11 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 35, 14 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 36, 6 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 37, 6 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 37, 7 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 38, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 38, 6 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 39, 6 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 39, 7 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 40, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 40, 10 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 41, 10 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 42, 10 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 43, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 43, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 44, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 44, 9 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 45, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 45, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 46, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 46, 10 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 46, 11 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 47, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 47, 5 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 47, 14 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 48, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 48, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 49, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 49, 12 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 50, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 50, 12 },
                column: "CreatedAtUtc",
                value: new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), 0, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), 0, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), 0, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), 0, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), 0, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), 0, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), 0, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), 0, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), 0, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), 0, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), 0, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), 0, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), 0, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), 0, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), 0, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), 0, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), 0, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), 0, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), 0, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), 0, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), 0, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), 0, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), 0, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), 0, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), 0, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), 0, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), 0, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), 0, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), 0, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), 0, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), 0, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), 0, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), 0, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), 0, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), 0, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), 0, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), 0, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), 0, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), 0, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), 0, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), 0, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), 0, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), 0, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), 0, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), 0, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), 0, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), 0, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), 0, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), 0, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAtUtc", "QuantityInStock", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51), 0, new DateTime(2025, 11, 26, 18, 3, 36, 887, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993), new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993) });

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
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993), new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993), new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993), new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993), new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993), new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993), new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993), new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993), new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993), new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993), new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993), new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993), new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993), new DateTime(2025, 11, 26, 18, 3, 36, 886, DateTimeKind.Utc).AddTicks(9993) });
        }
    }
}
