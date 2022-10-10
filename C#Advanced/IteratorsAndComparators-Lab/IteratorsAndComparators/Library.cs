
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> books;

        public Library(params Book[] books)
        {
            this.books = books.ToList();
        }

        public IEnumerator<Book> GetEnumerator()
        {
            for (int i = 0; i < this.books.Count; i++)
            {
                Console.WriteLine(this.books[i]);
                yield return this.books[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        //public IEnumerator<Book> GetEnumerator()
        //{
        //    return new LibraryIterator(this.books);
        //}

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return GetEnumerator();
        //}

        //class LibraryIterator : IEnumerator<Book>
        //{
        //    private List<Book> books;
        //    private int position = -1;

        //    public LibraryIterator(List<Book> books)
        //    {
        //        this.books = books;
        //        Reset();
        //    }

        //    public Book Current => this.books[position];

        //    object IEnumerator.Current => this.Current;

        //    public void Dispose()
        //    {

        //    }

        //    public bool MoveNext()
        //    {
        //        this.position++;
        //        return position < books.Count;
        //    }

        //    public void Reset()
        //    {
        //        this.position = -1;
        //    }
        //}
    }
}
