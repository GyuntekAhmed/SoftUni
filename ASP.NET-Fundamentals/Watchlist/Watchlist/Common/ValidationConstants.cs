namespace Watchlist.Common
{
    public static class ValidationConstants
    {
        public static class Genre
        {
            public const int GenreMaxLength = 50;
        }

        public static class Movie
        {
            public const int TitleMinLength = 10;
            public const int TitleMaxLength = 50;

            public const int DirectorMinLength = 5;
            public const int DirectorMaxLength = 50;

            public const double RatingMinValue = 0.00;
            public const double RatingMaxValue = 10.00;
        }
    }
}
