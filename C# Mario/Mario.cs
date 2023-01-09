using System;

namespace C_sharp_practice
{
    class Mario
    {
        static void Main(string[] args)
        {
           Console.WriteLine("Input required pyramid size:");
           string size = Console.ReadLine();
           int sizeint;
           bool success = int.TryParse(size, out sizeint);
           if (!success)
           {
            Console.WriteLine("Please input intergers only.");
           }
           else
           {
            for ( int i = 0; i < sizeint; i++)
            {
                Console.WriteLine(string.Concat(Enumerable.Repeat("#", sizeint - i)));
            }
           }
        }
    }
}

