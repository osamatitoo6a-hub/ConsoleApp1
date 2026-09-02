using System;
using System.Collections.Generic;

namespace LibrarySystem
{
    internal class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsAvailable { get; set; }

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
            IsAvailable = true;
        }
    }

    internal class Program
    {
        static List<Book> books = new List<Book>();
        static bool hasLibraryCard = false;

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=================================");
            Console.WriteLine(" Welcome to Library Management");
            Console.WriteLine("=================================");

            Console.Write("Enter 'u' for User or 'l' for Librarian: ");
            string role = Console.ReadLine().ToLower();

            if (role == "l")
            {
                RunLibrarianMenu();
            }
            else if (role == "u")
            {
                RunUserMenu();
            }
            else
            {
                Console.WriteLine("Invalid role selected.");
            }
        }

        static void RunLibrarianMenu()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n--- Librarian Panel ---");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Remove Book");
                Console.WriteLine("3. Display All Books");
                Console.WriteLine("4. Exit");

                Console.Write("Choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddNewBook();
                        break;

                    case "2":
                        DeleteBook();
                        break;

                    case "3":
                        ShowAllBooks();
                        break;

                    case "4":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Wrong choice, try again.");
                        break;
                }
            }
        }

        static void RunUserMenu()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n--- User Panel ---");
                Console.WriteLine("1. Get Library Card");
                Console.WriteLine("2. Display Books");
                Console.WriteLine("3. Borrow Book");
                Console.WriteLine("4. Exit");

                Console.Write("Choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        GetLibraryCard();
                        break;

                    case "2":
                        ShowAllBooks();
                        break;

                    case "3":
                        BorrowBook();
                        break;

                    case "4":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Wrong choice, try again.");
                        break;
                }
            }
        }

        static void GetLibraryCard()
        {
            if (hasLibraryCard)
            {
                Console.WriteLine("You already have a library card.");
                return;
            }

            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Error: Name cannot be empty.");
                return;
            }

            hasLibraryCard = true;

            Console.WriteLine("\nLibrary card issued successfully!");
            Console.WriteLine($"Welcome, {name}!");
        }

        static void AddNewBook()
        {
            Console.Write("Book Title: ");
            string title = Console.ReadLine();

            Console.Write("Author Name: ");
            string author = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(title) ||
                string.IsNullOrWhiteSpace(author))
            {
                Console.WriteLine("Error: Inputs cannot be empty.");
                return;
            }

            books.Add(new Book(title, author));

            Console.WriteLine("Book added successfully.");
        }

        static void DeleteBook()
        {
            Console.Write("Enter book title to remove: ");
            string title = Console.ReadLine();

            Book foundBook = null;

            foreach (var book in books)
            {
                if (string.Equals(
                    book.Title,
                    title,
                    StringComparison.OrdinalIgnoreCase))
                {
                    foundBook = book;
                    break;
                }
            }

            if (foundBook != null)
            {
                books.Remove(foundBook);
                Console.WriteLine("Book removed successfully.");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        static void ShowAllBooks()
        {
            Console.WriteLine("\n--- Books List ---");

            if (books.Count == 0)
            {
                Console.WriteLine("No books available right now.");
                return;
            }

            for (int i = 0; i < books.Count; i++)
            {
                string status = books[i].IsAvailable
                    ? "Available"
                    : "Borrowed";

                Console.WriteLine(
                    $"{i + 1}. Title: {books[i].Title} | " +
                    $"Author: {books[i].Author} | " +
                    $"Status: {status}");
            }
        }

        static void BorrowBook()
        {
            if (!hasLibraryCard)
            {
                Console.WriteLine(
                    "You need a library card before borrowing a book.");
                return;
            }

            ShowAllBooks();

            Console.Write("\nEnter book title to borrow: ");
            string title = Console.ReadLine();

            Book foundBook = null;

            foreach (var book in books)
            {
                if (string.Equals(
                    book.Title,
                    title,
                    StringComparison.OrdinalIgnoreCase))
                {
                    foundBook = book;
                    break;
                }
            }

            if (foundBook == null)
            {
                Console.WriteLine("Book not found.");
            }
            else if (!foundBook.IsAvailable)
            {
                Console.WriteLine("This book is already borrowed.");
            }
            else
            {
                foundBook.IsAvailable = false;
                Console.WriteLine("Book borrowed successfully.");
            }
        }
    }
}