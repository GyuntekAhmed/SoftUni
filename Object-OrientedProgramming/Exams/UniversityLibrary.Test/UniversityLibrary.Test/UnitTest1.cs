namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    public class Tests
    {
        private TextBook textBook;
        private UniversityLibrary library;
        string title;
        string author;
        string category;

        [SetUp]
        public void Setup()
        {
            title = "MyTitle";
            author = "Soyer";
            category = "General";

            textBook = new TextBook(title, author, category);
            library = new UniversityLibrary();
        }

        [Test]
        public void TextBookConstructorShouldSetCorrectly()
        {
            string actualTitle = textBook.Title;
            string actualAuthor = textBook.Author;
            string actualCategory = textBook.Category;

            Assert.That(actualTitle, Is.EqualTo(title));
            Assert.That(actualAuthor, Is.EqualTo(author));
            Assert.That(actualCategory, Is.EqualTo(category));
        }
    }
}