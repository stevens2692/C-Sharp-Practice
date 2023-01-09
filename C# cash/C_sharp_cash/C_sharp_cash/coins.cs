using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_cash
{
    internal class Coins
    {
        public int change;
        public static int FiftyPence(int change)
        {
            int numFiftyCoins = 0;
            while (change >= 50)
            {
                change = change - 50;
                numFiftyCoins++;
            }
            return numFiftyCoins;
        }
        public static int TwentyPence(int change)
        {
            int numTwentyCoins = 0;
            while (change >= 20)
            {
                change = change - 20;
                numTwentyCoins++;
            }
            return (numTwentyCoins);
        }

        public static int TenPence(int change)
        {
            int numTenCoins = 0;
            while (change >= 10)
            {
                change = change - 10;
                numTenCoins++;
            }
            return (numTenCoins);
        }

        public static int FivePence(int change)
        {
            int numFiveCoins = 0;
            while (change >= 5)
            {
                change = change - 5;
                numFiveCoins++;
            }
            return (numFiveCoins);
        }

        public static int TwoPence(int change)
        {
            int numTwoCoins = 0;
            while (change >= 2)
            {
                change = change - 2;
                numTwoCoins++;
            }
            return (numTwoCoins);
        }

        public static int OnePence(int change)
        {
            int numOneCoins = 0;
            while (change >= 1)
            {
                change = change - 1;
                numOneCoins++;
            }
            return (numOneCoins);
        }
    }
}
