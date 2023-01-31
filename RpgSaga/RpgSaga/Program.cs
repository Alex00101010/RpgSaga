using System;

namespace RpgSaga
{
    class Program
    {
        static void Main(string[] args)
        {
            var arena = new Saga.Arena(4096, 0);
            var log = arena.Start();
            Console.WriteLine(log);
            Console.WriteLine("Winner: " + arena.GetWinner());
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }
    }
}
