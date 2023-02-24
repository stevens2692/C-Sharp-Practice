
using System.Collections.Generic;
using System;
using System.Linq;

public class Program
{
    public static int GetTotal(string[] strArr, Dictionary<string, int> cards)
    {
        int total = 0;
        for (int i = 0; i < strArr.Length; i++)
        {
            total += cards[strArr[i]];
        }
        return total;
    }

    public static string HighestCard(string[] strArr)
    {
        Dictionary<string, int> cards = new Dictionary<string, int>()
        {
            {"one", 1},
            {"two", 2},
            {"three", 3},
            {"four", 4},
            {"five", 5},
            {"six", 6},
            {"seven", 7},
            {"eight", 8},
            {"nine", 9},
            {"ten", 10},
            {"jack", 11},
            {"queen", 12},
            {"king",13},
            {"ace", 14}
        };
        List<int> values = new List<int>();
        for (int i = 0; i < strArr.Length; i++)
        {
            values.Add(cards[strArr[i]]);
        }
        int max = values.Max();
        if (max == 1)
        {
            return "ace";
        }

        Dictionary<int, string> InverseCards = new Dictionary<int, string>()
        {
            {1, "one"},
            {2, "two"},
            {3, "three"},
            {4, "four"},
            {5, "five"},
            {6, "six"},
            {7, "seven"},
            {8, "eight"},
            {9, "nine"},
            {10, "ten"},
            {11, "jack"},
            {12, "queen"},
            {13, "king"},
            {14, "ace"}
        };

        return InverseCards[max];

    }
    public static string BlackjackHighest(string[] strArr)
    {
        Dictionary<string, int> cards = new Dictionary<string, int>()
        {
            {"one", 1},
            {"two", 2},
            {"three", 3},
            {"four", 4},
            {"five", 5},
            {"six", 6},
            {"seven", 7},
            {"eight", 8},
            {"nine", 9},
            {"ten", 10},
            {"jack", 10},
            {"queen", 10},
            {"king",10},
            {"ace", 11}
        };
        int total = GetTotal(strArr, cards);
        if (total < 21)
        {
            return "Below " + HighestCard(strArr);
        }
        else if (total == 21)
        {
            return "blackjack " + HighestCard(strArr);
        }
        else
        {
            if (strArr.Contains("ace"))
            {
                for (int i = 0; i < strArr.Length; i++)
                {
                    if (strArr[i] == "ace")
                    {
                        strArr[i] = "one";
                        total = GetTotal(strArr, cards);
                        if (total < 21)
                        {
                            return "Below " + HighestCard(strArr);
                        }
                        else if (total == 21)
                        {
                            return "blackjack " + HighestCard(strArr);
                        }
                    }
                }
                return "above " + HighestCard(strArr);
            }
            return "above " + HighestCard(strArr);
        }
    }
    public static void Main()
    {
        string[] strArr = new string[] { "five", "nine", "jack" };
        Console.WriteLine(BlackjackHighest(strArr));
    }
}

