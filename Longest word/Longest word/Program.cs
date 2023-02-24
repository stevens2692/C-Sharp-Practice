using System;
using System.Text;

class MainClass
{

    public static string LongestWord(string sen)
    {
        string[] words = sen.Split(' ');
        string modWord;
        List<string> wordlist = new List<string>();
        foreach (string word in words)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in word)
            {
                if (char.IsLetter(c))
                {
                    sb.Append(c);
                }
            }
            modWord = sb.ToString();
            wordlist.Add(modWord);
        }
        string longestWord = "";
        int length = 0;
        int longestInt = 0;
        foreach (string word in wordlist)
        {
            length = word.Length;
            if (length > longestInt)
            {
                longestInt = length;
                longestWord = word;
            }
        }
        return longestWord;

    }

    static void Main()
    {
        // keep this function call here
        Console.WriteLine(LongestWord(Console.ReadLine()));
    }

}
