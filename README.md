# BookVerse API
[![CI](https://github.com/kareem-sabry/BookVerseApi/actions/workflows/ci.yml/badge.svg)](https://github.com/kareem-sabry/BookVerseApi/actions/workflows/ci.yml)
A RESTful API for an online bookstore built with ASP.NET Core 8. Includes JWT authentication, role-based authorization, and Stripe payment integration.

## About

This is a backend system I built for managing an online bookstore. The architecture follows clean architecture principles - using repository pattern, unit of work, dependency injection, all that good stuff. I wanted something that wouldn't turn into a mess as it grows, so I spent some time getting the foundation right.

The project handles everything you'd expect from a bookstore API: user accounts, browsing books, managing inventory, and processing payments through Stripe. It's fairly complete but there's always room for improvement.

## What it does

**User Authentication**
- JWT tokens with refresh token support
- Role-based permissions (Admin and User roles)
- Password hashing through ASP.NET Core Identity
- Password reset via email
- Token refresh when they expire

**Managing Books**
- Full CRUD for books, authors, and categories
- Search and filtering (by price, author, category, publication date)
- Pagination because nobody wants to load 10,000 books at once
- Books can have multiple authors and categories (many-to-many relationships)
- Stock tracking for inventory management

**Payments**
- Stripe integration for handling payments
- Order creation and tracking
- Payment status updates
- Stock automatically decreases when orders go through
- Users can view their order history

**Architecture stuff**
- Clean Architecture (Core, Application, Infrastructure, API layers)
- Repository Pattern for data access
- Unit of Work for managing transactions
- AutoMapper for DTOs
- Entity Framework Core with Code First migrations

## Tech Stack

Built with:
- ASP.NET Core 8.0
- C# 12.0
- SQL Server with Entity Framework Core
- JWT Bearer tokens + ASP.NET Core Identity
- Stripe API
- Swagger/OpenAPI for documentation
- AutoMapper

## Project Layout

```
BookVerse/
├── BookVerse.Core/              # Domain layer - entities, interfaces
│   ├── Entities/
│   ├── Interfaces/
│   ├── Enums/
│   ├── Constants/
│   └── Models/
├── BookVerse.Application/       # Application layer - business logic, DTOs
│   ├── Dtos/
│   └── Interfaces/
├── BookVerse.Infrastructure/    # Infrastructure - data access, external services
│   ├── Data/
│   ├── Repositories/
│   ├── Services/
│   └── Profiles/
└── BookVerseApi/                # Presentation layer - controllers, middleware
    ├── Controllers/
    └── Middlewares/
```

Pretty standard clean architecture setup. Core has no dependencies, Application depends on Core, Infrastructure implements interfaces from Core/Application, and the API layer ties everything together.

## Getting it Running

### What you need

- .NET 8.0 SDK
- SQL Server (Express works fine if you don't have the full version)
- A Stripe account (free test account works)
- Git

### Setup Instructions

## Quick start (Docker)
```bash
git clone https://github.com/kareem-sabry/BookVerseApi.git
cd BookVerseApi
docker-compose up --build
```

API: `http://localhost:5000` | Swagger: `http://localhost:5000/index.html`

SQL Server data persists in a Docker volume across restarts.

Now for the configuration. I'm using user secrets for sensitive data instead of putting it in appsettings.json (please don't commit your secrets to GitHub):

```bash
cd BookVerseApi
dotnet user-secrets init

# Database connection - adjust this for your SQL Server setup
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=.;Database=BookVerseDb;Trusted_Connection=True;TrustServerCertificate=True"

# JWT settings - make sure the secret is at least 32 characters
dotnet user-secrets set "JwtOptions:Secret" "your-super-secret-key-min-32-characters-long"
dotnet user-secrets set "JwtOptions:Issuer" "BookVerseApi"
dotnet user-secrets set "JwtOptions:Audience" "BookVerseClient"
dotnet user-secrets set "JwtOptions:ExpirationTimeInMinutes" "60"

# Default admin user - change these before deploying to production
dotnet user-secrets set "AdminUser:Email" "admin@bookverse.com"
dotnet user-secrets set "AdminUser:Password" "Admin@123456"
dotnet user-secrets set "AdminUser:FirstName" "Admin"
dotnet user-secrets set "AdminUser:LastName" "User"

# Stripe keys - get these from your Stripe dashboard
dotnet user-secrets set "Stripe:PublishableKey" "pk_test_your_key"
dotnet user-secrets set "Stripe:SecretKey" "sk_test_your_key"

# Email settings (optional, only needed for password resets)
dotnet user-secrets set "EmailOptions:SmtpHost" "smtp.gmail.com"
dotnet user-secrets set "EmailOptions:SmtpPort" "587"
dotnet user-secrets set "EmailOptions:SmtpUsername" "your-email@gmail.com"
dotnet user-secrets set "EmailOptions:SmtpPassword" "your-app-password"
dotnet user-secrets set "EmailOptions:FromEmail" "noreply@bookverse.com"
dotnet user-secrets set "EmailOptions:FromName" "BookVerse"
```

Note: If you're using Gmail for SMTP, you'll need to generate an app password. Regular password won't work with 2FA enabled.

Run the migrations to create the database:
```bash
dotnet ef database update --project ../BookVerse.Infrastructure --startup-project .
```

If that command fails, make sure you have the EF Core tools installed:
```bash
dotnet tool install --global dotnet-ef
```

Start the application:
```bash
dotnet run
```

The API should start up at `https://localhost:7xxx/` (the port might be different). Navigate there and you'll see the Swagger UI with all the endpoints.

## API Reference

Here's what's available. Most GET endpoints don't require authentication, but POST/PUT/DELETE usually do.

### Authentication

- `POST /api/auth/register` - Create a new account
- `POST /api/auth/login` - Login and get JWT token
- `POST /api/auth/refresh-token` - Get a new access token using refresh token
- `POST /api/auth/logout` - Logout (requires auth)
- `GET /api/auth/me` - Get your user profile (requires auth)
- `POST /api/auth/forgot-password` - Request a password reset email
- `POST /api/auth/reset-password` - Reset password using the token from email
- `DELETE /api/auth/delete-account` - Delete your account (requires auth)

### Books

- `GET /api/book` - List books with pagination
- `GET /api/book/{id}` - Get a specific book
- `POST /api/book` - Add a new book (admin only)
- `PUT /api/book/{id}` - Update book details (admin only)
- `DELETE /api/book/{id}` - Remove a book (admin only)

### Authors

- `GET /api/author` - List authors with pagination
- `GET /api/author/{id}` - Get author details
- `POST /api/author` - Add a new author (admin only)
- `PUT /api/author/{id}` - Update author (admin only)
- `DELETE /api/author/{id}` - Remove author (admin only)

### Categories

- `GET /api/category` - List all categories
- `GET /api/category/{id}` - Get category details
- `POST /api/category` - Add category (admin only)
- `PUT /api/category/{id}` - Update category (admin only)
- `DELETE /api/category/{id}` - Remove category (admin only)

### Orders

- `POST /api/order` - Create a new order (requires auth)
- `GET /api/order/{id}` - Get order details (requires auth)
- `GET /api/order/my-orders` - List your order history (requires auth)
- `POST /api/order/{id}/payment` - Create Stripe payment intent (requires auth)

### Admin Operations

These all require admin role:
- `GET /api/admin/users` - List all users
- `GET /api/admin/users/{id}` - Get user details
- `POST /api/admin/users/{id}/make-admin` - Promote user to admin
- `POST /api/admin/users/{id}/remove-admin` - Remove admin role from user
- `DELETE /api/admin/users/{id}` - Delete a user account

## Query Parameters

Most list endpoints support these query parameters. Mix and match as needed:

**Pagination:**
```
?pageNumber=1&pageSize=10
```
Default page size is 10, but you can adjust it. I'd recommend keeping it under 100 to avoid performance issues.

**Sorting:**
```
?sortBy=Title&sortDescending=false
```
You can sort by most properties. Check the Swagger docs to see what's available for each endpoint.

**Searching:**
```
?searchTerm=harry+potter
```
Searches across relevant fields (title, description, etc.)

**Filtering (Books):**
```
?minPrice=10&maxPrice=50&authorId=1&categoryId=2&publishedAfter=2020-01-01
```
All filters are optional. Combine them however you want.

## Example Usage

Here are some common request examples. Check Swagger for the complete schemas.

**Register a new user:**
```json
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

The password needs to meet the default Identity requirements (uppercase, lowercase, number, special char). Role 1 is User, role 2 is Admin.

**Login:**
```json
POST /api/auth/login
Content-Type: application/json

{
  "email": "john.doe@example.com",
  "password": "Password@123"
}
```

This returns an access token and a refresh token. Store both securely (not in localStorage if you can help it).

**Create an order:**
```json
POST /api/order
Authorization: Bearer {your_access_token}
Content-Type: application/json

{
  "items": [
    {
      "bookId": 1,
      "quantity": 2
    },
    {
      "bookId": 3,
      "quantity": 1
    }
  ]
}
```

The order total gets calculated server-side based on current book prices. After creating the order, use the payment endpoint to actually charge the customer.

**Add a book (admin only):**
```json
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

Make sure the author and category IDs actually exist, or you'll get a validation error.

## Security Notes

I've tried to implement security best practices:

- Passwords are hashed using ASP.NET Core Identity (never stored in plain text)
- JWT tokens for stateless authentication
- Refresh tokens stored separately (you could move these to Redis in production)
- Role-based authorization throughout
- CORS properly configured
- HTTPS enforced
- Security headers middleware
- Input validation on all DTOs
- EF Core uses parameterized queries (no SQL injection risk)
- XSS protection enabled

That said, if you're deploying this to production, you should probably get a security review. I'm not a security expert.

## Database Structure

The database uses ASP.NET Identity tables for user management. On top of that:

Main tables:
- **Users** - from ASP.NET Identity
- **Books** - book catalog
- **Authors** - author information
- **Categories** - book categories
- **Orders** - customer orders
- **OrderItems** - individual items in orders

Junction tables for many-to-many:
- **BookAuthors** - links books to authors
- **BookCategories** - links books to categories

Pretty straightforward normalized schema. EF Core handles the joins.

## Contributing

If you want to contribute, go ahead and open a PR. I'm happy to review any improvements, bug fixes, or new features. Just make sure the code follows the existing patterns and includes tests if you're adding new functionality.

Also, if you find bugs, please open an issue with steps to reproduce.

## License

MIT License - do whatever you want with it. See the LICENSE file for the legal stuff.

## Contact

Kareem Sabry

- GitHub: [@kareem-sabry](https://github.com/kareem-sabry)
- LinkedIn: [k-sabry](https://www.linkedin.com/in/k-sabry/)
- Email: kareemsabry.mail@gmail.com

Feel free to reach out if you have questions or just want to chat about the project.

## Acknowledgments

Built with help from:
- ASP.NET Core documentation
- Stripe API docs
- Clean Architecture patterns from Robert C. Martin
- Various Stack Overflow answers when I got stuck

---

If this project was useful to you, consider giving it a star. Helps others find it too.