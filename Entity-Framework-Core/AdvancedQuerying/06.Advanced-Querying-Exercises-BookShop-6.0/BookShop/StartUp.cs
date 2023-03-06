namespace BookShop
{
    using System.Globalization;
    using System.Linq;
    using System.Text;

    using BookShop.Models.Enums;
    using Data;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            //string command = Console.ReadLine();
            int command = int.Parse(Console.ReadLine());

            Console.WriteLine(CountBooks(db, command));
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            AgeRestriction ageRestrictionEnum;

            bool isParsed =
                Enum.TryParse<AgeRestriction>(command, true, out ageRestrictionEnum);

            if (!isParsed)
            {
                return String.Empty;
            }

            string[] bookTitles = context
                .Books
                .Where(b => b.AgeRestriction == ageRestrictionEnum)
                .Select(b => b.Title)
                .OrderBy(t => t)
                .ToArray();

            return string.Join(Environment.NewLine, bookTitles);
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            string[] bookTitles = context
                .Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, bookTitles);
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder output = new StringBuilder();

            var booksTitle = context
                .Books
                //.Where(b => b.Price > 40)
                //.OrderByDescending(b => b.Price)
                .Select(b => new
                {
                    Title = b.Title,
                    Price = b.Price
                })
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .ToArray();

            foreach (var b in booksTitle)
            {
                output.AppendLine($"{b.Title} - ${b.Price:f2}");
            }

            return output.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            string[] books = context
                .Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input.ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[] books = context
                .Books
                .Where(b => b.BookCategories.Any(bc => categories.Contains(bc.Category.Name.ToLower())))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var parsedDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(b => b.ReleaseDate < parsedDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:F2}")
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string endingWith)
        {
            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(endingWith))
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName)
                .Select(a => $"{a.FirstName} {a.LastName}")
                .ToArray();

            return string.Join(Environment.NewLine, authors);
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            string[] books = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(t => t)
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            string[] books = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => b.Author.FirstName == null
                    ? $"{b.Title} ({b.Author.LastName})"
                    : $"{b.Title} ({b.Author.FirstName} {b.Author.LastName})")
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            int numberOfBooks = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();

            return numberOfBooks;
        }
    }
}


