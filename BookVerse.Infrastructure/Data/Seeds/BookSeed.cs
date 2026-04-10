using BookVerse.Core.Entities;

namespace BookVerse.Infrastructure.Data.Seeds;

public static class BookSeed
{
    public static List<Book> GetBooks()
    {
        var now = DateTime.UtcNow;

        return new List<Book>
        {
            new()
            {
                Id = 1, Title = "1984", Description = "Dystopian novel about surveillance and totalitarianism.",
                ISBN = "9780451524935", Price = 15.99m, PublishDate = new DateOnly(1949, 6, 8), QuantityInStock = 10,
                CreatedAtUtc = now, UpdatedAtUtc = now, CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 2, Title = "Animal Farm", Description = "Allegorical tale reflecting the Russian Revolution.",
                ISBN = "9780451526342", Price = 12.99m, PublishDate = new DateOnly(1945, 8, 17), QuantityInStock = 10,
                CreatedAtUtc = now, UpdatedAtUtc = now, CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 3, Title = "Pride and Prejudice",
                Description = "Classic story of manners, marriage, and social class.", ISBN = "9780141439518",
                Price = 11.99m, PublishDate = new DateOnly(1813, 1, 28), QuantityInStock = 10, CreatedAtUtc = now,
                UpdatedAtUtc = now, CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 4, Title = "Adventures of Huckleberry Finn",
                Description = "Boyhood adventures along the Mississippi River.", ISBN = "9780486280615", Price = 13.50m,
                PublishDate = new DateOnly(1884, 12, 10), QuantityInStock = 10, CreatedAtUtc = now, UpdatedAtUtc = now,
                CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 5, Title = "Crime and Punishment", Description = "Psychological novel about guilt and redemption.",
                ISBN = "9780140449136", Price = 16.75m, PublishDate = new DateOnly(1866, 1, 1), QuantityInStock = 10,
                CreatedAtUtc = now, UpdatedAtUtc = now, CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 6, Title = "The Brothers Karamazov",
                Description = "Philosophical novel exploring faith and morality.", ISBN = "9780374528379",
                Price = 18.99m, PublishDate = new DateOnly(1880, 1, 1), QuantityInStock = 10, CreatedAtUtc = now,
                UpdatedAtUtc = now, CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 7, Title = "War and Peace",
                Description = "Epic tale of history and personal stories during the Napoleonic Wars.",
                ISBN = "9780199232765", Price = 22.50m, PublishDate = new DateOnly(1869, 1, 1), QuantityInStock = 10,
                CreatedAtUtc = now, UpdatedAtUtc = now, CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 8, Title = "Anna Karenina",
                Description = "Tragic story of love, infidelity, and society in Russia.", ISBN = "9780143035008",
                Price = 17.99m, PublishDate = new DateOnly(1878, 1, 1), QuantityInStock = 10, CreatedAtUtc = now,
                UpdatedAtUtc = now, CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 9, Title = "Great Expectations",
                Description = "Coming-of-age story with themes of wealth and social ambition.", ISBN = "9780141439563",
                Price = 14.25m, PublishDate = new DateOnly(1861, 1, 1), QuantityInStock = 10, CreatedAtUtc = now,
                UpdatedAtUtc = now, CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 10, Title = "A Tale of Two Cities",
                Description = "Historical novel set in London and Paris during the French Revolution.",
                ISBN = "9780141439600", Price = 13.99m, PublishDate = new DateOnly(1859, 4, 30), QuantityInStock = 10,
                CreatedAtUtc = now, UpdatedAtUtc = now, CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 11, Title = "The Great Gatsby",
                Description = "Tragic story of wealth, love, and the American Dream.", ISBN = "9780743273565",
                Price = 14.99m, PublishDate = new DateOnly(1925, 4, 10), QuantityInStock = 10, CreatedAtUtc = now,
                UpdatedAtUtc = now, CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 12, Title = "Moby-Dick", Description = "Epic sea adventure and obsession with the white whale.",
                ISBN = "9780142437247", Price = 16.50m, PublishDate = new DateOnly(1851, 10, 18), QuantityInStock = 10,
                CreatedAtUtc = now, UpdatedAtUtc = now, CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 13, Title = "Wuthering Heights",
                Description = "Gothic tale of love and revenge on the Yorkshire moors.", ISBN = "9780141439556",
                Price = 12.75m, PublishDate = new DateOnly(1847, 12, 1), QuantityInStock = 10, CreatedAtUtc = now,
                UpdatedAtUtc = now, CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 14, Title = "Jane Eyre",
                Description = "Story of love, morality, and independence of an orphaned girl.", ISBN = "9780141441146",
                Price = 13.50m, PublishDate = new DateOnly(1847, 10, 16), QuantityInStock = 10, CreatedAtUtc = now,
                UpdatedAtUtc = now, CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 15, Title = "The Lord of the Rings",
                Description = "Epic fantasy saga of Middle-earth and the battle against evil.", ISBN = "9780618640157",
                Price = 29.99m, PublishDate = new DateOnly(1954, 7, 29), QuantityInStock = 10, CreatedAtUtc = now,
                UpdatedAtUtc = now, CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 16, Title = "The Hobbit", Description = "A journey of a hobbit who finds courage and adventure.",
                ISBN = "9780547928227", Price = 18.99m, PublishDate = new DateOnly(1937, 9, 21), QuantityInStock = 10,
                CreatedAtUtc = now, UpdatedAtUtc = now, CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 17, Title = "Harry Potter and the Philosopher's Stone",
                Description = "A young wizard begins his magical journey.", ISBN = "9780747532699", Price = 19.99m,
                PublishDate = new DateOnly(1997, 6, 26), QuantityInStock = 10, CreatedAtUtc = now, UpdatedAtUtc = now,
                CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 18, Title = "Harry Potter and the Chamber of Secrets",
                Description = "Second year at Hogwarts brings new mysteries.", ISBN = "9780747538493", Price = 19.99m,
                PublishDate = new DateOnly(1998, 7, 2), QuantityInStock = 10, CreatedAtUtc = now, UpdatedAtUtc = now,
                CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 19, Title = "The Chronicles of Narnia",
                Description = "Fantasy series where children enter a magical land.", ISBN = "9780066238500",
                Price = 24.99m, PublishDate = new DateOnly(1950, 10, 16), QuantityInStock = 10, CreatedAtUtc = now,
                UpdatedAtUtc = now, CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 20, Title = "Foundation",
                Description = "Science fiction epic about the fall and rise of a galactic empire.",
                ISBN = "9780553293357", Price = 15.99m, PublishDate = new DateOnly(1951, 6, 1), QuantityInStock = 10,
                CreatedAtUtc = now, UpdatedAtUtc = now, CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 21, Title = "I, Robot", Description = "Short stories exploring AI, robots, and ethics.",
                ISBN = "9780553294385", Price = 14.50m, PublishDate = new DateOnly(1950, 12, 2), QuantityInStock = 10,
                CreatedAtUtc = now, UpdatedAtUtc = now, CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 22, Title = "Dune", Description = "Epic sci-fi saga on desert planet and political intrigue.",
                ISBN = "9780441172719", Price = 21.99m, PublishDate = new DateOnly(1965, 8, 1), QuantityInStock = 10,
                CreatedAtUtc = now, UpdatedAtUtc = now, CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 23, Title = "The Hitchhiker's Guide to the Galaxy",
                Description = "Comedy sci-fi adventure across the universe.", ISBN = "9780345391803", Price = 16.99m,
                PublishDate = new DateOnly(1979, 10, 12), QuantityInStock = 10, CreatedAtUtc = now, UpdatedAtUtc = now,
                CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 24, Title = "Fahrenheit 451", Description = "Dystopian novel about censorship and book burning.",
                ISBN = "9781451673319", Price = 14.99m, PublishDate = new DateOnly(1953, 10, 19), QuantityInStock = 10,
                CreatedAtUtc = now, UpdatedAtUtc = now, CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 25, Title = "Brave New World",
                Description = "Futuristic dystopia exploring technology and society.", ISBN = "9780060850524",
                Price = 15.50m, PublishDate = new DateOnly(1932, 1, 1), QuantityInStock = 10, CreatedAtUtc = now,
                UpdatedAtUtc = now, CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 26, Title = "Do Androids Dream of Electric Sheep?",
                Description = "Sci-fi exploring humanity and artificial life.", ISBN = "9780345404473", Price = 14.99m,
                PublishDate = new DateOnly(1968, 1, 1), QuantityInStock = 10, CreatedAtUtc = now, UpdatedAtUtc = now,
                CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 27, Title = "The Left Hand of Darkness",
                Description = "Exploration of gender and politics on a distant planet.", ISBN = "9780441478125",
                Price = 15.99m, PublishDate = new DateOnly(1969, 3, 1), QuantityInStock = 10, CreatedAtUtc = now,
                UpdatedAtUtc = now, CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 28, Title = "One Hundred Years of Solitude",
                Description = "Multi-generational tale blending reality and magic.", ISBN = "9780060883287",
                Price = 17.99m, PublishDate = new DateOnly(1967, 5, 30), QuantityInStock = 10, CreatedAtUtc = now,
                UpdatedAtUtc = now, CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 29, Title = "Norwegian Wood", Description = "Coming-of-age novel exploring love and loss.",
                ISBN = "9780375704024", Price = 16.50m, PublishDate = new DateOnly(1987, 9, 4), QuantityInStock = 10,
                CreatedAtUtc = now, UpdatedAtUtc = now, CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 30, Title = "Kafka on the Shore",
                Description = "Surreal novel exploring fate, consciousness, and mystery.", ISBN = "9781400079278",
                Price = 17.25m, PublishDate = new DateOnly(2002, 9, 12), QuantityInStock = 10, CreatedAtUtc = now,
                UpdatedAtUtc = now, CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 31, Title = "Beloved", Description = "Haunting tale of slavery, memory, and motherhood.",
                ISBN = "9781400033416", Price = 15.99m, PublishDate = new DateOnly(1987, 9, 1), QuantityInStock = 10,
                CreatedAtUtc = now, UpdatedAtUtc = now, CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 32, Title = "The Handmaid's Tale",
                Description = "Dystopian novel about oppression and control of women.", ISBN = "9780385490818",
                Price = 16.99m, PublishDate = new DateOnly(1985, 8, 1), QuantityInStock = 10, CreatedAtUtc = now,
                UpdatedAtUtc = now, CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 33, Title = "The Road", Description = "Post-apocalyptic journey of father and son.",
                ISBN = "9780307387899", Price = 15.50m, PublishDate = new DateOnly(2006, 9, 26), QuantityInStock = 10,
                CreatedAtUtc = now, UpdatedAtUtc = now, CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 34, Title = "Slaughterhouse-Five", Description = "Darkly comic novel about war and time travel.",
                ISBN = "9780440180296", Price = 14.99m, PublishDate = new DateOnly(1969, 3, 31), QuantityInStock = 10,
                CreatedAtUtc = now, UpdatedAtUtc = now, CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 35, Title = "The Shining", Description = "Horror novel about a haunted hotel and psychic powers.",
                ISBN = "9780307743657", Price = 18.99m, PublishDate = new DateOnly(1977, 1, 28), QuantityInStock = 10,
                CreatedAtUtc = now, UpdatedAtUtc = now, CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 36, Title = "Murder on the Orient Express",
                Description = "Detective novel featuring a murder on a train.", ISBN = "9780062693662", Price = 14.50m,
                PublishDate = new DateOnly(1934, 1, 1), QuantityInStock = 10, CreatedAtUtc = now, UpdatedAtUtc = now,
                CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 37, Title = "And Then There Were None",
                Description = "Suspenseful mystery about ten strangers trapped on an island.", ISBN = "9780062073488",
                Price = 13.99m, PublishDate = new DateOnly(1939, 11, 6), QuantityInStock = 10, CreatedAtUtc = now,
                UpdatedAtUtc = now, CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 38, Title = "The Hound of the Baskervilles",
                Description = "Sherlock Holmes investigates a supernatural hound.", ISBN = "9780451528018",
                Price = 12.99m, PublishDate = new DateOnly(1902, 4, 1), QuantityInStock = 10, CreatedAtUtc = now,
                UpdatedAtUtc = now, CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 39, Title = "The Da Vinci Code",
                Description = "Thriller unraveling a conspiracy in the art world.", ISBN = "9780307474278",
                Price = 16.99m, PublishDate = new DateOnly(2003, 3, 18), QuantityInStock = 10, CreatedAtUtc = now,
                UpdatedAtUtc = now, CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 40, Title = "The Stranger", Description = "Existential novel about absurdity and alienation.",
                ISBN = "9780679720201", Price = 13.50m, PublishDate = new DateOnly(1942, 1, 1), QuantityInStock = 10,
                CreatedAtUtc = now, UpdatedAtUtc = now, CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 41, Title = "Man's Search for Meaning",
                Description = "Memoir about surviving the Holocaust and finding purpose.", ISBN = "9780807014295",
                Price = 14.99m, PublishDate = new DateOnly(1946, 1, 1), QuantityInStock = 10, CreatedAtUtc = now,
                UpdatedAtUtc = now, CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 42, Title = "The Art of War", Description = "Ancient treatise on military strategy and tactics.",
                ISBN = "9781590302255", Price = 11.99m, PublishDate = new DateOnly(1910, 1, 1), QuantityInStock = 10,
                CreatedAtUtc = now, UpdatedAtUtc = now, CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 43, Title = "The Old Man and the Sea",
                Description = "Story of an old fisherman's struggle with a giant marlin.", ISBN = "9780684801223",
                Price = 12.99m, PublishDate = new DateOnly(1952, 9, 1), QuantityInStock = 10, CreatedAtUtc = now,
                UpdatedAtUtc = now, CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 44, Title = "For Whom the Bell Tolls", Description = "Novel set during the Spanish Civil War.",
                ISBN = "9780684803357", Price = 15.99m, PublishDate = new DateOnly(1940, 10, 21), QuantityInStock = 10,
                CreatedAtUtc = now, UpdatedAtUtc = now, CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 45, Title = "Mrs Dalloway", Description = "Explores a day in the life of a high-society woman.",
                ISBN = "9780156628709", Price = 13.50m, PublishDate = new DateOnly(1925, 5, 14), QuantityInStock = 10,
                CreatedAtUtc = now, UpdatedAtUtc = now, CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 46, Title = "The Picture of Dorian Gray",
                Description = "Story about vanity, morality, and eternal youth.", ISBN = "9780141439570",
                Price = 12.99m, PublishDate = new DateOnly(1890, 7, 1), QuantityInStock = 10, CreatedAtUtc = now,
                UpdatedAtUtc = now, CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 47, Title = "Lord of the Flies", Description = "Boys stranded on an island descend into savagery.",
                ISBN = "9780399501487", Price = 13.99m, PublishDate = new DateOnly(1954, 9, 17), QuantityInStock = 10,
                CreatedAtUtc = now, UpdatedAtUtc = now, CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 48, Title = "Of Mice and Men",
                Description = "Two displaced ranch workers pursue their American Dream.", ISBN = "9780140177398",
                Price = 11.99m, PublishDate = new DateOnly(1937, 2, 25), QuantityInStock = 10, CreatedAtUtc = now,
                UpdatedAtUtc = now, CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 49, Title = "To Kill a Mockingbird",
                Description = "Story about racial injustice and childhood in the Deep South.", ISBN = "9780061120084",
                Price = 14.99m, PublishDate = new DateOnly(1960, 7, 11), QuantityInStock = 10, CreatedAtUtc = now,
                UpdatedAtUtc = now, CreatedBy = "System", UpdatedBy = "System"
            },
            new()
            {
                Id = 50, Title = "The Catcher in the Rye",
                Description = "Teenager's journey navigating alienation and identity.", ISBN = "9780316769488",
                Price = 13.99m, PublishDate = new DateOnly(1951, 7, 16), QuantityInStock = 10, CreatedAtUtc = now,
                UpdatedAtUtc = now, CreatedBy = "System", UpdatedBy = "System"
            }
        };
    }
}