using BookVerse.Core.Entities;

namespace BookVerse.Infrastructure.Data.Seeds;

public static class AuthorSeed
{
    public static List<Author> GetAuthors()
    {
        var now = DateTime.UtcNow;
        return new List<Author>
        {
            // Classic Literature
            new()
            {
                Id = 1, FirstName = "George", LastName = "Orwell", CreatedAtUtc = now, UpdatedAtUtc = now,
                CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 2, FirstName = "Jane", LastName = "Austen", CreatedAtUtc = now, UpdatedAtUtc = now,
                CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 3, FirstName = "Mark", LastName = "Twain", CreatedAtUtc = now, UpdatedAtUtc = now,
                CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 4, FirstName = "Fyodor", LastName = "Dostoevsky", CreatedAtUtc = now, UpdatedAtUtc = now,
                CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 5, FirstName = "Leo", LastName = "Tolstoy", CreatedAtUtc = now, UpdatedAtUtc = now,
                CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 6, FirstName = "Charles", LastName = "Dickens", CreatedAtUtc = now, UpdatedAtUtc = now,
                CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 7, FirstName = "F. Scott", LastName = "Fitzgerald", CreatedAtUtc = now, UpdatedAtUtc = now,
                CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 8, FirstName = "Herman", LastName = "Melville", CreatedAtUtc = now, UpdatedAtUtc = now,
                CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 9, FirstName = "Emily", LastName = "Brontë", CreatedAtUtc = now, UpdatedAtUtc = now,
                CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 10, FirstName = "Charlotte", LastName = "Brontë", CreatedAtUtc = now, UpdatedAtUtc = now,
                CreatedBy = "System", UpdatedBy = "System"
            },

            // Fantasy & Science Fiction
            new()
            {
                Id = 11, FirstName = "J.R.R.", LastName = "Tolkien", CreatedAtUtc = now, UpdatedAtUtc = now,
                CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 12, FirstName = "J.K.", LastName = "Rowling", CreatedAtUtc = now, UpdatedAtUtc = now,
                CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 13, FirstName = "Isaac", LastName = "Asimov", CreatedAtUtc = now, UpdatedAtUtc = now,
                CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 14, FirstName = "Frank", LastName = "Herbert", CreatedAtUtc = now, UpdatedAtUtc = now,
                CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 15, FirstName = "Douglas", LastName = "Adams", CreatedAtUtc = now, UpdatedAtUtc = now,
                CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 16, FirstName = "C.S.", LastName = "Lewis", CreatedAtUtc = now, UpdatedAtUtc = now,
                CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 17, FirstName = "Ray", LastName = "Bradbury", CreatedAtUtc = now, UpdatedAtUtc = now,
                CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 18, FirstName = "Aldous", LastName = "Huxley", CreatedAtUtc = now, UpdatedAtUtc = now,
                CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 19, FirstName = "Philip K.", LastName = "Dick", CreatedAtUtc = now, UpdatedAtUtc = now,
                CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 20, FirstName = "Ursula K.", LastName = "Le Guin", CreatedAtUtc = now, UpdatedAtUtc = now,
                CreatedBy = "System", UpdatedBy = "System"
            },

            // Modern Fiction
            new()
            {
                Id = 21, FirstName = "Gabriel García", LastName = "Márquez", CreatedAtUtc = now, UpdatedAtUtc = now,
                CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 22, FirstName = "Haruki", LastName = "Murakami", CreatedAtUtc = now, UpdatedAtUtc = now,
                CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 23, FirstName = "Toni", LastName = "Morrison", CreatedAtUtc = now, UpdatedAtUtc = now,
                CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 24, FirstName = "Margaret", LastName = "Atwood", CreatedAtUtc = now, UpdatedAtUtc = now,
                CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 25, FirstName = "Cormac", LastName = "McCarthy", CreatedAtUtc = now, UpdatedAtUtc = now,
                CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 26, FirstName = "Kurt", LastName = "Vonnegut", CreatedAtUtc = now, UpdatedAtUtc = now,
                CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 27, FirstName = "Stephen", LastName = "King", CreatedAtUtc = now, UpdatedAtUtc = now,
                CreatedBy = "System", UpdatedBy = "System"
            },

            // Mystery & Thriller
            new()
            {
                Id = 28, FirstName = "Agatha", LastName = "Christie", CreatedAtUtc = now, UpdatedAtUtc = now,
                CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 29, FirstName = "Arthur Conan", LastName = "Doyle", CreatedAtUtc = now, UpdatedAtUtc = now,
                CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 30, FirstName = "Dan", LastName = "Brown", CreatedAtUtc = now, UpdatedAtUtc = now,
                CreatedBy = "System", UpdatedBy = "System"
            },

            // Philosophy & Non-Fiction
            new()
            {
                Id = 31, FirstName = "Albert", LastName = "Camus", CreatedAtUtc = now, UpdatedAtUtc = now,
                CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 32, FirstName = "Viktor", LastName = "Frankl", CreatedAtUtc = now, UpdatedAtUtc = now,
                CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 33, FirstName = "Sun", LastName = "Tzu", CreatedAtUtc = now, UpdatedAtUtc = now,
                CreatedBy = "System", UpdatedBy = "System"
            },

            // Additional Authors
            new()
            {
                Id = 34, FirstName = "Ernest", LastName = "Hemingway", CreatedAtUtc = now, UpdatedAtUtc = now,
                CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 35, FirstName = "Virginia", LastName = "Woolf", CreatedAtUtc = now, UpdatedAtUtc = now,
                CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 36, FirstName = "Oscar", LastName = "Wilde", CreatedAtUtc = now, UpdatedAtUtc = now,
                CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 37, FirstName = "William", LastName = "Golding", CreatedAtUtc = now, UpdatedAtUtc = now,
                CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 38, FirstName = "John", LastName = "Steinbeck", CreatedAtUtc = now, UpdatedAtUtc = now,
                CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 39, FirstName = "Harper", LastName = "Lee", CreatedAtUtc = now, UpdatedAtUtc = now,
                CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 40, FirstName = "J.D.", LastName = "Salinger", CreatedAtUtc = now, UpdatedAtUtc = now,
                CreatedBy = "System", UpdatedBy = "System"
            }
        };
    }
}