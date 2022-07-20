namespace BookShop
{
    using Data;
    using Initializer;
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            int year = int.Parse(Console.ReadLine());

            Console.WriteLine(GetBooksNotReleasedIn(db,year));
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

        //Problem 3. Books by Price
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

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
           var books =  context.Books
                               .Where(x => x.ReleaseDate.Value.Year != year)
                               .OrderBy(x=> x.BookId)
                               .Select(x=> x.Title)
                               .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().Trim();
        }
    }
}
