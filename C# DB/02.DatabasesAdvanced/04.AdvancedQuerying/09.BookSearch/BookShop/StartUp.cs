namespace BookShop
{
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            // DbInitializer.ResetDatabase(db);

            string input = Console.ReadLine();
            Console.WriteLine(GetBookTitlesContaining(db, input));

        }
        //Problem 2.Age Restriction
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var booksTitle = context.Books
                    .ToArray()
                    .Where(x => x.AgeRestriction.ToString().ToLower() == command.ToLower())
                    .OrderBy(x => x.Title)
                    .Select(x => x.Title)
                    .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var book in booksTitle)
            {
                sb.AppendLine(book);
            }
            return sb.ToString().Trim();
        }

        // Problem 3. Golden Books
        public static string GetGoldenBooks(BookShopContext context)
        {
            var goldenBooks = context.Books
                 .OrderBy(x => x.BookId)
                 .ToArray()
                 .Where(x => x.Copies < 5000 && x.EditionType.ToString() == "Gold")
                 .Select(x => x.Title)
                 .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var book in goldenBooks)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().Trim();
        }

        //Problem 4. Books by Price
        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .ToList()
                .Where(x => x.Price > 40)
                .Select(x => new
                {
                    x.Title,
                    x.Price
                })
                .OrderByDescending(x => x.Price)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }
            return sb.ToString().Trim();
        }

        //Problem 5. Not Released In
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                                .Where(x => x.ReleaseDate.Value.Year != year)
                                .OrderBy(x => x.BookId)
                                .Select(x => x.Title)
                                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().Trim();
        }

        //Problem 6. Book Titles by Category
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] category = input.ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var books = context.Books.Include(x => x.BookCategories).ThenInclude(x => x.Book).Select(x => new
            {
                bookTittle = x.Title,
                bookCategories = x.BookCategories.Select(x => x.Category.Name)
            })
                .ToList();

            List<string> results = new List<string>();

            foreach (var book in books)
            {
                foreach (var b in book.bookCategories)
                {
                    if (category.Contains(b.ToLower()))
                    {
                        results.Add(book.bookTittle);
                    }
                }
            }
            results = results.OrderBy(x => x).ToList();
            string a = string.Join(Environment.NewLine, results);

            return a;
        }

        //Problem 7. Released Before Date
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime dt = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .OrderByDescending(x => x.ReleaseDate)
                .Where(x => x.ReleaseDate.Value < dt)
                .Select(x => $"{x.Title} - {x.EditionType} - ${x.Price:f2}")
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        //Problem 8. Author Search
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                            .OrderBy(x => x.FirstName)
                            .ThenBy(x => x.LastName)
                            .Where(x => x.FirstName.EndsWith(input))
                            .Select(x => $"{x.FirstName} {x.LastName}")
                            .ToList();

            return string.Join(Environment.NewLine, authors);
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(x => x.Title.ToLower().Contains(input.ToLower()))
                .OrderBy(x => x.Title)
                .Select(x => x.Title)
                .ToList();


            return string.Join(Environment.NewLine,books);
        }
    }
}
