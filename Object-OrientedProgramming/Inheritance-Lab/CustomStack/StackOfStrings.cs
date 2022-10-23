using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool isEmpty()
        {
            return this.Count == 0;
        }

        public Stack<string> AddRange(List<string> elements)
        {
            foreach (var element in elements)
            {
                Push(element);
            }

            return this;
        }
    }
}
