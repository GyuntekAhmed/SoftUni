
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Book : IComparable<Book>
    {
        public Book(string title, int year, params string[] autors)
        {
            Title = title;
            Year = year;
            Autors = autors.ToList();
        }

        public string Title { get; set; }
        public int Year { get; set; }
        public List<string> Autors { get; set; }

        public int CompareTo(Book other)
        {
            int result = this.Year.CompareTo(other.Year);

            if (result == 0)
            {
                return Title.CompareTo(other.Title);
            }

            return result;
        }

        public override string ToString()
        {
            return $"{Title} - {Year}";
        }
    }
}
