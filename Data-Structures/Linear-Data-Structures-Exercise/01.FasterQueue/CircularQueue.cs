namespace Problem01.CircularQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class CircularQueue<T> : IAbstractQueue<T>
    {
        private T[] elements;
        private int startIndex;
        private int endIndex;

        public int Count { get; private set; }
        public int Capacity { get => elements.Length; }

        private const int InitialCapacity = 4;

        public CircularQueue(int capacity = InitialCapacity)
        {
            this.elements = new T[capacity];
        }

        public void Enqueue(T element)
        {
            if (this.Count >= this.elements.Length)
            {
                this.Grow();
            }
            this.elements[this.endIndex] = element;
            this.endIndex = (this.endIndex + 1) % this.elements.Length;
            this.Count++;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty!");
            }

            var result = this.elements[this.startIndex];
            this.startIndex = (this.startIndex + 1) % this.elements.Length;
            this.Count--;
            return result;
        }

        public T[] ToArray()
        {
            return this.CopyAllElementsTo(new T[this.Count]);
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return this.elements[this.startIndex];
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.elements[(this.startIndex + i) % this.elements.Length];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void Grow()
        {
            this.elements = this.CopyAllElementsTo(new T[2 * this.elements.Length]);
            this.startIndex = 0;
            this.endIndex = this.Count;
        }

        private T[] CopyAllElementsTo(T[] resultArr)
        {
            int sourceIndex = this.startIndex;
            for (int i = 0; i < this.Count; i++)
            {
                resultArr[i] = this.elements[sourceIndex];
                sourceIndex = (sourceIndex + 1) % this.elements.Length;
            }

            return resultArr;
        }
    }

}
