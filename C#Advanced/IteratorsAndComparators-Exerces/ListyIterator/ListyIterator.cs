using System;
using System.Collections;
using System.Collections.Generic;

namespace ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> colection;
        private int currentIndex;

        public ListyIterator(params T[] data)
        {
            colection = new List<T>(data);
            currentIndex = 0;
        }

        public bool HasNext() => currentIndex < colection.Count - 1;

        public bool Move()
        {
            bool canMove = HasNext();

            if (canMove)
                currentIndex++;

            return canMove;
        }

        public void Print()
        {
            if (colection.Count == 0)
            {
                throw new ArgumentException("Invalid Operation");
            }

            Console.WriteLine($"{colection[currentIndex]}");
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T element in colection)
            {
                yield return element;
            }
        }

        public void PrintAll() => Console.WriteLine(string.Join(" ", colection));

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
