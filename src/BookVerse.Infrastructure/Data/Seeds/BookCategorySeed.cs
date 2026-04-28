using BookVerse.Core.Entities;

namespace BookVerse.Infrastructure.Data.Seeds;

public static class BookCategorySeed
{
    public static List<BookCategory> GetBookCategories()
    {
        var now = DateTime.UtcNow;
        return new List<BookCategory>
        {
            // 1984 - Dystopian, Science Fiction, Classic
            new() { BookId = 1, CategoryId = 4, CreatedAtUtc = now },
            new() { BookId = 1, CategoryId = 3, CreatedAtUtc = now },
            new() { BookId = 1, CategoryId = 1, CreatedAtUtc = now },

            // Animal Farm - Dystopian, Classic
            new() { BookId = 2, CategoryId = 4, CreatedAtUtc = now },
            new() { BookId = 2, CategoryId = 1, CreatedAtUtc = now },

            // Pride and Prejudice - Classic, Romance
            new() { BookId = 3, CategoryId = 1, CreatedAtUtc = now },
            new() { BookId = 3, CategoryId = 8, CreatedAtUtc = now },

            // Huckleberry Finn - Classic, Adventure
            new() { BookId = 4, CategoryId = 1, CreatedAtUtc = now },
            new() { BookId = 4, CategoryId = 5, CreatedAtUtc = now },

            // Crime and Punishment - Classic, Psychological Fiction
            new() { BookId = 5, CategoryId = 1, CreatedAtUtc = now },
            new() { BookId = 5, CategoryId = 14, CreatedAtUtc = now },
            new() { BookId = 5, CategoryId = 10, CreatedAtUtc = now },

            // The Brothers Karamazov - Classic, Philosophy
            new() { BookId = 6, CategoryId = 1, CreatedAtUtc = now },
            new() { BookId = 6, CategoryId = 10, CreatedAtUtc = now },
            new() { BookId = 6, CategoryId = 14, CreatedAtUtc = now },

            // War and Peace - Classic, Historical Fiction
            new() { BookId = 7, CategoryId = 1, CreatedAtUtc = now },
            new() { BookId = 7, CategoryId = 9, CreatedAtUtc = now },

            // Anna Karenina - Classic, Romance
            new() { BookId = 8, CategoryId = 1, CreatedAtUtc = now },
            new() { BookId = 8, CategoryId = 8, CreatedAtUtc = now },
            new() { BookId = 8, CategoryId = 13, CreatedAtUtc = now },

            // Great Expectations - Classic, Coming of Age
            new() { BookId = 9, CategoryId = 1, CreatedAtUtc = now },
            new() { BookId = 9, CategoryId = 12, CreatedAtUtc = now },

            // A Tale of Two Cities - Classic, Historical Fiction
            new() { BookId = 10, CategoryId = 1, CreatedAtUtc = now },
            new() { BookId = 10, CategoryId = 9, CreatedAtUtc = now },

            // The Great Gatsby - Classic, Literary Fiction
            new() { BookId = 11, CategoryId = 1, CreatedAtUtc = now },
            new() { BookId = 11, CategoryId = 13, CreatedAtUtc = now },

            // Moby-Dick - Classic, Adventure
            new() { BookId = 12, CategoryId = 1, CreatedAtUtc = now },
            new() { BookId = 12, CategoryId = 5, CreatedAtUtc = now },

            // Wuthering Heights - Classic, Romance, Gothic
            new() { BookId = 13, CategoryId = 1, CreatedAtUtc = now },
            new() { BookId = 13, CategoryId = 8, CreatedAtUtc = now },
            new() { BookId = 13, CategoryId = 11, CreatedAtUtc = now },

            // Jane Eyre - Classic, Romance, Coming of Age
            new() { BookId = 14, CategoryId = 1, CreatedAtUtc = now },
            new() { BookId = 14, CategoryId = 8, CreatedAtUtc = now },
            new() { BookId = 14, CategoryId = 12, CreatedAtUtc = now },

            // The Lord of the Rings - Fantasy, Adventure
            new() { BookId = 15, CategoryId = 2, CreatedAtUtc = now },
            new() { BookId = 15, CategoryId = 5, CreatedAtUtc = now },

            // The Hobbit - Fantasy, Adventure
            new() { BookId = 16, CategoryId = 2, CreatedAtUtc = now },
            new() { BookId = 16, CategoryId = 5, CreatedAtUtc = now },

            // Harry Potter 1 - Fantasy, Coming of Age
            new() { BookId = 17, CategoryId = 2, CreatedAtUtc = now },
            new() { BookId = 17, CategoryId = 12, CreatedAtUtc = now },

            // Harry Potter 2 - Fantasy, Coming of Age
            new() { BookId = 18, CategoryId = 2, CreatedAtUtc = now },
            new() { BookId = 18, CategoryId = 12, CreatedAtUtc = now },

            // Chronicles of Narnia - Fantasy, Adventure
            new() { BookId = 19, CategoryId = 2, CreatedAtUtc = now },
            new() { BookId = 19, CategoryId = 5, CreatedAtUtc = now },

            // Foundation - Science Fiction
            new() { BookId = 20, CategoryId = 3, CreatedAtUtc = now },

            // I, Robot - Science Fiction
            new() { BookId = 21, CategoryId = 3, CreatedAtUtc = now },

            // Dune - Science Fiction, Adventure
            new() { BookId = 22, CategoryId = 3, CreatedAtUtc = now },
            new() { BookId = 22, CategoryId = 5, CreatedAtUtc = now },

            // Hitchhiker's Guide - Science Fiction
            new() { BookId = 23, CategoryId = 3, CreatedAtUtc = now },

            // Fahrenheit 451 - Science Fiction, Dystopian
            new() { BookId = 24, CategoryId = 3, CreatedAtUtc = now },
            new() { BookId = 24, CategoryId = 4, CreatedAtUtc = now },

            // Brave New World - Science Fiction, Dystopian
            new() { BookId = 25, CategoryId = 3, CreatedAtUtc = now },
            new() { BookId = 25, CategoryId = 4, CreatedAtUtc = now },
            new() { BookId = 25, CategoryId = 1, CreatedAtUtc = now },

            // Do Androids Dream - Science Fiction
            new() { BookId = 26, CategoryId = 3, CreatedAtUtc = now },

            // The Left Hand of Darkness - Science Fiction
            new() { BookId = 27, CategoryId = 3, CreatedAtUtc = now },

            // One Hundred Years of Solitude - Magical Realism, Literary Fiction
            new() { BookId = 28, CategoryId = 15, CreatedAtUtc = now },
            new() { BookId = 28, CategoryId = 13, CreatedAtUtc = now },

            // Norwegian Wood - Literary Fiction, Romance
            new() { BookId = 29, CategoryId = 13, CreatedAtUtc = now },
            new() { BookId = 29, CategoryId = 8, CreatedAtUtc = now },
            new() { BookId = 29, CategoryId = 12, CreatedAtUtc = now },

            // Kafka on the Shore - Magical Realism, Literary Fiction
            new() { BookId = 30, CategoryId = 15, CreatedAtUtc = now },
            new() { BookId = 30, CategoryId = 13, CreatedAtUtc = now },

            // Beloved - Literary Fiction, Historical Fiction, Horror
            new() { BookId = 31, CategoryId = 13, CreatedAtUtc = now },
            new() { BookId = 31, CategoryId = 9, CreatedAtUtc = now },
            new() { BookId = 31, CategoryId = 11, CreatedAtUtc = now },

            // The Handmaid's Tale - Dystopian, Science Fiction
            new() { BookId = 32, CategoryId = 4, CreatedAtUtc = now },
            new() { BookId = 32, CategoryId = 3, CreatedAtUtc = now },

            // The Road - Dystopian, Literary Fiction
            new() { BookId = 33, CategoryId = 4, CreatedAtUtc = now },
            new() { BookId = 33, CategoryId = 13, CreatedAtUtc = now },

            // Slaughterhouse-Five - Science Fiction, Literary Fiction
            new() { BookId = 34, CategoryId = 3, CreatedAtUtc = now },
            new() { BookId = 34, CategoryId = 13, CreatedAtUtc = now },

            // The Shining - Horror, Psychological Fiction
            new() { BookId = 35, CategoryId = 11, CreatedAtUtc = now },
            new() { BookId = 35, CategoryId = 14, CreatedAtUtc = now },

            // Murder on the Orient Express - Mystery
            new() { BookId = 36, CategoryId = 6, CreatedAtUtc = now },

            // And Then There Were None - Mystery, Thriller
            new() { BookId = 37, CategoryId = 6, CreatedAtUtc = now },
            new() { BookId = 37, CategoryId = 7, CreatedAtUtc = now },

            // The Hound of the Baskervilles - Mystery, Classic
            new() { BookId = 38, CategoryId = 6, CreatedAtUtc = now },
            new() { BookId = 38, CategoryId = 1, CreatedAtUtc = now },

            // The Da Vinci Code - Mystery, Thriller
            new() { BookId = 39, CategoryId = 6, CreatedAtUtc = now },
            new() { BookId = 39, CategoryId = 7, CreatedAtUtc = now },

            // The Stranger - Philosophy, Classic
            new() { BookId = 40, CategoryId = 10, CreatedAtUtc = now },
            new() { BookId = 40, CategoryId = 1, CreatedAtUtc = now },

            // Man's Search for Meaning - Philosophy
            new() { BookId = 41, CategoryId = 10, CreatedAtUtc = now },

            // The Art of War - Philosophy
            new() { BookId = 42, CategoryId = 10, CreatedAtUtc = now },

            // The Old Man and the Sea - Classic, Literary Fiction
            new() { BookId = 43, CategoryId = 1, CreatedAtUtc = now },
            new() { BookId = 43, CategoryId = 13, CreatedAtUtc = now },

            // For Whom the Bell Tolls - Classic, Historical Fiction
            new() { BookId = 44, CategoryId = 1, CreatedAtUtc = now },
            new() { BookId = 44, CategoryId = 9, CreatedAtUtc = now },

            // Mrs Dalloway - Classic, Literary Fiction
            new() { BookId = 45, CategoryId = 1, CreatedAtUtc = now },
            new() { BookId = 45, CategoryId = 13, CreatedAtUtc = now },

            // The Picture of Dorian Gray - Classic, Horror, Philosophy
            new() { BookId = 46, CategoryId = 1, CreatedAtUtc = now },
            new() { BookId = 46, CategoryId = 11, CreatedAtUtc = now },
            new() { BookId = 46, CategoryId = 10, CreatedAtUtc = now },

            // Lord of the Flies - Classic, Adventure, Psychological Fiction
            new() { BookId = 47, CategoryId = 1, CreatedAtUtc = now },
            new() { BookId = 47, CategoryId = 5, CreatedAtUtc = now },
            new() { BookId = 47, CategoryId = 14, CreatedAtUtc = now },

            // Of Mice and Men - Classic, Literary Fiction
            new() { BookId = 48, CategoryId = 1, CreatedAtUtc = now },
            new() { BookId = 48, CategoryId = 13, CreatedAtUtc = now },

            // To Kill a Mockingbird - Classic, Coming of Age
            new() { BookId = 49, CategoryId = 1, CreatedAtUtc = now },
            new() { BookId = 49, CategoryId = 12, CreatedAtUtc = now },

            // The Catcher in the Rye - Classic, Coming of Age
            new() { BookId = 50, CategoryId = 1, CreatedAtUtc = now },
            new() { BookId = 50, CategoryId = 12, CreatedAtUtc = now }
        };
    }
}