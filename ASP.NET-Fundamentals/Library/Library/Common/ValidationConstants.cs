namespace Library.Common
{
    public static class ValidationConstants
    {
        public static class BookValidationConstants
        {
            public const int TitleMinLength = 10;
            public const int TitleMaxLength = 50;

            public const int AuthorMinLength = 5;
            public const int AuthorMaxLength = 50;

            public const int DescriptionMinLength = 5;
            public const int DescriptionMaxLength = 5000;
        }

        public static class CategoryValidationConstants
        {
            public const int NameMinLength = 5;
            public const int NameMaxLength = 50;
        }
    }
}
