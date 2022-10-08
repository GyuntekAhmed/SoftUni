
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericBoxOfString
{
    public class Box<T> : IComparable<T> where T : IComparable<T>
    {
        public Box(T element)
        {
            Element = element;
        }
        public Box(List<T> elementsList)
        {
            Elements = elementsList;
        }

        public T Element { get; }
        public List<T> Elements { get; }

        public void Swap(List<T> elements, int indexOne, int indexTwo)
        {
            T firstElement = elements[indexOne];
            elements[indexOne] = elements[indexTwo];
            elements[indexTwo] = firstElement;
        }

        public int CompareTo(T other)
            => Element.CompareTo(other);

        public int CountOfGreaterElements<T>(List<T> list, T readLine) where T : IComparable
            => list.Count(word => word.CompareTo(readLine) > 0);

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var element in Elements)
            {
                sb.AppendLine($"{element.GetType()}: {element}");
            }

            return sb.ToString().TrimEnd();
            //return $"{typeof(T)}: {Element}";
        }
    }
}
