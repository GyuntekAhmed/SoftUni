namespace Boardgames.DataProcessor
{
    using Boardgames.Data;
    using Boardgames.DataProcessor.ExportDto;
    using Boardgames.Utilities;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
        {
            XmlHelper xmlHelper = new XmlHelper();

            ExportCreatorDto[] creators = context.Creators
                .Where(c => c.Boardgames.Any())
                .Select(c => new ExportCreatorDto()
                {
                    BoardgamesCount = c.Boardgames.Count,
                    Name = $"{c.FirstName} {c.LastName}",
                    Boardgame = c.Boardgames
                    .Select(b => new ExportBoardgameDto()
                    {
                        Name = b.Name,
                        YearPublished = b.YearPublished,
                    })
                    .OrderBy(b => b.Name)
                    .ToArray()
                })
                .OrderByDescending(c => c.BoardgamesCount)
                .ThenBy(c => c.Name)
                .ToArray();

            return xmlHelper.Serialize(creators, "Creators");
        }

        public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
        {
            var sellers = context.Sellers
                .Where(s => s.BoardgamesSellers.Any(bs => bs.Boardgame.YearPublished >= year && bs.Boardgame.Rating <= rating))
                .ToArray()
                .Select(s => new
                {
                    s.Name,
                    s.Website,
                    Boardgames = s.BoardgamesSellers
                    .Where(b => b.Boardgame.YearPublished >= year && b.Boardgame.Rating <= rating)
                    .ToArray()
                    .OrderByDescending(s => s.Boardgame.Rating)
                    .ThenBy(s => s.Boardgame.Name)
                    .Select(b => new
                    {
                        b.Boardgame.Name,
                        b.Boardgame.Rating,
                        b.Boardgame.Mechanics,
                        CategoryT = b.Boardgame.CategoryType.ToString()
                    })
                    .ToArray()
                })
                .OrderByDescending(s => s.Boardgames.Length)
                .ThenBy(s => s.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(sellers, Formatting.Indented);
        }
    }
}