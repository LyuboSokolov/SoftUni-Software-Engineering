using System;

namespace AuthorProblem
{
    [Author("Pesho")]
   public class StartUp
    {
        [Author("Gosho")]
       public static void Main(string[] args)
        {

            var tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }
    }
}
