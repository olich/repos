using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            double d;
            if ((d=getNumber())==3.5)
            {
                Console.WriteLine("yes");
            }

            Console.ReadKey();
        }

        private static double getNumber()
        {
            return 3.5;
        }
    }
}
