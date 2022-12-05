namespace Book.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using NUnit.Framework;

    [TestFixture]
    public class Tests
    {
        private Book book;

        [SetUp]
        public void SetUp()
        {
            book = new Book("Harry Potter", "J. K. Rowling");
        }

        [Test]
        public void CountShouldSetCorrectly()
        {
            int expextedCount = 2;

            for (int i = 0; i < expextedCount; i++)
            {
                book.AddFootnote(i, i.ToString());
            }

            int actualCount = book.FootnoteCount;

            Assert.AreEqual(expextedCount, actualCount);
        }

        [Test]
        public void BookNameShouldSetCorrectly()
        {
            string expectedName = "Harry Potter";

            book = new Book(expectedName, "Tom");

            string actualName = book.BookName;

            Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        public void BookNameThrowExceptionWithInvalidValue()
        {
            string name = string.Empty;
            string secName = null;

            Assert.Throws<ArgumentException>(() =>
            {
                book = new Book(name, "Tom");
            });
            Assert.Throws<ArgumentException>(() =>
            {
                book = new Book(secName, "Tom");
            });
        }

        [Test]
        public void AuthorSetCorrectly()
        {
            string expectedAuthor = "Tom";

            book = new Book("Harry", expectedAuthor);

            string actualAuthor = book.Author;

            Assert.AreEqual(expectedAuthor, actualAuthor);
        }

        [Test]
        public void AuthorThrowExeptionWithInvalidAuthor()
        {
            string expectedAuthor1 = string.Empty;
            string expectedAuthor2 = null;

            Assert.Throws<ArgumentException>(() =>
            {
                book = new Book("Harry", expectedAuthor1);
            });
            Assert.Throws<ArgumentException>(() =>
            {
                book = new Book("Harry", expectedAuthor2);
            });
        }

        [Test]
        public void AddingFootNoteShouldAddKeyInTheDictionary()
        {
            int addedKey = 1;
            book.AddFootnote(addedKey, "Random text");

            Type bookType = book.GetType();
            FieldInfo dictFieldInfo = bookType
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(fi => fi.Name == "footnote");

            Dictionary<int, string> fieldValue = (Dictionary<int, string>)
                dictFieldInfo.GetValue(book);
            bool containsKey = fieldValue.ContainsKey(addedKey);

            Assert.IsTrue(containsKey);
        }

        [Test]
        public void AddingExistingFootNoteShouldThrowException()
        {
            int sameKey = 1;
            book.AddFootnote(sameKey, "Random note");
            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AddFootnote(sameKey, "Another text");
            }, "Footnote already exists!");
        }

        [Test]
        public void AddFootnoteThrowExceptionWhenContainsFootNote()
        {
            int expextedFootNote = 2;
            book.AddFootnote(expextedFootNote, "aaa");

            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AddFootnote(expextedFootNote, "bbb");
            });
        }

        [Test]
        public void FindFootNoteCorrectly()
        {
            int footNoteNumber = 3;
            string text = "Text";

            book.AddFootnote(footNoteNumber, text);

            string expectedResult = $"Footnote #{footNoteNumber}: {text}";
            string actualResult = book.FindFootnote(footNoteNumber);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void FindFootNoteThrowExceptionWhenHasKey()
        {
            int footNoteNumber = 3;
            string text = "Text";

            book.AddFootnote(footNoteNumber, text);

            Assert.Throws<InvalidOperationException>(() =>
            {
                book.FindFootnote(10);
            });
        }

        [Test]
        public void AlterFootNoteShouldChangeTextWhenFootNoteExists()
        {
            int footKey = 1;
            string footText = "Text";
            book.AddFootnote(footKey, footText);

            string expectedText = "New text";
            book.AlterFootnote(footKey, expectedText);

            Type bookType = book.GetType();
            FieldInfo dictFieldInfo = bookType
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(fi => fi.Name == "footnote");

            Dictionary<int, string> fieldValue = (Dictionary<int, string>)
                dictFieldInfo.GetValue(book);

            string actualText = fieldValue[footKey];
            Assert.AreEqual(expectedText, actualText);
        }

        [Test]
        public void AlterFootNoteShouldThrowExceptionIfThereAreFootNotesButPassedKeyDoesNotExist()
        {
            int footKey = 1;
            string footText = "Text";
            book.AddFootnote(footKey, footText);

            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AlterFootnote(999, "New invalid text");
            }, "Footnote doesn't exists!");
        }

        [Test]
        public void AlterFootNoteShouldThrowExceptionIfThereAreNoFootNotesAtAll()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AlterFootnote(1, "Invalid text");
            }, "Footnote doesn't exists!");
        }
    }
}