<div align="center">

# 📚 BookVerse API

[![CI](https://github.com/kareem-sabry/BookVerseApi/actions/workflows/ci.yml/badge.svg)](https://github.com/kareem-sabry/BookVerseApi/actions/workflows/ci.yml)
[![CD](https://github.com/kareem-sabry/BookVerseApi/actions/workflows/cd.yml/badge.svg)](https://github.com/kareem-sabry/BookVerseApi/actions/workflows/cd.yml)
[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![SQL Server](https://img.shields.io/badge/Database-SQL%20Server%202022-CC2927?logo=microsoftsqlserver)](https://www.microsoft.com/sql-server)
[![Redis](https://img.shields.io/badge/Cache-Redis%207-DC382D?logo=redis)](https://redis.io/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)
[![Tests](https://img.shields.io/badge/Tests-76%20Passing-2ea44f)](https://github.com/kareem-sabry/BookVerseApi/actions)
[![Docker](https://img.shields.io/badge/Docker-Ready-2496ED?logo=docker)](https://hub.docker.com/)
[![Stripe](https://img.shields.io/badge/Payments-Stripe-635BFF?logo=stripe)](https://stripe.com)

**A production-style RESTful API for an online bookstore** — built with ASP.NET Core 8, Clean Architecture, JWT authentication with refresh-token rotation, Stripe payments, Redis caching, and automated CI/CD.

[🚀 Quick Start](#-quick-start) · [📖 API Reference](#-api-reference) · [🏗 Architecture](#-architecture) · [🧪 Testing](#-testing) · [🔐 Security](#-security) · [⚠️ Known Issues](#️-known-issues--notes)

</div>

---

## 🌐 Live Demo

> **🚧 Coming Soon** — This API isn't deployed to a public environment yet. In the meantime, follow [Quick Start](#-quick-start) to run it locally in under 5 minutes.

---

## ✨ Features

| Area | What's Included |
|------|----------------|
| **🔐 Authentication** | JWT + refresh tokens with **theft detection** (reusing a rotated token revokes the whole session), role-based access (Admin/User), email-based password reset, account lockout after 5 failed attempts |
| **📚 Books** | Full CRUD, search & filtering (price range, author, category, publish date), pagination, sorting, many-to-many authors & categories, optimistic concurrency via row version |
| **🛒 Shopping Cart** | Add/update/remove items, server-side total calculation, stock validation against live inventory |
| **📦 Orders** | Order creation from cart with atomic stock deduction, order-number collision retry, forward-only status transitions, cancellation with stock restoration |
| **💳 Payments** | Stripe PaymentIntent flow, webhook signature verification, idempotent webhook handling (replayed events are safely ignored) |
| **👤 Admin** | Paginated user management, role promotion/demotion, account deletion — with self-demotion/self-deletion guards |
| **⚡ Caching & Performance** | Redis-backed distributed cache for single-book lookups (cache-aside, 5 min TTL, explicit eviction on stock mutations, graceful fallback to DB on Redis failure), HTTP response caching for list endpoints (300s) |
| **🚦 API Versioning & Rate Limiting** | URL-segment + header-based API versioning (`/api/v1/...`), tiered rate limits (global, auth, public API) using .NET 8's built-in `RateLimiter` |
| **🔒 Security** | ASP.NET Identity password hashing, CORS policies per environment, HTTPS + HSTS, security headers, parameterized EF Core queries, structured `ProblemDetails` error responses |
| **🐳 Docker** | Multi-stage build, non-root container user, health checks for API/DB/Redis, single `docker-compose.yml` for both dev and prod (environment-driven) |
| **🚀 CI/CD** | GitHub Actions: build + test + coverage on every push/PR, Docker image build & push to GHCR triggered automatically after CI succeeds on `master` |

---

## 🏗 Architecture

**Clean Architecture** with four clearly separated layers each outer layer only depends inward.

```
┌─────────────────────────────────────────────────────────────┐
│                      BookVerse.Api                          │
│         Controllers, Middleware, Program.cs (DI/host)       │
│                   (Presentation Layer)                      │
└────────────────────────┬────────────────────────────────────┘
                         │ depends on
┌────────────────────────▼────────────────────────────────────┐
│               BookVerse.Infrastructure                      │
│   EF Core, Repositories, Redis cache, Stripe, SMTP email    │
│                   (Data Access Layer)                       │
└────────────────────────┬────────────────────────────────────┘
                         │ depends on
┌────────────────────────▼────────────────────────────────────┐
│               BookVerse.Application                         │
│           DTOs, Service Interfaces, IUnitOfWork             │
│                  (Business Contracts Layer)                 │
└────────────────────────┬────────────────────────────────────┘
                         │ depends on
┌────────────────────────▼────────────────────────────────────┐
│                  BookVerse.Core                             │
│         Entities, Enums, Exceptions, Options Models         │
│                    (Domain Layer)                           │
│                                                             │
│                                                             │
└─────────────────────────────────────────────────────────────┘
```

`BookVerse.Tests` references all four layers and exercises the service layer through mocked repositories/`IUnitOfWork`.

### Design Patterns

| Pattern | Purpose |
|---|---|
| **Repository + Unit of Work** | Abstracts data access; `IUnitOfWork` ensures atomic multi-repository operations with explicit `BeginTransactionAsync`/`CommitTransactionAsync`/`RollbackTransactionAsync` |
| **Dependency Injection** | Loose coupling, testability, SOLID principles |
| **AutoMapper** | Clean separation between EF entities and DTOs |
| **Options Pattern** | Strongly-typed, validated configuration (`JwtOptions`, `StripeOptions`, `EmailOptions`, `AdminUserOptions`) |
| **Global Exception Handling** | `IExceptionHandler` maps domain exceptions to consistent `ProblemDetails` responses, no stack traces leaked in production |
| **Cache-Aside** | `BooksService` checks Redis before hitting the database, with try/catch fallback in `RedisCacheService` |

### Key Architectural Decisions

- **Refresh-token theft detection** — refresh tokens are stored hashed (SHA-256). The *previous* rotated token's hash is retained for one cycle; replaying an already-consumed token revokes **both** tokens for that user immediately, containing a stolen-token scenario instead of silently accepting it.
- **Optimistic concurrency on `Book`** — `RowVersion` is a SQL Server rowversion column. If two checkouts race on the same book's stock, EF raises `DbUpdateConcurrencyException`; `OrderService` catches it, re-reads fresh stock, and either confirms the order is still valid or throws a retriable `ConflictException`.
- **Order-number collision retry** — `OrderService` catches the SQL unique-constraint violation (error 2627/2601) on the generated `OrderNumber`, rolls back, and retries once with a freshly generated number rather than failing the checkout outright.
- **Idempotent Stripe webhooks** — before applying a webhook event, `PaymentService` checks whether the order's `PaymentStatus` is already `Completed`/`Failed` and no-ops if so, so Stripe's at-least-once delivery can't double-apply side effects.
- **Cache eviction on stock mutations** — `OrderService` calls `ICacheService.RemoveAsync(CacheKeys.Book(id))` for every book whose `QuantityInStock` changes, immediately after `CommitTransactionAsync` in both `CreateOrderFromCartAsync` and `CancelOrderAsync`. Evictions run concurrently via `Task.WhenAll`. Without this, the 5-minute cache-aside TTL on `GetByIdAsync` would serve stale `QuantityInStock` values after every purchase or cancellation — including showing a sold-out book as in-stock.
- **Forward-only state machines** — both `OrderStatus` and `PaymentStatus` transitions are enforced through explicit allow-lists (e.g. `Pending → Processing → Shipped → Delivered`, cancellation only from `Pending`/`Processing`; payment `Pending → Completed/Failed`, `Completed → Refunded`). Any other transition throws.
- **Centralized audit trail** — `CreatedAtUtc` / `UpdatedAtUtc` / `CreatedBy` / `UpdatedBy` are stamped exclusively inside `AppDbContext.SaveChangesAsync` via change-tracker interception. `CreatedAtUtc`/`CreatedBy` are explicitly locked from being overwritten on update — services never set these fields themselves.
- **Stripe.net isolated to Infrastructure** — `Core` has zero Stripe (or any external) dependency; only `Infrastructure`/`Application` reference `Stripe.net`.
- **`CancellationToken` throughout** — every async repository/service method accepts and propagates one.

---

## 🚀 Quick Start

### Option 1: Docker (Recommended)

```bash
# 1. Clone the repo
git clone https://github.com/kareem-sabry/BookVerseApi.git
cd BookVerseApi

# 2. Copy the environment template INTO the docker/ folder (compose reads .env from its own directory)
cp .env.example docker/.env
# Edit docker/.env with your Stripe keys, JWT secret, SMTP credentials, etc.
# Also add a line: IMAGE_TAG=latest   (not in .env.example, but docker-compose.yml requires it)

# 3. Start everything from the docker/ folder
cd docker
docker compose up --build
```

| Service | URL | Notes |
|---|---|---|
| **API** | http://localhost:5000 | |
| **Health Check** | http://localhost:5000/health | Detailed JSON: per-component status, duration, timestamp |
| **Swagger UI** | http://localhost:5000 | Only registered when `ASPNETCORE_ENVIRONMENT=Development` |
| SQL Server | localhost:1433 | Data persists in the `sqldata` volume |
| Redis | localhost:6379 | Data persists in the `redisdata` volume |

> ⚠️ The compose file defaults `ASPNETCORE_ENVIRONMENT` to **`Production`**, which means Swagger UI is *not* exposed and CORS is locked to `https://bookverseapi.com` by default. To explore the API interactively via Docker, set `ASPNETCORE_ENVIRONMENT=Development` in `docker/.env` first.

### Option 2: Local Development

**Prerequisites:**
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download)
- SQL Server (Express/Developer/LocalDB all work)
- Redis (optional — see note below)
- A [Stripe](https://stripe.com) test account (free)

`appsettings.json` intentionally ships with **no** connection strings or secrets (only logging config) — everything below must be supplied via `dotnet user-secrets` locally:

```bash
cd src/BookVerse.Api
dotnet user-secrets init

dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=localhost;Database=BookVerseDb;Trusted_Connection=True;TrustServerCertificate=true"
dotnet user-secrets set "ConnectionStrings:Redis" "localhost:6379"

dotnet user-secrets set "JwtOptions:Secret" "a-random-secret-at-least-32-characters-long"
dotnet user-secrets set "JwtOptions:Issuer" "https://localhost:7102"
dotnet user-secrets set "JwtOptions:Audience" "https://localhost:7102"
dotnet user-secrets set "JwtOptions:ExpirationTimeInMinutes" "15"

dotnet user-secrets set "AdminUser:Email" "admin@bookverse.local"
dotnet user-secrets set "AdminUser:Password" "Admin@Dev123!"
dotnet user-secrets set "AdminUser:FirstName" "Admin"
dotnet user-secrets set "AdminUser:LastName" "User"

dotnet user-secrets set "StripeOptions:PublishableKey" "pk_test_your_key"
dotnet user-secrets set "StripeOptions:SecretKey" "sk_test_your_key"
dotnet user-secrets set "StripeOptions:WebhookSecret" "whsec_your_secret"

# Optional — only needed to exercise forgot-password/reset-password emails
dotnet user-secrets set "EmailOptions:SmtpHost" "smtp.gmail.com"
dotnet user-secrets set "EmailOptions:SmtpPort" "587"
dotnet user-secrets set "EmailOptions:SmtpUsername" "your_smtp_username"
dotnet user-secrets set "EmailOptions:SmtpPassword" "your_smtp_password"
dotnet user-secrets set "EmailOptions:FromEmail" "noreply@bookverse.com"
dotnet user-secrets set "EmailOptions:FromName" "BookVerse"
```

> 💡 No local Redis? `RedisCacheService` wraps every call in try/catch and logs a warning on failure instead of throwing — the API still works, it just always falls through to the database (no caching speedup).

```bash
# Apply migrations (run from the repo root)
dotnet ef database update --project src/BookVerse.Infrastructure --startup-project src/BookVerse.Api

# Run the API
dotnet run --project src/BookVerse.Api
```

The API listens on `https://localhost:7102` and `http://localhost:5242` (see `launchSettings.json`). In `Development`, Swagger UI is served at the application root.

---

## 📖 API Reference

All routes are versioned: `api/v{version}/[controller]` — current version is **`1.0`** (also selectable via the `X-Api-Version` header). Examples below use `v1`.

### Authentication — `/api/v1/auth`

| Method | Endpoint | Auth | Rate Limit | Description |
|--------|----------|------|------|-------------|
| `POST` | `/register` | Anonymous | `auth` (5/min/IP) | Register a new account (`Role` must be `User`) |
| `POST` | `/login` | Anonymous | `auth` | Login → JWT access token + refresh token |
| `POST` | `/refresh-token` | Anonymous | — | Rotate refresh token for a new access token |
| `POST` | `/logout` | ✅ Bearer | — | Invalidate the current user's refresh tokens |
| `GET` | `/me` | ✅ Bearer | — | Get your profile |
| `POST` | `/forgot-password` | Anonymous | `auth` | Send a password-reset email |
| `POST` | `/reset-password` | Anonymous | `auth` | Reset password with the emailed token |
| `DELETE` | `/delete-account` | ✅ Bearer | — | Delete your own account |

### Books — `/api/v1/book` *(rate limit: `api`, 50/min/IP)*

| Method | Endpoint | Auth | Description |
|--------|----------|------|-------------|
| `GET` | `/` | Anonymous | Paged, filterable list — response-cached 300s |
| `GET` | `/{id}` | Anonymous | Single book — response-cached 300s **and** Redis-cached 5 min |
| `POST` | `/` | 🔒 Admin | Create a book |
| `PUT` | `/{id}` | 🔒 Admin | Update a book |
| `DELETE` | `/{id}` | 🔒 Admin | Delete a book |

### Authors & Categories — `/api/v1/author` · `/api/v1/category` *(rate limit: `api`)*

Same CRUD pattern as Books, with HTTP response caching (300s) on the `GET` endpoints. `GET` is public; writes require Admin.

### Shopping Cart — `/api/v1/cart` *(all endpoints `[Authorize]`)*

| Method | Endpoint | Description |
|--------|----------|-------------|
| `GET` | `/` | Get the current user's cart |
| `POST` | `/items` | Add a book to the cart |
| `PUT` | `/items/{cartItemId}` | Update a cart item's quantity |
| `DELETE` | `/items/{cartItemId}` | Remove a single cart item |
| `DELETE` | `/clear-cart` | Remove all items from the cart |

### Orders — `/api/v1/order` *(all endpoints `[Authorize]`)*

| Method | Endpoint | Auth | Description |
|--------|----------|------|-------------|
| `POST` | `/` | User | Create an order from the cart (validates stock, deducts it, clears cart — one transaction) |
| `GET` | `/my-orders` | User | Your order history (paginated) |
| `GET` | `/` | 🔒 Admin | All orders (paginated) |
| `GET` | `/{id}` | User (own) / Admin | Order details |
| `PUT` | `/{id}/cancel` | User (own, `Pending`/`Processing` only) | Cancel — restores stock |
| `PUT` | `/{id}/status` | 🔒 Admin | Update order status (forward-only transitions) |
| `PUT` | `/{id}/payment-status` | 🔒 Admin | Update payment status (forward-only transitions) |

### Payments — `/api/v1/payment`

| Method | Endpoint | Auth | Description |
|--------|----------|------|-------------|
| `POST` | `/create-intent/{orderId}` | ✅ Bearer | Create a Stripe PaymentIntent for an order you own |
| `POST` | `/webhook` | Anonymous | Stripe webhook receiver — signature-verified, idempotent |

> 📌 Payment-intent creation lives on `PaymentController`, **not** under `/order/{id}/payment` — that's a common point of confusion if you're integrating against this API.

### Admin — `/api/v1/admin` *(all endpoints `[Authorize(Roles = "Admin")]`)*

| Method | Endpoint | Description |
|--------|----------|-------------|
| `GET` | `/users` | Paginated list of users with their roles |
| `GET` | `/users/{userId}` | Single user with roles |
| `POST` | `/users/{userId}/make-admin` | Promote to Admin (cannot target yourself) |
| `POST` | `/users/{userId}/remove-admin` | Demote to User (cannot target yourself) |
| `DELETE` | `/users/{userId}` | Delete a user account (cannot target yourself) |

---

## 🔎 Query Parameters

```http
# Pagination (PageSize is capped server-side at 100; default is 10)
GET /api/v1/book?pageNumber=1&pageSize=10

# Sorting
GET /api/v1/book?sortBy=Title&sortDescending=false

# Search
GET /api/v1/book?searchTerm=harry+potter

# Book-specific filters
GET /api/v1/book?minPrice=10&maxPrice=50&authorId=1&categoryId=2&publishedAfter=2020-01-01&publishedBefore=2024-01-01
```

---

## 💡 Example Requests

<details>
<summary><strong>1️⃣ Register a new user</strong></summary>

```http
POST /api/v1/auth/register
Content-Type: application/json

{
  "firstName": "John",
  "lastName": "Doe",
  "email": "john.doe@example.com",
  "password": "Password@123",
  "role": 1
}
```

💡 `role`: `1` = User, `2` = Admin — registering as `2` is rejected (admins are seeded/promoted, never self-registered). Password must be 8–100 chars with upper/lower/digit/special character.
</details>

<details>
<summary><strong>2️⃣ Login and get JWT token</strong></summary>

```http
POST /api/v1/auth/login
Content-Type: application/json

{
  "email": "john.doe@example.com",
  "password": "Password@123"
}
```

**Response:** `200 OK`
```json
{
  "succeeded": true,
  "message": "Login successful",
  "accessToken": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "expiresAtUtc": "2026-06-23T15:15:00Z",
  "refreshToken": "abc123..."
}
```

💡 Replaying a refresh token after it's been rotated revokes the whole session — store it securely and don't reuse it.
</details>

<details>
<summary><strong>3️⃣ Create an order from the cart</strong></summary>

```http
POST /api/v1/order
Authorization: Bearer {your_access_token}
Content-Type: application/json

{
  "shippingAddress": "123 Main St, New York, NY 10001",
  "paymentMethod": "Credit Card",
  "notes": "Please deliver between 9 AM - 5 PM"
}
```

💡 There's no item list in the request — the order is built from whatever is currently in your cart. Total is calculated server-side and stock is validated + deducted atomically.
</details>

<details>
<summary><strong>4️⃣ Pay with Stripe</strong></summary>

```http
POST /api/v1/payment/create-intent/123
Authorization: Bearer {your_access_token}
```

**Response:** `200 OK`
```json
{
  "clientSecret": "pi_xxx_secret_yyy",
  "publishableKey": "pk_test_...",
  "orderId": 123,
  "amount": 99.97
}
```

💡 Use `clientSecret` with Stripe.js on the frontend. The webhook updates the order's payment status automatically and idempotently — safe even if Stripe redelivers the same event.
</details>

<details>
<summary><strong>5️⃣ Add a book (Admin only)</strong></summary>

```http
POST /api/v1/book
Authorization: Bearer {admin_token}
Content-Type: application/json

{
  "title": "Clean Code",
  "description": "A Handbook of Agile Software Craftsmanship",
  "isbn": "9780132350884",
  "price": 42.99,
  "publishDate": "2008-08-01",
  "quantityInStock": 50,
  "authorIds": [1],
  "categoryIds": [2, 5]
}
```

💡 At least one author and one category are required; any unknown ID returns `400 Validation Error` instead of a raw FK-constraint `500`.
</details>

---

## 🗄 Database Schema

SQL Server, fully normalized, managed entirely through EF Core migrations.

```
┌──────────────────────────────────────────────────────────────┐
│                        Users (ASP.NET Identity, Guid PK)      │
│  FirstName, LastName, RefreshToken, PreviousRefreshToken,     │
│  RefreshTokenExpiresAtUtc, CreatedAtUtc, UpdatedAtUtc          │
└────┬─────────────────────────────────────────────┬───────────┘
     │ 1:1                                         │ 1:N
┌────▼──────────┐                          ┌───────▼──────────┐
│    Carts      │                          │     Orders        │
│  Id, UserId   │                          │  Id, UserId        │
│               │                          │  OrderNumber (U)    │
│               │                          │  TotalAmount        │
│               │                          │  Status             │
│               │                          │  PaymentStatus       │
│               │                          │  StripePaymentIntentId│
└────┬──────────┘                          └───────┬──────────┘
     │ 1:N                                         │ 1:N
┌────▼──────────┐                          ┌───────▼──────────┐
│  CartItems    │                          │   OrderItems       │
│  CartId,      │                          │  OrderId,           │
│  BookId, Qty  │                          │  BookId, Qty        │
└───────────────┘                          └────────┬─────────┘
                                                     │ N:1
                                              ┌──────▼──────────┐
                                              │     Books         │
                                              │  Id, Title         │
                                              │  Price, ISBN        │
                                              │  QuantityInStock     │
                                              │  RowVersion (concurrency)│
                                              └────┬────────┬────┘
                                                   │ N:M    │ N:M
                                            ┌──────▼──┐  ┌──▼──────┐
                                            │BookAuth │  │BookCat   │
                                            └─────┬───┘  └──┬─────┘
                                                  │        │
                                            ┌─────▼──┐  ┌──▼─────┐
                                            │Authors │  │Categories│
                                            └────────┘  └────────┘
```

Indexed columns include `Order.OrderNumber` (unique), `Order.UserId`, `Order.OrderDate`, `Order.StripePaymentIntentId`, `CartItem.BookId`, `OrderItem.BookId`, and `User.RefreshToken`/`PreviousRefreshToken`.

---

## 🧪 Testing

**76 unit tests** with xUnit, Moq, and FluentAssertions, covering the service layer against mocked repositories/`IUnitOfWork`.

| Service | Tests  |
|---|--------|
| `AccountServiceTests` | 11     |
| `BooksServiceTests` | 12     |
| `CartServiceTests` | 16     |
| `OrderServiceTests` | 29     |
| `PaymentServiceTests` | 8      |
| **Total** | **76** |

### Run Tests

```bash
dotnet test BookVerseApi.sln --verbosity normal

# With code coverage (Cobertura format, collected in CI via coverlet)
dotnet test BookVerseApi.sln --collect:"XPlat Code Coverage"

# A single class
dotnet test --filter "FullyQualifiedName~OrderServiceTests"
```

### What's Covered

- Happy paths and edge cases (not-found, forbidden, conflict, insufficient stock, invalid state transitions)
- Refresh-token rotation **and** the theft-detection/replay scenario
- Stock deduction/restoration math on order creation and cancellation
- Stripe webhook idempotency (already-completed / already-failed / unknown order)
- Transaction begin/commit/rollback verification via `Mock<IUnitOfWork>`

---

## 🔐 Security

| Feature | Details |
|---|---|
| **Password Hashing** | ASP.NET Core Identity (PBKDF2), never stored in plain text |
| **JWT Authentication** | Stateless access tokens + rotating refresh tokens, hashed (SHA-256) at rest |
| **Refresh-Token Theft Detection** | Reusing an already-rotated refresh token revokes both the current and previous token for that user |
| **Account Lockout** | 5 failed login attempts → 15-minute lockout |
| **Role-Based Access** | `[Authorize(Roles = "Admin")]` on sensitive endpoints; admins can't self-promote/demote/delete |
| **Rate Limiting** | Global: 100 req/min per user-or-IP · `auth` policy: 5 req/min/IP · `api` policy: 50 req/min/IP — `429` responses include `Retry-After` |
| **Webhook Verification** | Stripe signature validated via `EventUtility.ConstructEvent`; webhook events are idempotent |
| **SQL Injection Prevention** | EF Core parameterized queries throughout |
| **Security Headers** | `X-Content-Type-Options`, `X-Frame-Options`, `X-XSS-Protection`, `Referrer-Policy`, `Content-Security-Policy` |
| **CORS** | Open in `Development`; locked to a specific origin with credentials in `Production` |
| **Input Validation** | Data annotations on every DTO, validated before hitting the service layer |
| **Error Handling** | Global `IExceptionHandler` → `ProblemDetails` with `traceId`/`timestamp`; stack traces only ever included in `Development` |

> 📖 There's no separate `SECURITY_GUIDE.md` in this repo — everything you need (secrets setup, rate-limit numbers, token model) is covered above and in [Quick Start](#-quick-start).

---

## 🛠 Tech Stack

| Category | Technology |
|---|---|
| **Framework** | ASP.NET Core 8.0 / C# 12 |
| **Database** | SQL Server 2022 + Entity Framework Core 8.0 |
| **Caching** | Redis 7 via `Microsoft.Extensions.Caching.StackExchangeRedis` |
| **Authentication** | JWT Bearer 8.0 + ASP.NET Core Identity |
| **API Versioning** | `Asp.Versioning.Mvc` 8.0.0 (URL segment + `X-Api-Version` header) |
| **Rate Limiting** | Built-in .NET 8 `System.Threading.RateLimiting` |
| **Payments** | Stripe.net 47.4.0 |
| **Mapping** | AutoMapper 16.1.1 (license-key configured) |
| **Testing** | xUnit 2.5.3 + Moq 4.20.72 + FluentAssertions 8.8.0 + EF Core InMemory |
| **CI/CD** | GitHub Actions |
| **Containerization** | Docker + Docker Compose |
| **Documentation** | Swagger / OpenAPI (Development only) |

---

## 📂 Project Structure

```
BookVerseApi/
├── src/
│   ├── BookVerse.Core/            # Domain layer
│   │   ├── Entities/               # User, Book, Order, Cart, etc.
│   │   ├── Enums/                  # OrderStatus, PaymentStatus, Role
│   │   ├── Exceptions/             # NotFoundException, ConflictException, etc.
│   │   ├── Models/                 # JwtOptions, StripeOptions, PagedResult<T>, QueryParameters
│   │   └── Constants/              # ErrorMessages, SuccessMessages, CacheKeys
│   │
│   ├── BookVerse.Application/      # Business contracts layer
│   │   ├── Interfaces/             # IxxxService, IxxxRepository, IUnitOfWork
│   │   └── Dtos/                   # Request/response DTOs per feature area
│   │
│   ├── BookVerse.Infrastructure/   # Data access layer
│   │   ├── Data/                   # AppDbContext, DbInitializer, UnitOfWork
│   │   │   ├── Migrations/         # EF Core migrations
│   │   │   └── Seeds/              # Author/Category/Book seed data
│   │   ├── Repositories/           # EF Core repository implementations
│   │   ├── Services/               # BooksService, OrderService, PaymentService, RedisCacheService, EmailService (SMTP), Stripe services
│   │   └── Profiles/                # AutoMapper MappingProfile
│   │
│   └── BookVerse.Api/              # Presentation layer
│       ├── Controllers/            # Auth, Book, Cart, Order, Payment, Admin, Author, Category
│       ├── Middlewares/            # GlobalExceptionHandler
│       └── Program.cs              # DI, auth, rate limiting, CORS, Swagger, health checks
│
├── tests/BookVerse.Tests/
│   ├── Helpers/                    # TestHelper (UserManager/RoleManager mocking)
│   └── Unit/Services/              # 69 xUnit tests across 5 service classes
│
├── scripts/                        # EF Core helper scripts (⚠️ see Known Issues)
├── docker/
│   ├── Dockerfile                  # Multi-stage build, non-root user
│   └── docker-compose.yml          # API + SQL Server 2022 + Redis 7
│
├── .github/workflows/
│   ├── ci.yml                      # Build + test + coverage on push/PR
│   └── cd.yml                      # Docker build & push to GHCR after CI succeeds on master
│
└── .env.example                    # Environment variable template for docker/.env
```

There is no `BookVerse.Worker` project and no message broker in the current codebase — order-confirmation email is sent directly by `EmailService` over SMTP, synchronously within the request, not via a background queue.

---

## 🚀 Deployment

### CI/CD Pipeline

```
Push / PR  ──▶  CI (ci.yml): restore → build (Release) → run 69 tests → collect coverage
                                                              │
                                            on success, only for pushes to master
                                                              ▼
                                       CD (cd.yml) triggers via workflow_run
                                                              │
                                                              ▼
                                   Build Docker image → push to GHCR
                                   ghcr.io/<owner>/bookverse-api:latest
                                   ghcr.io/<owner>/bookverse-api:<commit-sha>
```

CD does **not** trigger directly on `push` — it listens for the `CI` workflow to finish successfully on `master`, so a broken build or failing test never reaches the registry.

### Deploy to Production

1. **Pull the published image:**
   ```bash
   docker pull ghcr.io/kareem-sabry/bookverse-api:latest
   ```
2. **Configure `docker/.env`** with production secrets (live Stripe keys, a strong `JWT_SECRET`, real SMTP credentials, `SA_PASSWORD`, and `IMAGE_TAG`).
3. **Start the stack** — the same `docker/docker-compose.yml` already defaults `ASPNETCORE_ENVIRONMENT` to `Production`, so no separate production compose file is needed:
   ```bash
   cd docker
   docker compose up -d
   ```

---

## ⚠️ Known Issues / Notes

Documenting these honestly rather than hiding them:

- **`RedisCacheService.RemoveByPrefixAsync` isn't a real prefix scan.** It currently just forwards to `RemoveAsync` for the exact key passed in — there's no Redis key-pattern scan implemented, so bulk invalidation by prefix doesn't actually happen yet.
- **`docker-compose.yml` never sets `ConnectionStrings__Redis`.** The compose file provisions a healthy Redis container and the API `depends_on` it, but the connection string env var is missing from the `api` service. Without it, every Redis call fails (gracefully — `RedisCacheService` logs a warning and falls back to the database), so caching is effectively a no-op when run purely via Docker Compose until `ConnectionStrings__Redis=redis:6379` is added.
- **`.env.example` is missing `IMAGE_TAG`.** `docker-compose.yml`'s `api` service tags its build as `bookverse-api:${IMAGE_TAG}`, but that variable isn't in `.env.example`. Add `IMAGE_TAG=latest` (or a real tag) to `docker/.env` before running `docker compose up --build`.
- **The PowerShell scripts in `/scripts` reference pre-reorg paths.** `add-migration.ps1`, `update-database.ps1`, etc. still point at `./BookVerse.Infrastructure/...` and `./BookVerseApi/BookVerseApi.csproj`, which predate the current `src/BookVerse.Infrastructure` / `src/BookVerse.Api` layout. Use the `dotnet ef` commands in [Quick Start](#-quick-start) instead until these are updated.
- **`appsettings.json` has no defaults.** Only `Logging` and `AllowedHosts` are configured there — every connection string and option (JWT, Stripe, Email, Admin user, Redis) must come from user secrets, `docker/.env`, or another environment-specific source.

---

## 🤝 Contributing

PRs are welcome — see [CONTRIBUTING.md](CONTRIBUTING.md) for the full guide on reporting bugs, proposing features, and the pull-request workflow.

```bash
git checkout -b feat/your-feature
dotnet test BookVerseApi.sln
git commit -m "feat: add your feature description"
git push -u origin feat/your-feature
```

---

## 📄 License

[MIT](LICENSE) — use it for anything, no restrictions needed.

---

## 📬 Contact

**Kareem Sabry**

[![GitHub](https://img.shields.io/badge/GitHub-kareem--sabry-181717?logo=github)](https://github.com/kareem-sabry)
[![LinkedIn](https://img.shields.io/badge/LinkedIn-k--sabry-0A66C2?logo=linkedin)](https://www.linkedin.com/in/k-sabry/)
[![Email](https://img.shields.io/badge/Email-kareemsabry.mail@gmail.com-EA4335?logo=gmail)](mailto:kareemsabry.mail@gmail.com)

---

<div align="center">

**Built with ❤️ using ASP.NET Core 8, Clean Architecture, and a lot of ☕**

If this project helped you learn .NET backend development, consider giving it a ⭐ — it helps others find it too!

</div>
