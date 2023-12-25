namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
    {
        private class Node
        {
            public T Element { get; set; }
            public Node Next { get; set; }

            public Node(T element, Node next)
            {
                this.Element = element;
                this.Next = next;
            }
            
            public Node(T element)
            {
                this.Element = element;
            }
        }

        private Node top;

        public int Count { get; private set; }

        public void Push(T item)
        {
            var newNode = new Node(item, this.top);

            this.top = newNode;
            this.Count++;
        }

        public T Pop()
        {
            if (this.top == null)
            {
                throw new InvalidOperationException();
            }

            var oldTop = this.top;
            this.top = oldTop.Next;

            this.Count--;
            return oldTop.Element;
        }

        public T Peek()
        {
            if (this.top == null)
            {
                throw new InvalidOperationException();
            }

            return this.top.Element;
        }

        public bool Contains(T item)
        {
            foreach (var element in this)
            {
                if (item.Equals(element))
                {
                    return true;
                }
            }

            return false;

        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = this.top;

            while (node != null)
            {
                yield return node.Element;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }
}