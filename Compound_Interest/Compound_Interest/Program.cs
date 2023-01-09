//Promt user for investment, interest rate, years of investment.

Console.Write("Investment Value: ");
double original_investment = double.Parse(Console.ReadLine());

Console.Write("Yearly interest as percentage: ");
double percentage = double.Parse(Console.ReadLine());

Console.Write("Years of investing: ");
double years = double.Parse(Console.ReadLine());

//iterate for the number of years adding the interst for each year
double investment = original_investment;
for (int i = 0; i < years; i++)
{
    investment = investment * (1 + (percentage / 100));
}

Console.WriteLine("Final Value: " + (Math.Round(investment, 2)));
Console.WriteLine("Total profit: " + (Math.Round(investment - original_investment, 2)));


