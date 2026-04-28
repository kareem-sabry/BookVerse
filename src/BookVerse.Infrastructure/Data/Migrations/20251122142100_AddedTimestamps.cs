using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookVerse.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedTimestamps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAtUtc",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAtUtc",
                table: "Categories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAtUtc",
                table: "Books",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAtUtc",
                table: "Books",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAtUtc",
                table: "Authors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAtUtc",
                table: "Authors",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAtUtc",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAtUtc",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "CreatedBy", "UpdatedAtUtc", "UpdatedBy" },
                values: new object[] { new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(4957), "System", new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(4960), "System" });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "CreatedBy", "UpdatedAtUtc", "UpdatedBy" },
                values: new object[] { new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(4966), "System", new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(4966), "System" });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "CreatedBy", "UpdatedAtUtc", "UpdatedBy" },
                values: new object[] { new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(4968), "System", new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(4968), "System" });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAtUtc", "CreatedBy", "UpdatedAtUtc", "UpdatedBy" },
                values: new object[] { new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(4969), "System", new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(4970), "System" });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAtUtc", "CreatedBy", "UpdatedAtUtc", "UpdatedBy" },
                values: new object[] { new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(4971), "System", new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(4971), "System" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "CreatedBy", "UpdatedAtUtc", "UpdatedBy" },
                values: new object[] { new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(5125), "System", new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(5126), "System" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "CreatedBy", "UpdatedAtUtc", "UpdatedBy" },
                values: new object[] { new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(5130), "System", new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(5130), "System" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "CreatedBy", "UpdatedAtUtc", "UpdatedBy" },
                values: new object[] { new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(5132), "System", new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(5132), "System" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAtUtc", "CreatedBy", "UpdatedAtUtc", "UpdatedBy" },
                values: new object[] { new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(5135), "System", new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(5135), "System" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAtUtc", "CreatedBy", "UpdatedAtUtc", "UpdatedBy" },
                values: new object[] { new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(5136), "System", new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(5137), "System" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "CreatedBy", "UpdatedAtUtc", "UpdatedBy" },
                values: new object[] { new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(5171), "System", new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(5172), "System" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "CreatedBy", "UpdatedAtUtc", "UpdatedBy" },
                values: new object[] { new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(5203), "System", new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(5204), "System" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "CreatedBy", "UpdatedAtUtc", "UpdatedBy" },
                values: new object[] { new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(5205), "System", new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(5206), "System" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAtUtc", "CreatedBy", "UpdatedAtUtc", "UpdatedBy" },
                values: new object[] { new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(5207), "System", new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(5207), "System" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAtUtc", "CreatedBy", "UpdatedAtUtc", "UpdatedBy" },
                values: new object[] { new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(5208), "System", new DateTime(2025, 11, 22, 14, 20, 59, 550, DateTimeKind.Utc).AddTicks(5209), "System" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAtUtc",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "UpdatedAtUtc",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CreatedAtUtc",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "UpdatedAtUtc",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "CreatedAtUtc",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "UpdatedAtUtc",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "CreatedAtUtc",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UpdatedAtUtc",
                table: "AspNetUsers");
        }
    }
}
