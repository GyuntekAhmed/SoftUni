using System.Collections.Generic;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> elements;

        public int Count => elements.Count;

        public Box()
        {
            elements = new List<T>();
        }

        public void Add(T element)
        {
            elements.Add(element);
        }

        public T Remove()
        {
            var lastElement = elements[Count - 1];
            elements.RemoveAt(Count - 1);

            return lastElement;
        }
    }
}
