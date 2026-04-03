<div align="center">

# 📚 BookVerse API

[![CI](https://github.com/kareem-sabry/BookVerseApi/actions/workflows/ci.yml/badge.svg)](https://github.com/kareem-sabry/BookVerseApi/actions/workflows/ci.yml)
[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)
[![EF Core](https://img.shields.io/badge/EF%20Core-8.0-512BD4)](https://learn.microsoft.com/en-us/ef/core/)
[![Stripe](https://img.shields.io/badge/Payments-Stripe-635BFF?logo=stripe)](https://stripe.com)

A production-ready RESTful API for an online bookstore — built with ASP.NET Core 8, Clean Architecture, JWT authentication, and Stripe payments.

[Getting Started](#-getting-started) · [API Reference](#-api-reference) · [Architecture](#-architecture) · [Contributing](#-contributing)

</div>

---

## ✨ Features

| Area | What's included |
|------|----------------|
| **Auth** | JWT + refresh tokens, role-based access (Admin / User), password reset via email |
| **Books** | Full CRUD, search & filtering, pagination, sorting, many-to-many authors & categories |
| **Orders** | Order creation & history, stock management, Stripe payment intent flow |
| **Admin** | User management, role promotion/demotion, account deletion |
| **Security** | Password hashing via ASP.NET Identity, CORS, HTTPS, security headers, XSS protection, parameterized queries |

---

## 🏗 Architecture

Clean Architecture with four clearly separated layers — Core has zero dependencies, each outer layer only depends inward.

```
BookVerse/
├── BookVerse.Core/           # Domain — entities, interfaces, enums
├── BookVerse.Application/    # Business logic — DTOs, service interfaces
├── BookVerse.Infrastructure/ # Data access — EF Core, repositories, services
└── BookVerseApi/             # Presentation — controllers, middleware
```

**Patterns used:** Repository Pattern · Unit of Work · Dependency Injection · AutoMapper · Code First Migrations

---

## 🚀 Getting Started

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download)
- SQL Server (Express is fine)
- A [Stripe](https://stripe.com) test account (free)

### Option 1 — Docker (recommended)

```bash
# 1. Clone the repo
git clone https://github.com/kareem-sabry/BookVerseApi.git
cd BookVerseApi

# 2. Copy the example env file and fill in your values
cp .env.example .env

# 3. Start everything
docker-compose up --build
```

| | URL |
|---|---|
| API | `http://localhost:5000` |
| Swagger UI | `http://localhost:5000/index.html` |

> SQL Server data persists in a Docker volume between restarts.

---

### Option 2 — Local Setup

**1. Configure secrets**

```bash
cd BookVerseApi
dotnet user-secrets init

# Database
dotnet user-secrets set "ConnectionStrings:DefaultConnection" \
  "Server=.;Database=BookVerseDb;Trusted_Connection=True;TrustServerCertificate=True"

# JWT  (secret must be at least 32 characters)
dotnet user-secrets set "JwtOptions:Secret"                  "your-super-secret-key-min-32-chars"
dotnet user-secrets set "JwtOptions:Issuer"                  "BookVerseApi"
dotnet user-secrets set "JwtOptions:Audience"                "BookVerseClient"
dotnet user-secrets set "JwtOptions:ExpirationTimeInMinutes" "60"

# Default admin (change before deploying to production)
dotnet user-secrets set "AdminUser:Email"     "admin@bookverse.com"
dotnet user-secrets set "AdminUser:Password"  "Admin@123456"
dotnet user-secrets set "AdminUser:FirstName" "Admin"
dotnet user-secrets set "AdminUser:LastName"  "User"

# Stripe (from your Stripe dashboard)
dotnet user-secrets set "Stripe:PublishableKey" "pk_test_your_key"
dotnet user-secrets set "Stripe:SecretKey"      "sk_test_your_key"

# Email / SMTP (optional — only needed for password reset)
dotnet user-secrets set "EmailOptions:SmtpHost"     "smtp.gmail.com"
dotnet user-secrets set "EmailOptions:SmtpPort"     "587"
dotnet user-secrets set "EmailOptions:SmtpUsername" "your-email@gmail.com"
dotnet user-secrets set "EmailOptions:SmtpPassword" "your-app-password"
dotnet user-secrets set "EmailOptions:FromEmail"    "noreply@bookverse.com"
dotnet user-secrets set "EmailOptions:FromName"     "BookVerse"
```

> **Gmail users:** generate an [App Password](https://support.google.com/accounts/answer/185833) — your regular password won't work when 2FA is enabled.

**2. Apply migrations**

```bash
dotnet ef database update --project ../BookVerse.Infrastructure --startup-project .
```

If `dotnet ef` isn't found:
```bash
dotnet tool install --global dotnet-ef
```

**3. Run**

```bash
dotnet run
```

The API starts at `https://localhost:7xxx/`. Open that URL to see the Swagger UI.

---

## 📖 API Reference

> Most `GET` endpoints are public. `POST` / `PUT` / `DELETE` require authentication unless noted.

### Authentication — `/api/auth`

| Method | Endpoint | Auth | Description |
|--------|----------|------|-------------|
| `POST` | `/register` | — | Create a new account |
| `POST` | `/login` | — | Login, returns JWT + refresh token |
| `POST` | `/refresh-token` | — | Exchange refresh token for a new access token |
| `POST` | `/logout` | ✅ | Logout |
| `GET` | `/me` | ✅ | Get your profile |
| `POST` | `/forgot-password` | — | Request a password reset email |
| `POST` | `/reset-password` | — | Reset password with emailed token |
| `DELETE` | `/delete-account` | ✅ | Delete your account |

### Books — `/api/book`

| Method | Endpoint | Auth | Description |
|--------|----------|------|-------------|
| `GET` | `/` | — | List books (paginated, filterable) |
| `GET` | `/{id}` | — | Get a single book |
| `POST` | `/` | 🔒 Admin | Add a book |
| `PUT` | `/{id}` | 🔒 Admin | Update a book |
| `DELETE` | `/{id}` | 🔒 Admin | Delete a book |

### Authors — `/api/author` · Categories — `/api/category`

Same CRUD shape as Books. `GET` endpoints are public; write operations require Admin.

### Orders — `/api/order`

| Method | Endpoint | Auth | Description |
|--------|----------|------|-------------|
| `POST` | `/` | ✅ | Create an order |
| `GET` | `/{id}` | ✅ | Get order details |
| `GET` | `/my-orders` | ✅ | Your order history |
| `POST` | `/{id}/payment` | ✅ | Create a Stripe payment intent |

### Admin — `/api/admin` *(Admin role required)*

| Method | Endpoint | Description |
|--------|----------|-------------|
| `GET` | `/users` | List all users |
| `GET` | `/users/{id}` | Get user details |
| `POST` | `/users/{id}/make-admin` | Promote to Admin |
| `POST` | `/users/{id}/remove-admin` | Demote to User |
| `DELETE` | `/users/{id}` | Delete a user |

---

## 🔎 Query Parameters

All list endpoints support a consistent set of query parameters:

```
# Pagination
?pageNumber=1&pageSize=10

# Sorting
?sortBy=Title&sortDescending=false

# Search
?searchTerm=harry+potter

# Book-specific filters
?minPrice=10&maxPrice=50&authorId=1&categoryId=2&publishedAfter=2020-01-01
```

> Recommended max `pageSize` is 100 to avoid performance issues.

---

## 💡 Example Requests

<details>
<summary><strong>Register a new user</strong></summary>

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
`role`: `1` = User, `2` = Admin. Password must include uppercase, lowercase, number, and special character.
</details>

<details>
<summary><strong>Login</strong></summary>

```http
POST /api/auth/login
Content-Type: application/json

{
  "email": "john.doe@example.com",
  "password": "Password@123"
}
```
Returns an access token and refresh token. Store them securely — avoid `localStorage`.
</details>

<details>
<summary><strong>Create an order</strong></summary>

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
Order total is calculated server-side. Use `POST /api/order/{id}/payment` afterwards to charge the customer via Stripe.
</details>

<details>
<summary><strong>Add a book (Admin only)</strong></summary>

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
Author and category IDs must already exist, otherwise you'll get a validation error.
</details>

---

## 🗄 Database Schema

```
Users (ASP.NET Identity)
│
├── Orders ──── OrderItems ──── Books
│                                 │
│                            BookAuthors ──── Authors
│                            BookCategories ── Categories
```

Standard normalized schema — EF Core handles all joins.

---

## 🔐 Security

- Passwords hashed with ASP.NET Core Identity (bcrypt-based, never stored plain)
- Stateless JWT authentication with refresh token rotation
- Role-based authorization on all sensitive endpoints
- CORS and HTTPS enforced
- Security headers middleware
- EF Core parameterized queries (SQL injection safe)
- XSS protection enabled
- Input validation on all DTOs

> For production deployments, a dedicated security review is recommended.

---

## 🛠 Tech Stack

| | Technology |
|---|---|
| Framework | ASP.NET Core 8.0 / C# 12 |
| Database | SQL Server + Entity Framework Core 8 |
| Auth | JWT Bearer + ASP.NET Core Identity |
| Payments | Stripe API |
| Mapping | AutoMapper |
| Docs | Swagger / OpenAPI |

---

## 🤝 Contributing

PRs are welcome! Please follow the existing code patterns and include tests for new functionality. For bugs, open an issue with steps to reproduce.

---

## 📄 License

[MIT](LICENSE) — do whatever you want with it.

---

## 📬 Contact

**Kareem Sabry**

[![GitHub](https://img.shields.io/badge/GitHub-kareem--sabry-181717?logo=github)](https://github.com/kareem-sabry)
[![LinkedIn](https://img.shields.io/badge/LinkedIn-k--sabry-0A66C2?logo=linkedin)](https://www.linkedin.com/in/k-sabry/)
[![Email](https://img.shields.io/badge/Email-kareemsabry.mail@gmail.com-EA4335?logo=gmail)](mailto:kareemsabry.mail@gmail.com)

---

<div align="center">
  If this was useful, consider giving it a ⭐ — it helps others find it too.
</div>