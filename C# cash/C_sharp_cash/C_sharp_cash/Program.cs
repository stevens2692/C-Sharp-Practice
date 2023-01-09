using System;

namespace C_sharp_cash
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // The user inputs a value of change they need form a whole £, the programme will return the smallest number of coins needed and the coins required.

            // get change value from user and ensure its an int between 1 and 99
            Console.WriteLine("Please enter how much change you need in pence ");
            string stringChange = Console.ReadLine();
            if (!int.TryParse(stringChange, out int change))
            {
                Console.WriteLine("Please input interger values only");
            }
            else if (change < 1 || change > 99)
            {
                Console.WriteLine("Please input a change value between 1 and 99");
            }

            // Calculate the coins needed updating change after each coion value
            else
            {
                int fifty = Coins.FiftyPence(change);
                change = change - (50 * fifty);
                int twenty = Coins.TwentyPence(change);
                change = change - (20 * twenty);
                int ten = Coins.TenPence(change);
                change = change - (10 * ten);
                int five = Coins.FivePence(change);
                change = change - (5 * five);
                int two = Coins.TwoPence(change);
                change = change - (2 * two);
                int one = Coins.OnePence(change);

                // Get the total number of coins needed
                int totalCoins = fifty + twenty + ten + five + two + one;

                // Print the coins needed and total coins allowing for single or plural phrases
                Console.WriteLine("For this change value you will need, ");
                if (fifty >= 1)
                {
                    Console.WriteLine(fifty + " x 50p coin");
                }

                if (twenty > 1)
                {
                    Console.WriteLine(twenty + " x 20p coins");
                }
                if (twenty == 1)
                {
                    Console.WriteLine(twenty + " x 20p coin");
                }

                if (ten > 1)
                {
                    Console.WriteLine(ten + " x 10p coins");
                }
                if (ten == 1)
                {
                    Console.WriteLine(ten + " x 10p coin");
                }

                if (five > 1)
                {
                    Console.WriteLine(five + " x 5p coins");
                }
                if (five == 1)
                {
                    Console.WriteLine(five + " x 5p coin");
                }

                if (two > 1)
                {
                    Console.WriteLine(two + " x 2p coins");
                }
                if (two == 1)
                {
                    Console.WriteLine(two + " x 2p coin");
                }

                if (one > 1)
                {
                    Console.WriteLine(one + " x 1p coins");
                }
                if (one == 1)
                {
                    Console.WriteLine(one + " x 1p coin");
                }

                Console.WriteLine("You will need " + totalCoins + " coins in total");

            }
            Console.ReadLine();
        }
    }
}