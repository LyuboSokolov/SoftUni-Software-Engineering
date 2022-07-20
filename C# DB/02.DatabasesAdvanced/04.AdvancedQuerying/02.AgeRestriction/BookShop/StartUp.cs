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
            string command = Console.ReadLine();
            Console.WriteLine(GetBooksByAgeRestriction(db, command));
        }

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
    }
}
