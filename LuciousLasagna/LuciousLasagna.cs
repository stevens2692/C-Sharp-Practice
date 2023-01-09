using System;

namespace C_sharp_practice
{
    class Program
    {
        static void Main(string[] args)
        {
            int layers;
            int currentOvenTime;

            Console.WriteLine("Caluculate the total cooking time and remaining cooking time of your lasagna using this program");
            Console.WriteLine("How many layers in your Lasagna? ");
            string stringLayers = Console.ReadLine();
            bool success = int.TryParse(stringLayers, out layers);
            if (!success)
            {
                Console.WriteLine("Please input intergers only.");
            }
            else
            {
                Console.WriteLine("How long has your lasagna been in the oven in minutes?");
                string stringCurrentOvenTime = Console.ReadLine();
                success = int.TryParse(stringCurrentOvenTime, out currentOvenTime);
                if (!success)
                {
                    Console.WriteLine("Please input intergers only.");
                }   
                else
                {
                    int totalTime = Lasagna.cookingTime(layers);
                    int remainingTime = Lasagna.remainingTime(currentOvenTime, totalTime);
                    Console.WriteLine("The total cooking time will be: " + totalTime);
                    Console.WriteLine("The remaining cooking time will be: " + remainingTime);
                }

            }  
        }
    }
}

