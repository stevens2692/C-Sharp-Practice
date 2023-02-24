

using ConsoleTables;
using System.Net;

namespace Crypto_wallet
{
    internal class Program
    {
        class Coin
        {
            public string Name { get; set; }
            public decimal Value { get; set; }
            public decimal Units { get; set; }

            public Coin(string name, decimal value, decimal units)
            {
                Name = name;
                Value = value;
                Units = units;
            }
        }
        class Wallet
        {
            public decimal Balance { get; set; }
            public List<Coin> Coins { get; set; }

            public Wallet()
            {
                Balance = 0;
                Coins = new List<Coin>();
            }

            // Allow the user to deposit funds to their wallet
            public void Deposit()
            {
                while (true)
                {
                    Console.Write("Deposit amount: ");
                    string amount = Console.ReadLine();
                    if (Decimal.TryParse(amount, out decimal Deposit))
                    {
                        if (Deposit >= 0)
                        {
                            Balance += Deposit;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Deposit amount must be positive");
                        }                      
                    }
                    else
                    {
                        Console.WriteLine("Please input a valid Number");
                    }
                }
            }
            
            // Allow the user to withdraw funds from their wallet.
            public void Withdraw()
            {
                while (true)
                {
                    Console.Write("Withdraw amount: ");
                    string amount = Console.ReadLine();
                    if (Decimal.TryParse(amount, out decimal Withdraw))
                    {
                        if (Balance >= Withdraw && Withdraw >= 0)
                        {
                            Balance -= Withdraw;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Ensure withdraw value is positive and you have sufficient funds");
                        }

                    }
                    else
                    {
                        Console.WriteLine("Please input a valid Number");
                    }
                }
            }

            // Allow the user to buy any of the coins in the "Crypto" list.
            public void Buy()
            {
                List<string> Cryptos = new() { "BTC", "ETH", "BNB", "XRP", "ADA", "DOGE", "MATIC", "SOL"};
                Console.Write("Crypto ticker symbol: ");
                string? Crypto =  Console.ReadLine();
                if (Cryptos.Contains(Crypto.ToUpper()))
                {
                    Console.Write("Purchase units: ");
                    string Units = Console.ReadLine();
                    decimal decimalUnits = 0;
                    try
                    {                      
                        decimalUnits = System.Convert.ToDecimal(Units);
                    }
                    catch (System.ArgumentException)
                    {
                        Console.WriteLine("please input a valid decimal value");
                        return;
                    }
                    // Check the user has sufficient funds for the purchase.
                    if (decimalUnits * GetPrice(Crypto) <= Balance)
                    {
                        // Update user balance.
                        Balance -= decimalUnits * GetPrice(Crypto); 
                        // check if the user already owns any of the coin the are trying to buy
                        Coin u = Coins.FirstOrDefault(u => u.Name == Crypto.ToUpper());
                        if (u != null)
                        {
                            // If the user already owns the coin, add on the additional units purchased.
                            u.Units += decimalUnits;
                            u.Value = GetPrice(Crypto) * u.Units;
                        }
                        else
                        // If the user does not already own the coin add a new coin to the coins list.
                        {
                            Coin coin = new Coin(Crypto.ToUpper(), GetPrice(Crypto), decimalUnits);
                            Coins.Add(coin);
                        }                        
                    }
                    else
                    {
                        Console.WriteLine("Insufficient funds for this purchase");
                    }                                        
                }
                else
                {
                    Console.WriteLine("Please input a valid ticker symbol");
                }
            }

            // Allow the user to sell any of the coins they own.
            public void sell()
            {
                Console.Write("Crypto ticker symbol to sell: ");
                string? Crypto = Console.ReadLine();
                //Check the user actually owns the coin they are trying to sell.
                Coin u = Coins.FirstOrDefault(u => u.Name == Crypto.ToUpper());
                if (u == null)
                {
                    Console.WriteLine("You do not own any of this coin");
                    return;
                }
                else
                {
                    Console.Write("Sell units: ");
                    string Units = Console.ReadLine();
                    decimal decimalUnits = 0;
                    try
                    {
                        decimalUnits = System.Convert.ToDecimal(Units);
                    }
                    catch (System.ArgumentException)
                    {
                        Console.WriteLine("please input a valid decimal value");
                        return;
                    }
                    // Allows the user to sell all of the particular coin and updates their cash balance with the sale price.
                    if (u.Units <= decimalUnits)
                    {
                        Balance += u.Units * GetPrice(u.Name);
                        Coins.Remove(u);
                    }
                    // Allows partial sale of the particular coin and updates the cash balance with the sale price. 
                    else
                    {
                        Balance += decimalUnits * GetPrice(u.Name);
                        u.Units -= decimalUnits;
                    }

                }
            }
            // Uses the binance API to get the current real world price of the crypto coin of interest.
            public static decimal GetPrice(string coin)
            {
                var url = "https://api.binance.com/api/v3/ticker/price?symbol=" + coin.ToUpper() + "USDT";
                var request = WebRequest.Create(url);
                request.Method = "GET";

                using var webResponse = request.GetResponse();
                using var webStream = webResponse.GetResponseStream();

                using var reader = new StreamReader(webStream);
                var data = reader.ReadToEnd();
                if (decimal.TryParse(data.Split("\"")[7], out decimal value))
                {
                    return value;
                }
                else
                {
                    return 0;
                }
            }
        }

        static void Main(string[] args)
        {
            Wallet wallet = new Wallet();
            while (true)
            {
                // Ask the user which of the following functionality they would like to perform: "deposit", "withdraw", "buy", "sell", "exit".
                Console.WriteLine("What would you like to do? ");
                string userInput = (Console.ReadLine()).ToLower();
                string[] functions = new string[] { "deposit", "withdraw", "buy", "sell", "exit" };
                if (functions.Contains(userInput))
                {
                    CallFunction(userInput, wallet);
                }
                else
                {
                    Console.WriteLine("Please type one of these functions: deposit, withdraw, buy, sell or exit");
                }
                Console.WriteLine();
                //Print the users current balance after every method performed.
                Console.WriteLine($"Balance: ${decimal.Round(wallet.Balance, 2, MidpointRounding.AwayFromZero)}"); 
                
                // Use the ConsoleTables packaged to display the contents of the users wallet.
                var table = new ConsoleTable("Coin", "Value ($)", "Units");
                foreach (Coin coin in wallet.Coins)
                {
                    table.AddRow(coin.Name, decimal.Round((Wallet.GetPrice(coin.Name) * coin.Units), 2, MidpointRounding.AwayFromZero), coin.Units);
                }                                    
                table.Write(Format.Alternative);
            }

        }

        //calls the relevant object method based on the users input
        static void CallFunction(string userInput, Wallet wallet)
        {
            switch (userInput) {
                case "buy":
                    wallet.Buy();
                    break;
                case "sell":
                    wallet.sell();
                    break;
                case "deposit":
                    wallet.Deposit();
                    break;
                case "withdraw":
                    wallet.Withdraw();
                    break;
                case "exit":
                    Exit();
                    break;
            }
        }

        //Exits the program at the users discretion. 
        static void Exit()
        {
            System.Environment.Exit(0);
        }

    }
}