// Read file

using System.Formats.Asn1;
using System.Globalization;
using System;
using CsvHelper;
using CsvHelper.Configuration.Attributes;

using var reader = new StreamReader("C:\\Users\\Matt\\OneDrive\\Documents\\Coding\\C# practice\\Nutmeg dividends\\Nutmeg dividends\\Nutmeg_SavingsInvestment-30-Dec-22.csv");

// Get headings
string? headings = reader.ReadLine();

//split by comma
string?[] words = headings?.Split(',');


var rows = new List<Row>();
while (true)
{
    var line = reader.ReadLine(); //Think of this as ReadNextLine
    if (line == null) //Only null at end of file
        break;
    string[] row = line.Split(',');

    rows.Add(new Row
    {
        Date = row[0],
        Description = row[1],
        Investment = row[2],
        AssetCode = row[3],
        Pot = row[4],
        Account = row[5],
        NoShares = Convert.ToDouble(row[6]),
        SharePrice = Convert.ToDouble(row[7]),
        TotalValue = Convert.ToDouble(row[8]),
    });
}
var value = rows.Where(x => x.Description == "Dividend").Sum(x => x.TotalValue);
var fee = rows.Where(x => x.Description == "Fee").Sum(x => x.TotalValue);
Console.WriteLine($"Dividends: {Math.Round(value, 2)}");
Console.WriteLine($"Profit: {Math.Round(value - fee, 2)}");





Console.ReadKey();

//using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

//var records = csv.GetRecords<Row>().ToList();

//var allRows = records.ToList();




//var value = rows.Where(x => x.Description == "Dividend").Sum(x => x.TotalValue);
//Console.WriteLine(value);

public class Row
{
    public string Date { get; set; }
    public string Description { get; set; }
    public string Investment { get; set; }

    [Name("Asset Code")]
    public string AssetCode { get; set; }
    public string Pot { get; set; }
    public string Account { get; set; }

    [Name("No. Shares")]
    public double NoShares { get; set; }

    [Name("Share Price (£)")]
    public double SharePrice { get; set; }

    [Name("Total Value (£)")]
    public double TotalValue { get; set; }
}




//------------------------------OLD---------------------------//



//var value = allRows.Where(x => x.Description == "Dividend").Sum(x => x.TotalValue);

//var fee = allRows.Where(x => x.Description == "Fee").Sum(x => x.TotalValue);

//Console.WriteLine(value);
//Console.WriteLine(fee);


//Parse CSV into object

//Select all rows where == dividend and sum up value

//Date	Description	Investment	Asset Code	Pot	Account	No. Shares	Share Price (Â£)	Total Value (Â£)

//Date,Description,Investment,Asset Code, Pot, Account, No. Shares, Share Price (£),Total Value(£)

//Headers: 'Date', 'Description', 'Investment', 'Asset Code', 'Pot', 'Account', 'No. Shares', 'Share Price (£)', 'Total Value (£)'
//Headers: 'Date', 'Description', 'Investment', 'Asset Code', 'Pot', 'Account', 'No. Shares', 'Share Price (£)', 'Total Value (£)'

// 




