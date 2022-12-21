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
            textBook.Holder = "Me";
            library = new UniversityLibrary();
        }

        [Test]
        public void TextBookConstructorShouldSetCorrectly()
        {
            string actualTitle = textBook.Title;
            string actualAuthor = textBook.Author;
            string actualCategory = textBook.Category;
            string actualHolder = textBook.Holder;

            Assert.Multiple(() =>
            {
                Assert.That(actualTitle, Is.EqualTo(title));
                Assert.That(actualAuthor, Is.EqualTo(author));
                Assert.That(actualCategory, Is.EqualTo(category));
                Assert.That(actualHolder, Is.EqualTo("Me"));
            });
        }
        [Test]
        public void UniversityLibraryShouldSetCorrectly()
        {
            int expextedCount = 0;
            int actualCount = library.Catalogue.Count;

            Assert.That(actualCount, Is.EqualTo(expextedCount));
        }
        [Test]
        public void AddCorrectly()
        {
            library.AddTextBookToLibrary(textBook);

            int expextedCount = 1;
            int actualCount = library.Catalogue.Count;

            Assert.That(actualCount, Is.EqualTo(expextedCount));
        }
    }
}