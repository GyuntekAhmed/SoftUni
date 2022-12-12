namespace CustomStack
{
    using System.Collections.Generic;

    public class StackOfStrings : Stack<string>
    {

        public bool IsEmpty()
        {
            return Count == 0;
        }

        public Stack<string> AddRange(IEnumerable<string> elements)
        {
            foreach (var element in elements)
            {
                Push(element);
            }

            return this;
        }
    }
}
