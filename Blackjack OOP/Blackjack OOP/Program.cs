using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public class Card
    {
        public string Name { get; set; }
        public int Hierarchy { get; set; }
        public int FaceValue { get; set; }

        public Card(string Name, int Hierarchy, int FaceValue)
        {
            this.Name = Name;
            this.Hierarchy = Hierarchy;
            this.FaceValue = FaceValue;
        }

        public static string GetHighestCard(List<Card> cardhand)
        {
            cardhand.Sort((x, y) => x.Hierarchy.CompareTo(y.Hierarchy));
            Card Highcard = cardhand.Last();
            return Highcard.Name;
        }

        public static int GetHierarchy(string name)
        {
            switch (name)
            {
                case "two":
                    return 2;
                case "three":
                    return 3;
                case "four":
                    return 4;
                case "five":
                    return 5;
                case "six":
                    return 6;
                case "seven":
                    return 7;
                case "eight":
                    return 8;
                case "nine":
                    return 9;
                case "ten":
                    return 10;
                case "jack":
                    return 11;
                case "queen":
                    return 12;
                case "king":
                    return 13;
                case "ace":
                    return 14;
                default:
                    return 0;
            }
        }

        public static int GetValue(string name)
        {
            switch (name)
            {
                case "two":
                    return 2;
                case "three":
                    return 3;
                case "four":
                    return 4;
                case "five":
                    return 5;
                case "six":
                    return 6;
                case "seven":
                    return 7;
                case "eight":
                    return 8;
                case "nine":
                    return 9;
                case "ten":
                    return 10;
                case "jack":
                    return 10;
                case "queen":
                    return 10;
                case "king":
                    return 10;
                case "ace":
                    return 11;
                default:
                    return 0;
            }
        }

        public static string BlackjackHighest(string[] hand)
        {
            List<Card> cardhand = new List<Card>();
            foreach (string _ in hand)
            {
                Card card = new Card(_, Card.GetHierarchy(_), Card.GetValue(_));
                cardhand.Add(card);
            }
            int total = cardhand.Sum(item => item.FaceValue);
            string highestcard = Card.GetHighestCard(cardhand);
            if (total < 21)
            {
                return "below " + highestcard;
            }
            if (total == 21)
            {
                return "blackjack " + highestcard;
            }
            else
            {
                if (cardhand.Any(x => x.Name == "ace"))
                {
                    for (int i = 0; i < cardhand.Count(); i++)
                    {
                        if (cardhand[i].Name == "ace")
                        {
                            cardhand[i].FaceValue = 1;
                            cardhand[i].Hierarchy = 1;
                            total = cardhand.Sum(item => item.FaceValue);
                            highestcard = Card.GetHighestCard(cardhand);
                            if (total < 21)
                            {
                                return "below " + highestcard;
                            }
                            if (total == 21)
                            {
                                return "blackjack " + highestcard;
                            }
                        }
                    }
                    return "Over " + highestcard;
                }
                else
                {
                    return "Over " + highestcard;
                }
            }
        }

        public static void Main()
        {
            string[] hand = new string[] { "jack", "queen", "ace" };
            Console.WriteLine(BlackjackHighest(hand));
        }
    }
}
