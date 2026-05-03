using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookVerse.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialPostgres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    RefreshToken = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    PreviousRefreshToken = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    RefreshTokenExpiresAtUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    UpdatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    ISBN = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Price = table.Column<decimal>(type: "numeric(18,4)", precision: 18, scale: 4, nullable: false),
                    PublishDate = table.Column<DateOnly>(type: "date", nullable: false),
                    QuantityInStock = table.Column<int>(type: "integer", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    UpdatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    UpdatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    UpdatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
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
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    OrderDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    ShippingAddress = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    PaymentMethod = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    PaymentStatus = table.Column<int>(type: "integer", nullable: false),
                    StripePaymentIntentId = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Notes = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    UpdatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
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
                name: "BookAuthors",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "integer", nullable: false),
                    AuthorId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
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
                    BookId = table.Column<int>(type: "integer", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CartId = table.Column<int>(type: "integer", nullable: false),
                    BookId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    PriceAtAdd = table.Column<decimal>(type: "numeric(18,4)", precision: 18, scale: 4, nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    UpdatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
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

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    BookId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    PriceAtOrder = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    UpdatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("3472507d-6568-4360-bbaa-da29673194f5"), null, "Admin", "ADMIN" },
                    { new Guid("f27ed6e2-2249-4c12-835a-cc623cc8f3ba"), null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "CreatedAtUtc", "CreatedBy", "FirstName", "LastName", "UpdatedAtUtc", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System", "George", "Orwell", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System" },
                    { 2, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System", "Jane", "Austen", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System" },
                    { 3, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System", "Mark", "Twain", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System" },
                    { 4, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System", "Fyodor", "Dostoevsky", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System" },
                    { 5, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System", "Leo", "Tolstoy", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System" },
                    { 6, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System", "Charles", "Dickens", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System" },
                    { 7, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System", "F. Scott", "Fitzgerald", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System" },
                    { 8, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System", "Herman", "Melville", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System" },
                    { 9, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System", "Emily", "Brontë", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System" },
                    { 10, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System", "Charlotte", "Brontë", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System" },
                    { 11, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System", "J.R.R.", "Tolkien", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System" },
                    { 12, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System", "J.K.", "Rowling", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System" },
                    { 13, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System", "Isaac", "Asimov", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System" },
                    { 14, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System", "Frank", "Herbert", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System" },
                    { 15, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System", "Douglas", "Adams", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System" },
                    { 16, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System", "C.S.", "Lewis", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System" },
                    { 17, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System", "Ray", "Bradbury", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System" },
                    { 18, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System", "Aldous", "Huxley", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System" },
                    { 19, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System", "Philip K.", "Dick", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System" },
                    { 20, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System", "Ursula K.", "Le Guin", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System" },
                    { 21, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System", "Gabriel García", "Márquez", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System" },
                    { 22, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System", "Haruki", "Murakami", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System" },
                    { 23, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System", "Toni", "Morrison", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System" },
                    { 24, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System", "Margaret", "Atwood", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System" },
                    { 25, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System", "Cormac", "McCarthy", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System" },
                    { 26, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System", "Kurt", "Vonnegut", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System" },
                    { 27, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System", "Stephen", "King", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System" },
                    { 28, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System", "Agatha", "Christie", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System" },
                    { 29, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System", "Arthur Conan", "Doyle", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System" },
                    { 30, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System", "Dan", "Brown", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System" },
                    { 31, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System", "Albert", "Camus", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System" },
                    { 32, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System", "Viktor", "Frankl", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System" },
                    { 33, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System", "Sun", "Tzu", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System" },
                    { 34, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System", "Ernest", "Hemingway", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System" },
                    { 35, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System", "Virginia", "Woolf", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System" },
                    { 36, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System", "Oscar", "Wilde", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System" },
                    { 37, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System", "William", "Golding", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System" },
                    { 38, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System", "John", "Steinbeck", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System" },
                    { 39, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System", "Harper", "Lee", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System" },
                    { 40, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System", "J.D.", "Salinger", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4642), "System" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "CreatedAtUtc", "CreatedBy", "Description", "ISBN", "Price", "PublishDate", "QuantityInStock", "Title", "UpdatedAtUtc", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System", "Dystopian novel about surveillance and totalitarianism.", "9780451524935", 15.99m, new DateOnly(1949, 6, 8), 10, "1984", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System" },
                    { 2, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System", "Allegorical tale reflecting the Russian Revolution.", "9780451526342", 12.99m, new DateOnly(1945, 8, 17), 10, "Animal Farm", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System" },
                    { 3, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System", "Classic story of manners, marriage, and social class.", "9780141439518", 11.99m, new DateOnly(1813, 1, 28), 10, "Pride and Prejudice", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System" },
                    { 4, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System", "Boyhood adventures along the Mississippi River.", "9780486280615", 13.50m, new DateOnly(1884, 12, 10), 10, "Adventures of Huckleberry Finn", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System" },
                    { 5, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System", "Psychological novel about guilt and redemption.", "9780140449136", 16.75m, new DateOnly(1866, 1, 1), 10, "Crime and Punishment", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System" },
                    { 6, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System", "Philosophical novel exploring faith and morality.", "9780374528379", 18.99m, new DateOnly(1880, 1, 1), 10, "The Brothers Karamazov", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System" },
                    { 7, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System", "Epic tale of history and personal stories during the Napoleonic Wars.", "9780199232765", 22.50m, new DateOnly(1869, 1, 1), 10, "War and Peace", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System" },
                    { 8, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System", "Tragic story of love, infidelity, and society in Russia.", "9780143035008", 17.99m, new DateOnly(1878, 1, 1), 10, "Anna Karenina", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System" },
                    { 9, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System", "Coming-of-age story with themes of wealth and social ambition.", "9780141439563", 14.25m, new DateOnly(1861, 1, 1), 10, "Great Expectations", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System" },
                    { 10, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System", "Historical novel set in London and Paris during the French Revolution.", "9780141439600", 13.99m, new DateOnly(1859, 4, 30), 10, "A Tale of Two Cities", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System" },
                    { 11, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System", "Tragic story of wealth, love, and the American Dream.", "9780743273565", 14.99m, new DateOnly(1925, 4, 10), 10, "The Great Gatsby", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System" },
                    { 12, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System", "Epic sea adventure and obsession with the white whale.", "9780142437247", 16.50m, new DateOnly(1851, 10, 18), 10, "Moby-Dick", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System" },
                    { 13, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System", "Gothic tale of love and revenge on the Yorkshire moors.", "9780141439556", 12.75m, new DateOnly(1847, 12, 1), 10, "Wuthering Heights", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System" },
                    { 14, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System", "Story of love, morality, and independence of an orphaned girl.", "9780141441146", 13.50m, new DateOnly(1847, 10, 16), 10, "Jane Eyre", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System" },
                    { 15, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System", "Epic fantasy saga of Middle-earth and the battle against evil.", "9780618640157", 29.99m, new DateOnly(1954, 7, 29), 10, "The Lord of the Rings", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System" },
                    { 16, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System", "A journey of a hobbit who finds courage and adventure.", "9780547928227", 18.99m, new DateOnly(1937, 9, 21), 10, "The Hobbit", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System" },
                    { 17, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System", "A young wizard begins his magical journey.", "9780747532699", 19.99m, new DateOnly(1997, 6, 26), 10, "Harry Potter and the Philosopher's Stone", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System" },
                    { 18, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System", "Second year at Hogwarts brings new mysteries.", "9780747538493", 19.99m, new DateOnly(1998, 7, 2), 10, "Harry Potter and the Chamber of Secrets", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System" },
                    { 19, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System", "Fantasy series where children enter a magical land.", "9780066238500", 24.99m, new DateOnly(1950, 10, 16), 10, "The Chronicles of Narnia", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System" },
                    { 20, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System", "Science fiction epic about the fall and rise of a galactic empire.", "9780553293357", 15.99m, new DateOnly(1951, 6, 1), 10, "Foundation", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System" },
                    { 21, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System", "Short stories exploring AI, robots, and ethics.", "9780553294385", 14.50m, new DateOnly(1950, 12, 2), 10, "I, Robot", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System" },
                    { 22, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System", "Epic sci-fi saga on desert planet and political intrigue.", "9780441172719", 21.99m, new DateOnly(1965, 8, 1), 10, "Dune", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System" },
                    { 23, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System", "Comedy sci-fi adventure across the universe.", "9780345391803", 16.99m, new DateOnly(1979, 10, 12), 10, "The Hitchhiker's Guide to the Galaxy", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System" },
                    { 24, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System", "Dystopian novel about censorship and book burning.", "9781451673319", 14.99m, new DateOnly(1953, 10, 19), 10, "Fahrenheit 451", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System" },
                    { 25, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System", "Futuristic dystopia exploring technology and society.", "9780060850524", 15.50m, new DateOnly(1932, 1, 1), 10, "Brave New World", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System" },
                    { 26, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System", "Sci-fi exploring humanity and artificial life.", "9780345404473", 14.99m, new DateOnly(1968, 1, 1), 10, "Do Androids Dream of Electric Sheep?", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System" },
                    { 27, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System", "Exploration of gender and politics on a distant planet.", "9780441478125", 15.99m, new DateOnly(1969, 3, 1), 10, "The Left Hand of Darkness", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System" },
                    { 28, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System", "Multi-generational tale blending reality and magic.", "9780060883287", 17.99m, new DateOnly(1967, 5, 30), 10, "One Hundred Years of Solitude", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System" },
                    { 29, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System", "Coming-of-age novel exploring love and loss.", "9780375704024", 16.50m, new DateOnly(1987, 9, 4), 10, "Norwegian Wood", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System" },
                    { 30, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System", "Surreal novel exploring fate, consciousness, and mystery.", "9781400079278", 17.25m, new DateOnly(2002, 9, 12), 10, "Kafka on the Shore", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System" },
                    { 31, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System", "Haunting tale of slavery, memory, and motherhood.", "9781400033416", 15.99m, new DateOnly(1987, 9, 1), 10, "Beloved", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System" },
                    { 32, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System", "Dystopian novel about oppression and control of women.", "9780385490818", 16.99m, new DateOnly(1985, 8, 1), 10, "The Handmaid's Tale", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System" },
                    { 33, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System", "Post-apocalyptic journey of father and son.", "9780307387899", 15.50m, new DateOnly(2006, 9, 26), 10, "The Road", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System" },
                    { 34, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System", "Darkly comic novel about war and time travel.", "9780440180296", 14.99m, new DateOnly(1969, 3, 31), 10, "Slaughterhouse-Five", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System" },
                    { 35, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System", "Horror novel about a haunted hotel and psychic powers.", "9780307743657", 18.99m, new DateOnly(1977, 1, 28), 10, "The Shining", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System" },
                    { 36, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System", "Detective novel featuring a murder on a train.", "9780062693662", 14.50m, new DateOnly(1934, 1, 1), 10, "Murder on the Orient Express", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System" },
                    { 37, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System", "Suspenseful mystery about ten strangers trapped on an island.", "9780062073488", 13.99m, new DateOnly(1939, 11, 6), 10, "And Then There Were None", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System" },
                    { 38, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System", "Sherlock Holmes investigates a supernatural hound.", "9780451528018", 12.99m, new DateOnly(1902, 4, 1), 10, "The Hound of the Baskervilles", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System" },
                    { 39, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System", "Thriller unraveling a conspiracy in the art world.", "9780307474278", 16.99m, new DateOnly(2003, 3, 18), 10, "The Da Vinci Code", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System" },
                    { 40, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System", "Existential novel about absurdity and alienation.", "9780679720201", 13.50m, new DateOnly(1942, 1, 1), 10, "The Stranger", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System" },
                    { 41, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System", "Memoir about surviving the Holocaust and finding purpose.", "9780807014295", 14.99m, new DateOnly(1946, 1, 1), 10, "Man's Search for Meaning", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System" },
                    { 42, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System", "Ancient treatise on military strategy and tactics.", "9781590302255", 11.99m, new DateOnly(1910, 1, 1), 10, "The Art of War", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System" },
                    { 43, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System", "Story of an old fisherman's struggle with a giant marlin.", "9780684801223", 12.99m, new DateOnly(1952, 9, 1), 10, "The Old Man and the Sea", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System" },
                    { 44, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System", "Novel set during the Spanish Civil War.", "9780684803357", 15.99m, new DateOnly(1940, 10, 21), 10, "For Whom the Bell Tolls", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System" },
                    { 45, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System", "Explores a day in the life of a high-society woman.", "9780156628709", 13.50m, new DateOnly(1925, 5, 14), 10, "Mrs Dalloway", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System" },
                    { 46, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System", "Story about vanity, morality, and eternal youth.", "9780141439570", 12.99m, new DateOnly(1890, 7, 1), 10, "The Picture of Dorian Gray", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System" },
                    { 47, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System", "Boys stranded on an island descend into savagery.", "9780399501487", 13.99m, new DateOnly(1954, 9, 17), 10, "Lord of the Flies", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System" },
                    { 48, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System", "Two displaced ranch workers pursue their American Dream.", "9780140177398", 11.99m, new DateOnly(1937, 2, 25), 10, "Of Mice and Men", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System" },
                    { 49, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System", "Story about racial injustice and childhood in the Deep South.", "9780061120084", 14.99m, new DateOnly(1960, 7, 11), 10, "To Kill a Mockingbird", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System" },
                    { 50, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System", "Teenager's journey navigating alienation and identity.", "9780316769488", 13.99m, new DateOnly(1951, 7, 16), 10, "The Catcher in the Rye", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4864), "System" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAtUtc", "CreatedBy", "Name", "UpdatedAtUtc", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4811), "System", "Classic Literature", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4811), "System" },
                    { 2, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4811), "System", "Fantasy", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4811), "System" },
                    { 3, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4811), "System", "Science Fiction", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4811), "System" },
                    { 4, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4811), "System", "Dystopian", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4811), "System" },
                    { 5, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4811), "System", "Adventure", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4811), "System" },
                    { 6, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4811), "System", "Mystery", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4811), "System" },
                    { 7, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4811), "System", "Thriller", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4811), "System" },
                    { 8, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4811), "System", "Romance", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4811), "System" },
                    { 9, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4811), "System", "Historical Fiction", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4811), "System" },
                    { 10, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4811), "System", "Philosophy", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4811), "System" },
                    { 11, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4811), "System", "Horror", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4811), "System" },
                    { 12, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4811), "System", "Coming of Age", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4811), "System" },
                    { 13, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4811), "System", "Literary Fiction", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4811), "System" },
                    { 14, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4811), "System", "Psychological Fiction", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4811), "System" },
                    { 15, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4811), "System", "Magical Realism", new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(4811), "System" }
                });

            migrationBuilder.InsertData(
                table: "BookAuthors",
                columns: new[] { "AuthorId", "BookId", "CreatedAtUtc" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5077) },
                    { 1, 2, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5077) },
                    { 2, 3, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5077) },
                    { 3, 4, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5077) },
                    { 4, 5, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5077) },
                    { 4, 6, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5077) },
                    { 5, 7, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5077) },
                    { 5, 8, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5077) },
                    { 6, 9, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5077) },
                    { 6, 10, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5077) },
                    { 7, 11, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5077) },
                    { 8, 12, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5077) },
                    { 9, 13, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5077) },
                    { 10, 14, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5077) },
                    { 11, 15, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5077) },
                    { 11, 16, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5077) },
                    { 12, 17, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5077) },
                    { 12, 18, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5077) },
                    { 16, 19, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5077) },
                    { 13, 20, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5077) },
                    { 13, 21, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5077) },
                    { 14, 22, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5077) },
                    { 15, 23, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5077) },
                    { 17, 24, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5077) },
                    { 18, 25, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5077) },
                    { 19, 26, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5077) },
                    { 20, 27, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5077) },
                    { 21, 28, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5077) },
                    { 22, 29, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5077) },
                    { 22, 30, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5077) },
                    { 23, 31, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5077) },
                    { 24, 32, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5077) },
                    { 25, 33, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5077) },
                    { 26, 34, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5077) },
                    { 27, 35, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5077) },
                    { 28, 36, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5077) },
                    { 28, 37, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5077) },
                    { 29, 38, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5077) },
                    { 30, 39, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5077) },
                    { 31, 40, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5077) },
                    { 32, 41, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5077) },
                    { 33, 42, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5077) },
                    { 34, 43, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5077) },
                    { 34, 44, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5077) },
                    { 35, 45, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5077) },
                    { 36, 46, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5077) },
                    { 37, 47, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5077) },
                    { 38, 48, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5077) },
                    { 39, 49, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5077) },
                    { 40, 50, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5077) }
                });

            migrationBuilder.InsertData(
                table: "BookCategories",
                columns: new[] { "BookId", "CategoryId", "CreatedAtUtc" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 1, 3, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 1, 4, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 2, 1, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 2, 4, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 3, 1, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 3, 8, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 4, 1, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 4, 5, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 5, 1, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 5, 10, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 5, 14, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 6, 1, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 6, 10, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 6, 14, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 7, 1, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 7, 9, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 8, 1, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 8, 8, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 8, 13, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 9, 1, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 9, 12, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 10, 1, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 10, 9, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 11, 1, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 11, 13, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 12, 1, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 12, 5, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 13, 1, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 13, 8, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 13, 11, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 14, 1, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 14, 8, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 14, 12, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 15, 2, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 15, 5, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 16, 2, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 16, 5, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 17, 2, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 17, 12, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 18, 2, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 18, 12, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 19, 2, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 19, 5, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 20, 3, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 21, 3, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 22, 3, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 22, 5, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 23, 3, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 24, 3, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 24, 4, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 25, 1, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 25, 3, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 25, 4, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 26, 3, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 27, 3, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 28, 13, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 28, 15, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 29, 8, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 29, 12, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 29, 13, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 30, 13, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 30, 15, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 31, 9, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 31, 11, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 31, 13, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 32, 3, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 32, 4, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 33, 4, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 33, 13, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 34, 3, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 34, 13, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 35, 11, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 35, 14, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 36, 6, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 37, 6, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 37, 7, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 38, 1, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 38, 6, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 39, 6, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 39, 7, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 40, 1, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 40, 10, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 41, 10, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 42, 10, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 43, 1, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 43, 13, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 44, 1, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 44, 9, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 45, 1, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 45, 13, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 46, 1, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 46, 10, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 46, 11, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 47, 1, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 47, 5, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 47, 14, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 48, 1, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 48, 13, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 49, 1, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 49, 12, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 50, 1, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) },
                    { 50, 12, new DateTime(2026, 5, 3, 8, 32, 22, 195, DateTimeKind.Utc).AddTicks(5183) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PreviousRefreshToken",
                table: "AspNetUsers",
                column: "PreviousRefreshToken");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RefreshToken",
                table: "AspNetUsers",
                column: "RefreshToken");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_AuthorId",
                table: "BookAuthors",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BookCategories_CategoryId",
                table: "BookCategories",
                column: "CategoryId");

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
                name: "IX_Orders_StripePaymentIntentId",
                table: "Orders",
                column: "StripePaymentIntentId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BookAuthors");

            migrationBuilder.DropTable(
                name: "BookCategories");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
