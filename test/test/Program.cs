using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

class Execute
{
    public static string LongestWord(string sen)
    {
        return Regex.Replace(sen,@"[^\w\s]","").Split(" ").OrderByDescending(x => x.Length).ToList().First();
    }

    static void Main(string[] args)
    {
        Console.WriteLine(LongestWord(Console.ReadLine()));
    }
}