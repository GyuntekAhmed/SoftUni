using System;

namespace MyQueue
{
    public class StartUp
    {
        static void Main()
        {
            CustomQueue customQueue = new CustomQueue();

            customQueue.Enqueue(10);
            customQueue.Enqueue(20);
            customQueue.Enqueue(30);
            customQueue.Enqueue(40);
            customQueue.Enqueue(50);

            customQueue.Dequeue();

            customQueue.Peek();

            customQueue.ForEach(x => Console.WriteLine(x));
        }
    }
}
