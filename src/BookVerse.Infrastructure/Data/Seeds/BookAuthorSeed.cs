using BookVerse.Core.Entities;

namespace BookVerse.Infrastructure.Data.Seeds;

public static class BookAuthorSeed
{
    public static List<BookAuthor> GetBookAuthors()
    {
        var now = DateTime.UtcNow;
        return new List<BookAuthor>
        {
            // George Orwell
            new() { BookId = 1, AuthorId = 1, CreatedAtUtc = now }, // 1984
            new() { BookId = 2, AuthorId = 1, CreatedAtUtc = now }, // Animal Farm

            // Jane Austen
            new() { BookId = 3, AuthorId = 2, CreatedAtUtc = now }, // Pride and Prejudice

            // Mark Twain
            new() { BookId = 4, AuthorId = 3, CreatedAtUtc = now }, // Huckleberry Finn

            // Fyodor Dostoevsky
            new() { BookId = 5, AuthorId = 4, CreatedAtUtc = now }, // Crime and Punishment
            new() { BookId = 6, AuthorId = 4, CreatedAtUtc = now }, // The Brothers Karamazov

            // Leo Tolstoy
            new() { BookId = 7, AuthorId = 5, CreatedAtUtc = now }, // War and Peace
            new() { BookId = 8, AuthorId = 5, CreatedAtUtc = now }, // Anna Karenina

            // Charles Dickens
            new() { BookId = 9, AuthorId = 6, CreatedAtUtc = now }, // Great Expectations
            new() { BookId = 10, AuthorId = 6, CreatedAtUtc = now }, // A Tale of Two Cities

            // F. Scott Fitzgerald
            new() { BookId = 11, AuthorId = 7, CreatedAtUtc = now }, // The Great Gatsby

            // Herman Melville
            new() { BookId = 12, AuthorId = 8, CreatedAtUtc = now }, // Moby-Dick

            // Emily Brontë
            new() { BookId = 13, AuthorId = 9, CreatedAtUtc = now }, // Wuthering Heights

            // Charlotte Brontë
            new() { BookId = 14, AuthorId = 10, CreatedAtUtc = now }, // Jane Eyre

            // J.R.R. Tolkien
            new() { BookId = 15, AuthorId = 11, CreatedAtUtc = now }, // The Lord of the Rings
            new() { BookId = 16, AuthorId = 11, CreatedAtUtc = now }, // The Hobbit

            // J.K. Rowling
            new() { BookId = 17, AuthorId = 12, CreatedAtUtc = now }, // Harry Potter 1
            new() { BookId = 18, AuthorId = 12, CreatedAtUtc = now }, // Harry Potter 2

            // C.S. Lewis
            new() { BookId = 19, AuthorId = 16, CreatedAtUtc = now }, // Chronicles of Narnia

            // Isaac Asimov
            new() { BookId = 20, AuthorId = 13, CreatedAtUtc = now }, // Foundation
            new() { BookId = 21, AuthorId = 13, CreatedAtUtc = now }, // I, Robot

            // Frank Herbert
            new() { BookId = 22, AuthorId = 14, CreatedAtUtc = now }, // Dune

            // Douglas Adams
            new() { BookId = 23, AuthorId = 15, CreatedAtUtc = now }, // Hitchhiker's Guide

            // Ray Bradbury
            new() { BookId = 24, AuthorId = 17, CreatedAtUtc = now }, // Fahrenheit 451

            // Aldous Huxley
            new() { BookId = 25, AuthorId = 18, CreatedAtUtc = now }, // Brave New World

            // Philip K. Dick
            new() { BookId = 26, AuthorId = 19, CreatedAtUtc = now }, // Do Androids Dream

            // Ursula K. Le Guin
            new() { BookId = 27, AuthorId = 20, CreatedAtUtc = now }, // The Left Hand of Darkness

            // Gabriel García Márquez
            new() { BookId = 28, AuthorId = 21, CreatedAtUtc = now }, // One Hundred Years of Solitude

            // Haruki Murakami
            new() { BookId = 29, AuthorId = 22, CreatedAtUtc = now }, // Norwegian Wood
            new() { BookId = 30, AuthorId = 22, CreatedAtUtc = now }, // Kafka on the Shore

            // Toni Morrison
            new() { BookId = 31, AuthorId = 23, CreatedAtUtc = now }, // Beloved

            // Margaret Atwood
            new() { BookId = 32, AuthorId = 24, CreatedAtUtc = now }, // The Handmaid's Tale

            // Cormac McCarthy
            new() { BookId = 33, AuthorId = 25, CreatedAtUtc = now }, // The Road

            // Kurt Vonnegut
            new() { BookId = 34, AuthorId = 26, CreatedAtUtc = now }, // Slaughterhouse-Five

            // Stephen King
            new() { BookId = 35, AuthorId = 27, CreatedAtUtc = now }, // The Shining

            // Agatha Christie
            new() { BookId = 36, AuthorId = 28, CreatedAtUtc = now }, // Murder on the Orient Express
            new() { BookId = 37, AuthorId = 28, CreatedAtUtc = now }, // And Then There Were None

            // Arthur Conan Doyle
            new() { BookId = 38, AuthorId = 29, CreatedAtUtc = now }, // The Hound of the Baskervilles

            // Dan Brown
            new() { BookId = 39, AuthorId = 30, CreatedAtUtc = now }, // The Da Vinci Code

            // Albert Camus
            new() { BookId = 40, AuthorId = 31, CreatedAtUtc = now }, // The Stranger

            // Viktor Frankl
            new() { BookId = 41, AuthorId = 32, CreatedAtUtc = now }, // Man's Search for Meaning

            // Sun Tzu
            new() { BookId = 42, AuthorId = 33, CreatedAtUtc = now }, // The Art of War

            // Ernest Hemingway
            new() { BookId = 43, AuthorId = 34, CreatedAtUtc = now }, // The Old Man and the Sea
            new() { BookId = 44, AuthorId = 34, CreatedAtUtc = now }, // For Whom the Bell Tolls

            // Virginia Woolf
            new() { BookId = 45, AuthorId = 35, CreatedAtUtc = now }, // Mrs Dalloway

            // Oscar Wilde
            new() { BookId = 46, AuthorId = 36, CreatedAtUtc = now }, // The Picture of Dorian Gray

            // William Golding
            new() { BookId = 47, AuthorId = 37, CreatedAtUtc = now }, // Lord of the Flies

            // John Steinbeck
            new() { BookId = 48, AuthorId = 38, CreatedAtUtc = now }, // Of Mice and Men

            // Harper Lee
            new() { BookId = 49, AuthorId = 39, CreatedAtUtc = now }, // To Kill a Mockingbird

            // J.D. Salinger
            new() { BookId = 50, AuthorId = 40, CreatedAtUtc = now } // The Catcher in the Rye
        };
    }
}