using System;

namespace MyList
{
    public class StartUp
    {
        static void Main()
        {
            CustomList customList = new CustomList();

            customList.Add(11);
            customList.Add(12);
            customList.Add(13);
            customList.Add(14);
            customList.Add(15);
            customList.ForEach(x => Console.WriteLine(x));
            customList.RemoveAt(0);

            customList.RemoveAt(2);
            customList.RemoveAt(0);

            customList.ForEach(x => Console.WriteLine(x));

            customList.Add(44);

            customList.ForEach(x => Console.WriteLine(x));
        }
    }
}
