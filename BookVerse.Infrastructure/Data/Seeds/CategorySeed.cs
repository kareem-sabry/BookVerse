using BookVerse.Core.Entities;

namespace BookVerse.Infrastructure.Data.Seeds;

public static class CategorySeed
{
    public static List<Category> GetCategories()
    {
        var now = DateTime.UtcNow;
        return new List<Category>
        {
            new()
            {
                Id = 1, Name = "Classic Literature", CreatedAtUtc = now, UpdatedAtUtc = now, CreatedBy = "System",
                UpdatedBy = "System"
            },
            new()
            {
                Id = 2, Name = "Fantasy", CreatedAtUtc = now, UpdatedAtUtc = now, CreatedBy = "System",
                UpdatedBy = "System"
            },
            new()
            {
                Id = 3, Name = "Science Fiction", CreatedAtUtc = now, UpdatedAtUtc = now, CreatedBy = "System",
                UpdatedBy = "System"
            },
            new()
            {
                Id = 4, Name = "Dystopian", CreatedAtUtc = now, UpdatedAtUtc = now, CreatedBy = "System",
                UpdatedBy = "System"
            },
            new()
            {
                Id = 5, Name = "Adventure", CreatedAtUtc = now, UpdatedAtUtc = now, CreatedBy = "System",
                UpdatedBy = "System"
            },
            new()
            {
                Id = 6, Name = "Mystery", CreatedAtUtc = now, UpdatedAtUtc = now, CreatedBy = "System",
                UpdatedBy = "System"
            },
            new()
            {
                Id = 7, Name = "Thriller", CreatedAtUtc = now, UpdatedAtUtc = now, CreatedBy = "System",
                UpdatedBy = "System"
            },
            new()
            {
                Id = 8, Name = "Romance", CreatedAtUtc = now, UpdatedAtUtc = now, CreatedBy = "System",
                UpdatedBy = "System"
            },
            new()
            {
                Id = 9, Name = "Historical Fiction", CreatedAtUtc = now, UpdatedAtUtc = now, CreatedBy = "System",
                UpdatedBy = "System"
            },
            new()
            {
                Id = 10, Name = "Philosophy", CreatedAtUtc = now, UpdatedAtUtc = now, CreatedBy = "System",
                UpdatedBy = "System"
            },
            new()
            {
                Id = 11, Name = "Horror", CreatedAtUtc = now, UpdatedAtUtc = now, CreatedBy = "System",
                UpdatedBy = "System"
            },
            new()
            {
                Id = 12, Name = "Coming of Age", CreatedAtUtc = now, UpdatedAtUtc = now, CreatedBy = "System",
                UpdatedBy = "System"
            },
            new()
            {
                Id = 13, Name = "Literary Fiction", CreatedAtUtc = now, UpdatedAtUtc = now, CreatedBy = "System",
                UpdatedBy = "System"
            },
            new()
            {
                Id = 14, Name = "Psychological Fiction", CreatedAtUtc = now, UpdatedAtUtc = now, CreatedBy = "System",
                UpdatedBy = "System"
            },
            new()
            {
                Id = 15, Name = "Magical Realism", CreatedAtUtc = now, UpdatedAtUtc = now, CreatedBy = "System",
                UpdatedBy = "System"
            }
        };
    }
}