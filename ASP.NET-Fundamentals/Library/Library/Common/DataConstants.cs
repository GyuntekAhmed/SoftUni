using System.Security.Policy;

namespace Library.Common
{
    public static class DataConstants
    {
        public static class BookConstants
        {
            public const int TitleMinLength = 10;
            public const int TitleMaxLength = 50;

            public const int AuthorMinLength = 5;
            public const int AuthorMaxLength = 50;

            public const int DescriptionMinLength = 5;
            public const int DescriptionMaxLength = 5000;
        }

        public static class CategoryConstants
        {
            public static int NameMinLength = 5;
            public const int NameMaxLength = 50;
        }
    }
}
