using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookVerse.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class modifiedBookSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ShippingAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PriceAtOrder = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624), new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624), new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624), new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624), new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624), new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624), new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624), new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624), new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624), new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624), new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624), new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624), new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624), new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624), new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624), new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624), new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624), new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624), new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624), new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624), new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624), new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624), new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624), new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624), new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624), new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624), new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624), new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624), new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624), new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624), new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624), new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624), new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624), new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624), new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624), new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624), new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624), new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624), new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624), new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624), new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3624) });

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 1, 2 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 2, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 3, 4 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 4, 5 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 4, 6 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 5, 7 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 5, 8 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 6, 9 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 6, 10 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 7, 11 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 8, 12 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 9, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 10, 14 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 11, 15 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 11, 16 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 12, 17 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 12, 18 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 16, 19 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 13, 20 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 13, 21 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 14, 22 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 15, 23 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 17, 24 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 18, 25 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 19, 26 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 20, 27 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 21, 28 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 22, 29 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 22, 30 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 23, 31 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 24, 32 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 25, 33 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 26, 34 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 27, 35 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 28, 36 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 28, 37 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 29, 38 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 30, 39 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 31, 40 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 32, 41 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 33, 42 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 34, 43 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 34, 44 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 35, 45 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 36, 46 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 37, 47 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 38, 48 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 39, 49 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 40, 50 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 1, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 1, 4 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 2, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 2, 4 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 3, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 3, 8 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 4, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 4, 5 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 5, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 5, 10 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 5, 14 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 6, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 6, 10 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 6, 14 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 7, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 7, 9 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 8, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 8, 8 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 8, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 9, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 9, 12 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 10, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 10, 9 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 11, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 11, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 12, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 12, 5 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 13, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 13, 8 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 13, 11 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 14, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 14, 8 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 14, 12 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 15, 2 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 15, 5 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 16, 2 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 16, 5 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 17, 2 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 17, 12 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 18, 2 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 18, 12 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 19, 2 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 19, 5 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 20, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 21, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 22, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 22, 5 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 23, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 24, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 24, 4 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 25, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 25, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 25, 4 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 26, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 27, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 28, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 28, 15 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 29, 8 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 29, 12 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 29, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 30, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 30, 15 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 31, 9 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 31, 11 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 31, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 32, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 32, 4 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 33, 4 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 33, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 34, 3 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 34, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 35, 11 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 35, 14 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 36, 6 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 37, 6 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 37, 7 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 38, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 38, 6 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 39, 6 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 39, 7 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 40, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 40, 10 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 41, 10 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 42, 10 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 43, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 43, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 44, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 44, 9 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 45, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 45, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 46, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 46, 10 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 46, 11 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 47, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 47, 5 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 47, 14 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 48, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 48, 13 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 49, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 49, 12 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 50, 1 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 50, 12 },
                column: "CreatedAtUtc",
                value: new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830), "Dystopian novel about surveillance and totalitarianism.", "9780451524935", new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830), "Allegorical tale reflecting the Russian Revolution.", "9780451526342", new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830), "Classic story of manners, marriage, and social class.", "9780141439518", new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830), "Boyhood adventures along the Mississippi River.", "9780486280615", new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830), "Psychological novel about guilt and redemption.", "9780140449136", new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830), "Philosophical novel exploring faith and morality.", "9780374528379", new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830), "Epic tale of history and personal stories during the Napoleonic Wars.", "9780199232765", new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830), "Tragic story of love, infidelity, and society in Russia.", "9780143035008", new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830), "Coming-of-age story with themes of wealth and social ambition.", "9780141439563", new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830), "Historical novel set in London and Paris during the French Revolution.", "9780141439600", new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830), "Tragic story of wealth, love, and the American Dream.", "9780743273565", new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830), "Epic sea adventure and obsession with the white whale.", "9780142437247", new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830), "Gothic tale of love and revenge on the Yorkshire moors.", "9780141439556", new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830), "Story of love, morality, and independence of an orphaned girl.", "9780141441146", new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830), "Epic fantasy saga of Middle-earth and the battle against evil.", "9780618640157", new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830), "A journey of a hobbit who finds courage and adventure.", "9780547928227", new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830), "A young wizard begins his magical journey.", "9780747532699", new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830), "Second year at Hogwarts brings new mysteries.", "9780747538493", new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830), "Fantasy series where children enter a magical land.", "9780066238500", new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830), "Science fiction epic about the fall and rise of a galactic empire.", "9780553293357", new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830), "Short stories exploring AI, robots, and ethics.", "9780553294385", new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830), "Epic sci-fi saga on desert planet and political intrigue.", "9780441172719", new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830), "Comedy sci-fi adventure across the universe.", "9780345391803", new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830), "Dystopian novel about censorship and book burning.", "9781451673319", new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830), "Futuristic dystopia exploring technology and society.", "9780060850524", new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830), "Sci-fi exploring humanity and artificial life.", "9780345404473", new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830), "Exploration of gender and politics on a distant planet.", "9780441478125", new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830), "Multi-generational tale blending reality and magic.", "9780060883287", new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830), "Coming-of-age novel exploring love and loss.", "9780375704024", new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830), "Surreal novel exploring fate, consciousness, and mystery.", "9781400079278", new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830), "Haunting tale of slavery, memory, and motherhood.", "9781400033416", new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830), "Dystopian novel about oppression and control of women.", "9780385490818", new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830), "Post-apocalyptic journey of father and son.", "9780307387899", new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830), "Darkly comic novel about war and time travel.", "9780440180296", new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830), "Horror novel about a haunted hotel and psychic powers.", "9780307743657", new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830), "Detective novel featuring a murder on a train.", "9780062693662", new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830), "Suspenseful mystery about ten strangers trapped on an island.", "9780062073488", new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830), "Sherlock Holmes investigates a supernatural hound.", "9780451528018", new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830), "Thriller unraveling a conspiracy in the art world.", "9780307474278", new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830), "Existential novel about absurdity and alienation.", "9780679720201", new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830), "Memoir about surviving the Holocaust and finding purpose.", "9780807014295", new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830), "Ancient treatise on military strategy and tactics.", "9781590302255", new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830), "Story of an old fisherman's struggle with a giant marlin.", "9780684801223", new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830), "Novel set during the Spanish Civil War.", "9780684803357", new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830), "Explores a day in the life of a high-society woman.", "9780156628709", new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830), "Story about vanity, morality, and eternal youth.", "9780141439570", new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830), "Boys stranded on an island descend into savagery.", "9780399501487", new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830), "Two displaced ranch workers pursue their American Dream.", "9780140177398", new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830), "Story about racial injustice and childhood in the Deep South.", "9780061120084", new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830), "Teenager's journey navigating alienation and identity.", "9780316769488", new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3776), new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3776) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3776), new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3776) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3776), new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3776) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3776), new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3776) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3776), new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3776) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3776), new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3776) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3776), new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3776) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3776), new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3776) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3776), new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3776) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3776), new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3776) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3776), new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3776) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3776), new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3776) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3776), new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3776) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3776), new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3776) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3776), new DateTime(2026, 1, 7, 16, 33, 40, 611, DateTimeKind.Utc).AddTicks(3776) });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_BookId",
                table: "OrderItems",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderDate",
                table: "Orders",
                column: "OrderDate");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderNumber",
                table: "Orders",
                column: "OrderNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

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
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), null, null, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), null, null, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), null, null, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), null, null, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), null, null, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), null, null, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), null, null, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), null, null, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), null, null, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), null, null, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), null, null, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), null, null, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), null, null, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), null, null, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), null, null, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), null, null, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), null, null, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), null, null, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), null, null, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), null, null, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), null, null, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), null, null, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), null, null, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), null, null, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), null, null, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), null, null, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), null, null, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), null, null, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), null, null, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), null, null, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), null, null, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), null, null, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), null, null, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), null, null, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), null, null, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), null, null, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), null, null, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), null, null, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), null, null, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), null, null, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), null, null, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), null, null, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), null, null, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), null, null, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), null, null, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), null, null, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), null, null, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), null, null, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), null, null, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647), null, null, new DateTime(2026, 1, 2, 13, 54, 0, 510, DateTimeKind.Utc).AddTicks(647) });

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
        }
    }
}
