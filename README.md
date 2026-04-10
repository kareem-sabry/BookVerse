<div align="center">

# 📚 BookVerse API

[![CI](https://github.com/kareem-sabry/BookVerseApi/actions/workflows/ci.yml/badge.svg)](https://github.com/kareem-sabry/BookVerseApi/actions/workflows/ci.yml)
[![CD](https://github.com/kareem-sabry/BookVerseApi/actions/workflows/cd.yml/badge.svg)](https://github.com/kareem-sabry/BookVerseApi/actions/workflows/cd.yml)
[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)
[![Tests](https://img.shields.io/badge/Tests-71%20Passing-2ea44f)](https://github.com/kareem-sabry/BookVerseApi/actions)
[![Coverage](https://img.shields.io/badge/Coverage-45%25-orange)](https://github.com/kareem-sabry/BookVerseApi/actions)
[![Docker](https://img.shields.io/badge/Docker-Ready-2496ED?logo=docker)](https://hub.docker.com/)
[![Stripe](https://img.shields.io/badge/Payments-Stripe-635BFF?logo=stripe)](https://stripe.com)

**A production-ready RESTful API for an online bookstore** — built with ASP.NET Core 8, Clean Architecture, JWT authentication, Stripe payments, and automated CI/CD.

[🌐 Live Demo](#-live-demo) · [🚀 Quick Start](#-quick-start) · [📖 API Reference](#-api-reference) · [🏗 Architecture](#-architecture) · [🧪 Testing](#-testing) · [📮 Postman Collection](#-postman-collection)

</div>

---

## 🌐 Live Demo

> **🚧 Coming Soon** — This API is being deployed to a live environment. Check back for the public URL!

Once deployed, you'll be able to:
- **Swagger UI:** Explore all endpoints interactively
- **Test Payments:** Use Stripe test cards (no real money)
- **Full API:** Register, browse books, place orders, and more

---

## ✨ Features

| Area | What's Included |
|------|----------------|
| **🔐 Authentication** | JWT + refresh tokens, role-based access (Admin/User), password reset via email |
| **📚 Books** | Full CRUD, search & filtering, pagination, sorting, many-to-many authors & categories |
| **🛒 Shopping Cart** | Add/update/remove items, server-side total calculation, stock validation |
| **📦 Orders** | Order creation & history, stock management, Stripe payment intent flow |
| **💳 Payments** | Stripe integration with webhook handling, signature verification, idempotent operations |
| **👤 Admin** | User management, role promotion/demotion, account deletion |
| **🔒 Security** | Password hashing (ASP.NET Identity), CORS, HTTPS, security headers, XSS protection, parameterized queries |
| **🐳 Docker** | Multi-stage builds, non-root user, health checks, docker-compose for dev & production |
| **🚀 CI/CD** | Automated testing on PR, Docker image builds, push to GitHub Container Registry |

---

## 🏗 Architecture

**Clean Architecture** with four clearly separated layers — Core has zero dependencies, each outer layer only depends inward.

```
┌─────────────────────────────────────────────────────────────┐
│                      BookVerse.Api                          │
│                Controllers, Middleware, Program.cs           │
│                   (Presentation Layer)                      │
└────────────────────────┬────────────────────────────────────┘
                         │ depends on
┌────────────────────────▼────────────────────────────────────┐
│               BookVerse.Infrastructure                       │
│         EF Core, Repositories, Services, Stripe              │
│                   (Data Access Layer)                        │
└────────────────────────┬────────────────────────────────────┘
                         │ depends on
┌────────────────────────▼────────────────────────────────────┐
│               BookVerse.Application                          │
│           DTOs, Service Interfaces, IUnitOfWork              │
│                  (Business Logic Layer)                      │
└────────────────────────┬────────────────────────────────────┘
                         │ depends on
┌────────────────────────▼────────────────────────────────────┐
│                  BookVerse.Core                              │
│         Entities, Interfaces, Enums, Exceptions              │
│                    (Domain Layer)                            │
│                                                             │
│                   ⚡ ZERO External Dependencies              │
└─────────────────────────────────────────────────────────────┘
```

### Design Patterns

| Pattern | Purpose |
|---|---|
| **Repository Pattern** | Abstracts data access behind interfaces |
| **Unit of Work** | Ensures atomic operations across multiple repositories |
| **Dependency Injection** | Loose coupling, testability, SOLID principles |
| **AutoMapper** | Clean separation between domain models and DTOs |
| **Options Pattern** | Type-safe configuration with validation |
| **Global Exception Handling** | Consistent error responses, no stack traces leaked |

### Key Architectural Decisions

- **Domain-Driven Design:** Entities encapsulate business rules, services orchestrate workflows
- **Stripe.net isolated to Infrastructure:** Core and Application layers have zero Stripe dependencies
- **Webhook signature verification:** Security-first approach — never skip verification, even in test mode
- **Audit fields centralized:** `CreatedAtUtc`, `UpdatedAtUtc` set only in `AppDbContext`, never in services
- **CancellationToken throughout:** Every async method supports cancellation for responsive APIs

---

## 🚀 Quick Start

### Option 1: Docker (Recommended — 2 minutes)

```bash
# 1. Clone the repo
git clone https://github.com/kareem-sabry/BookVerseApi.git
cd BookVerseApi

# 2. Copy environment file and fill in your values
cp .env.example .env
# Edit .env with your Stripe keys, JWT secret, etc.

# 3. Start everything
docker-compose up --build
```

| Service | URL |
|---|---|
| **API** | http://localhost:5000 |
| **Swagger UI** | http://localhost:5000/swagger |
| **Health Check** | http://localhost:5000/health |

> SQL Server data persists in a Docker volume between restarts.

---

### Option 2: Local Development

**Prerequisites:**
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download)
- SQL Server (Express is fine)
- [Stripe](https://stripe.com) test account (free)

```bash
# 1. Configure secrets
cd BookVerse.Api
dotnet user-secrets init
dotnet user-secrets set "StripeOptions:PublishableKey" "pk_test_your_key"
dotnet user-secrets set "StripeOptions:SecretKey" "sk_test_your_key"
dotnet user-secrets set "StripeOptions:WebhookSecret" "whsec_your_secret"
# ... see full setup in SECURITY_GUIDE.md

# 2. Apply migrations
dotnet ef database update --project ../BookVerse.Infrastructure

# 3. Run
dotnet run
```

> 📖 **Full setup guide:** See [SECURITY_GUIDE.md](SECURITY_GUIDE.md) for secrets management, key generation, and production deployment.

---

## 📖 API Reference

> Most `GET` endpoints are public. `POST` / `PUT` / `DELETE` require authentication unless noted.

### Authentication — `/api/auth`

| Method | Endpoint | Auth | Description |
|--------|----------|------|-------------|
| `POST` | `/register` | — | Create a new account |
| `POST` | `/login` | — | Login, returns JWT + refresh token |
| `POST` | `/refresh-token` | — | Exchange refresh token for new access token |
| `POST` | `/logout` | ✅ | Invalidate refresh token |
| `GET` | `/me` | ✅ | Get your profile |
| `POST` | `/forgot-password` | — | Request password reset email |
| `POST` | `/reset-password` | — | Reset password with emailed token |
| `DELETE` | `/delete-account` | ✅ | Delete your account |

### Books — `/api/book`

| Method | Endpoint | Auth | Description |
|--------|----------|------|-------------|
| `GET` | `/` | — | List books (paginated, filterable) |
| `GET` | `/{id}` | — | Get a single book by ID |
| `POST` | `/` | 🔒 Admin | Add a new book |
| `PUT` | `/{id}` | 🔒 Admin | Update a book |
| `DELETE` | `/{id}` | 🔒 Admin | Delete a book |

### Authors & Categories — `/api/author` · `/api/category`

Same CRUD pattern as Books. `GET` endpoints are public; write operations require Admin role.

### Orders — `/api/order`

| Method | Endpoint | Auth | Description |
|--------|----------|------|-------------|
| `POST` | `/` | ✅ | Create an order from cart |
| `GET` | `/{id}` | ✅ | Get order details |
| `GET` | `/my-orders` | ✅ | Your order history (paginated) |
| `POST` | `/{id}/payment` | ✅ | Create Stripe payment intent |

### Payments — `/api/payment`

| Method | Endpoint | Auth | Description |
|--------|----------|------|-------------|
| `POST` | `/create-intent/{orderId}` | ✅ | Create Stripe PaymentIntent |
| `POST` | `/webhook` | — | Handle Stripe webhook events |

### Admin — `/api/admin` *(Admin role required)*

| Method | Endpoint | Description |
|--------|----------|-------------|
| `GET` | `/users` | List all users (paginated) |
| `GET` | `/users/{id}` | Get user details with orders |
| `POST` | `/users/{id}/make-admin` | Promote user to Admin role |
| `POST` | `/users/{id}/remove-admin` | Demote to User role |
| `DELETE` | `/users/{id}` | Delete a user account |

---

## 🔎 Query Parameters

All list endpoints support consistent query parameters:

```http
# Pagination
GET /api/book?pageNumber=1&pageSize=10

# Sorting
GET /api/book?sortBy=Title&sortDescending=false

# Search
GET /api/book?searchTerm=harry+potter

# Book-specific filters
GET /api/book?minPrice=10&maxPrice=50&authorId=1&categoryId=2&publishedAfter=2020-01-01
```

> 💡 Recommended max `pageSize` is 100 to avoid performance issues.

---

## 💡 Example Requests

<details>
<summary><strong>1️⃣ Register a new user</strong></summary>

```http
POST /api/auth/register
Content-Type: application/json

{
  "firstName": "John",
  "lastName": "Doe",
  "email": "john.doe@example.com",
  "password": "Password@123",
  "role": 1
}
```

**Response:** `201 Created` with user profile  
💡 `role`: `1` = User, `2` = Admin. Password requires uppercase, lowercase, number, special character.
</details>

<details>
<summary><strong>2️⃣ Login and get JWT token</strong></summary>

```http
POST /api/auth/login
Content-Type: application/json

{
  "email": "john.doe@example.com",
  "password": "Password@123"
}
```

**Response:** `200 OK`
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "refreshToken": "abc123...",
  "expiresAt": "2025-01-01T00:15:00Z"
}
```

💡 Store tokens securely — avoid `localStorage` in browsers (prefer httpOnly cookies).
</details>

<details>
<summary><strong>3️⃣ Create an order</strong></summary>

```http
POST /api/order
Authorization: Bearer {your_access_token}
Content-Type: application/json

{
  "items": [
    { "bookId": 1, "quantity": 2 },
    { "bookId": 3, "quantity": 1 }
  ]
}
```

**Response:** `201 Created` with order details  
💡 Order total is calculated server-side. Stock is validated and decremented.
</details>

<details>
<summary><strong>4️⃣ Pay with Stripe</strong></summary>

```http
POST /api/payment/create-intent/123
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

💡 Use `clientSecret` with Stripe.js on the frontend to complete payment. Webhook updates order status automatically.
</details>

<details>
<summary><strong>5️⃣ Add a book (Admin only)</strong></summary>

```http
POST /api/book
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

**Response:** `201 Created`  
💡 Author and category IDs must exist, otherwise returns `400 Validation Error`.
</details>

---

## 🗄 Database Schema

```
┌──────────────────────────────────────────────────────────────┐
│                        Users                                │
│  (ASP.NET Identity — Guid PK)                               │
│  FirstName, LastName, RefreshToken, RefreshTokenExpiresAt    │
└────┬─────────────────────────────────────────────┬───────────┘
     │ 1:N                                         │ 1:N
     │                                             │
┌────▼──────────┐                          ┌───────▼──────────┐
│    Carts      │                          │     Orders       │
│  Id, UserId   │                          │  Id, UserId      │
│               │                          │  OrderNumber (U) │
│               │                          │  TotalAmount     │
│               │                          │  Status          │
│               │                          │  PaymentStatus   │
│               │                          │  StripePaymentId │
└────┬──────────┘                          └───────┬──────────┘
     │ 1:N                                         │ 1:N
     │                                             │
┌────▼──────────┐                          ┌───────▼──────────┐
│  CartItems    │                          │   OrderItems     │
│  CartId,      │                          │  OrderId,        │
│  BookId, Qty  │                          │  BookId, Qty    │
└───────────────┘                          └────────┬─────────┘
                                                   │ N:1
                                            ┌──────▼──────────┐
                                            │     Books       │
                                            │  Id, Title      │
                                            │  Price, ISBN    │
                                            │  QuantityInStock│
                                            └────┬────────┬───┘
                                                 │ N:M    │ N:M
                                          ┌──────▼──┐  ┌──▼──────┐
                                          │BookAuth │  │BookCat  │
                                          └─────┬───┘  └──┬─────┘
                                                │        │
                                          ┌─────▼──┐  ┌──▼─────┐
                                          │Authors │  │Categories│
                                          └────────┘  └────────┘
```

> Fully normalized to 3NF — EF Core handles all joins with navigation properties.

---

## 🧪 Testing

**71 unit tests passing** with xUnit, Moq, and FluentAssertions.

### Test Coverage by Service

| Service | Tests | Status |
|---|---|---|
| AccountService | ✅ | 15 tests |
| BooksService | ✅ | 18 tests |
| CartService | ✅ | 12 tests |
| OrderService | ✅ | 14 tests |
| PaymentService | ✅ | 12 tests |
| **Total** | **71** | **✅ All Passing** |

### Run Tests

```bash
# All tests
dotnet test BookVerseApi.sln --verbosity normal

# With code coverage
dotnet test BookVerseApi.sln --collect:"XPlat Code Coverage"

# Specific test
dotnet test --filter "FullyQualifiedName~PaymentServiceTests"
```

### Test Quality

- **Mock external dependencies:** Stripe API, email service, logger
- **Edge cases covered:** Not found, forbidden, invalid state, race conditions
- **CancellationToken propagation:** Verified in all tests
- **Exception messages:** Validated with FluentAssertions

---

## 📮 Postman Collection

A complete Postman collection is included for easy API testing and exploration.

### Import Collection

1. Open Postman
2. Click **Import**
3. Select `BookVerse.postman_collection.json`
4. Collection appears in Postman sidebar

### Use Collection

1. **Set environment variables:**
    - `base_url`: Your API URL (default: `http://localhost:5000/api`)
    - `access_token`: Auto-set after login
    - `admin_token`: Set after admin login

2. **Run requests in order:**
    - Register User → Login (token auto-saved) → Get Profile → Browse Books → Create Order → Payment

3. **Test admin endpoints:**
    - Login as admin → Update `admin_token` variable → Run Admin folder requests

### Collection Features

- ✅ **Auto-save tokens:** Login request automatically saves access & refresh tokens to variables
- ✅ **Pre-configured auth:** Bearer token authentication set on all protected requests
- ✅ **Example payloads:** Realistic data for all request bodies
- ✅ **Organized folders:** Auth, Books, Orders, Admin separated logically

---

## 🔐 Security

### Implemented

| Feature | Details |
|---|---|
| **Password Hashing** | ASP.NET Core Identity (PBKDF2, never stored plain text) |
| **JWT Authentication** | Stateless tokens with refresh rotation |
| **Role-Based Access** | `[Authorize(Roles = "Admin")]` on sensitive endpoints |
| **Webhook Verification** | Stripe signature validation with `EventUtility.ConstructEvent` |
| **SQL Injection Prevention** | EF Core parameterized queries |
| **XSS Protection** | Security headers middleware |
| **CORS** | Configurable per-environment policies |
| **Input Validation** | Data annotations on all DTOs |
| **Error Handling** | Global exception handler — no stack traces leaked |

### Best Practices

- **Secrets management:** Environment variables in production, `secrets.json` (gitignored) for local dev
- **Non-root Docker user:** Improved container security
- **Stripe test mode:** No real money charged until live keys are configured
- **Rate limiting:** Configurable per-endpoint limits

> 📖 **Full security guide:** See [SECURITY_GUIDE.md](SECURITY_GUIDE.md) for key generation, production deployment, and secret rotation.

---

## 🛠 Tech Stack

| Category | Technology |
|---|---|
| **Framework** | ASP.NET Core 8.0 / C# 12 |
| **Database** | SQL Server 2022 + Entity Framework Core 8 |
| **Authentication** | JWT Bearer + ASP.NET Core Identity |
| **Payments** | Stripe.net 47.4 |
| **Mapping** | AutoMapper 16.1 |
| **Testing** | xUnit + Moq + FluentAssertions |
| **CI/CD** | GitHub Actions |
| **Containerization** | Docker + Docker Compose |
| **Documentation** | Swagger / OpenAPI |

---

## 📂 Project Structure

```
BookVerseApi/
├── BookVerse.Core/              # Domain layer (zero dependencies)
│   ├── Entities/                # User, Book, Order, etc.
│   ├── Enums/                   # OrderStatus, PaymentStatus, Role
│   ├── Exceptions/              # NotFoundException, ConflictException, etc.
│   ├── Models/                  # JwtOptions, StripeOptions, PagedResult<T>
│   └── Constants/               # ErrorMessages, SuccessMessages
│
├── BookVerse.Application/       # Business logic layer
│   ├── Interfaces/              # IService, IRepository, IUnitOfWork
│   └── Dtos/                    # Request/response DTOs
│
├── BookVerse.Infrastructure/    # Data access layer
│   ├── Data/                    # AppDbContext, UnitOfWork, Migrations
│   ├── Repositories/            # EF Core repository implementations
│   ├── Services/                # StripePaymentService, EmailService, etc.
│   └── Profiles/                # AutoMapper MappingProfile
│
├── BookVerse.Api/               # Presentation layer
│   ├── Controllers/             # REST endpoints
│   ├── Middlewares/             # GlobalExceptionHandler, etc.
│   └── Program.cs               # DI, configuration, middleware setup
│
├── BookVerse.Tests/             # Unit tests
│   └── Unit/Services/           # Service layer tests
│
├── .github/workflows/           # CI/CD pipelines
│   ├── ci.yml                   # Build + test on push/PR
│   └── cd.yml                   # Docker build + push to GHCR
│
├── Dockerfile                   # Multi-stage Docker build
├── docker-compose.yml           # Development environment
├── docker-compose.production.yml# Production environment
└── .env.example                 # Environment variable template
```

---

## 🚀 Deployment

### CI/CD Pipeline

```
┌─────────────┐     ┌──────────────┐     ┌───────────────┐     ┌──────────────┐
│  Push to    │────▶│  Build &     │────▶│  Run 71       │────▶│  Build Docker│
│  master     │     │  .NET App    │     │  Unit Tests   │     │  Image       │
└─────────────┘     └──────────────┘     └───────────────┘     └──────┬───────┘
                                                                      │
                                                           ┌──────────▼───────┐
                                                           │  Push to GHCR    │
                                                           │  ghcr.io/kareem- │
                                                           │  sabry/bookverse │
                                                           └──────────────────┘
```

### Deploy to Production

1. **Pull image from GHCR:**
   ```bash
   docker pull ghcr.io/kareem-sabry/bookverse-api:latest
   ```

2. **Create `.env` with production values:**
   ```bash
   cp .env.example .env
   # Fill in Stripe live keys, JWT secret, database password, etc.
   ```

3. **Start with production compose:**
   ```bash
   docker-compose -f docker-compose.production.yml up -d
   ```

> 📖 **Full deployment guide:** See [PROJECT_STATUS.md](PROJECT_STATUS.md) for checklist, monitoring setup, and troubleshooting.

---

## 🤝 Contributing

PRs are welcome! Here's how to contribute:

1. **Fork the repo** and create your branch from `master`
2. **Follow existing patterns** — check `_claude_map.md` for established conventions
3. **Add tests** for new functionality
4. **Ensure CI passes** — all tests must pass, no warnings allowed
5. **Submit a PR** with clear description and testing notes

### Development Workflow

```bash
# Create feature branch
git checkout -b feat/your-feature

# Make changes, run tests
dotnet test BookVerseApi.sln

# Commit with conventional message
git commit -m "feat: add your feature description"

# Push and create PR
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
