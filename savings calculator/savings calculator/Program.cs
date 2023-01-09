using System.Runtime.InteropServices;
using System.Xml.Schema;
using static System.Net.Mime.MediaTypeNames;

Console.Write("Enter Months:");
int months = int.Parse(Console.ReadLine());
int currentPot = 50000;
int mortgage = 500;
int vanguard = 800;
int cash = 400;
int interest = 74;
int total = 0;
int mortgageDept = 209700;

for (int i = 0; i < months; i++)
{
    total += mortgage + vanguard + cash + interest;
}

Console.WriteLine($"Money saved over {months} months: £{total}");

double yearsToComplete = ((mortgageDept - currentPot) / ((mortgage + vanguard + cash + interest) * 12));

Console.WriteLine($"Years until mortage payed: {yearsToComplete}");
