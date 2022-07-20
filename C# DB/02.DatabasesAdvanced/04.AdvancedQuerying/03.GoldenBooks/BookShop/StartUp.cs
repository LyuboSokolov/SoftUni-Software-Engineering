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
            //DbInitializer.ResetDatabase(db);

            Console.WriteLine(GetGoldenBooks(db));
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
    }
}
