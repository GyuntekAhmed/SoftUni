using System;
namespace AuthorProblem
{
    [Author("Gyuntek")]
    public class StartUp
    {
        [Author("Gyuni")]
        static void Main()
        {
            Tracker tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }
    }
}
