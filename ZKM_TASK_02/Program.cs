using System;

namespace IJunior_Exit_Control
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = "Hello mir";
            const string ExitCheck = "exit";

            while (true)
            {
                Console.WriteLine(message);
                string Exitwrite = Console.ReadLine();
                if (Exitwrite == ExitCheck)
                {
                    break;
                }
            }
            Console.WriteLine();
            Console.WriteLine("Конец!");
            Console.ReadLine();
        }
    }
}