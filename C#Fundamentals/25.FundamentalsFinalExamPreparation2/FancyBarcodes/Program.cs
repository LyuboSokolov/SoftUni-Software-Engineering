using System;
using System.Text.RegularExpressions;

namespace FancyBarcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"@#+([A-Z][A-Za-z0-9]{4,}[A-Z])@#+";
            string patterNumbers = @"\d";
            Regex regex = new Regex(pattern);
            Regex regexNumber = new Regex(patterNumbers);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Match match = regex.Match(input);
                string barcodeGroup = "00";

                if (match.Success)
                {
                    MatchCollection machNumber = regexNumber.Matches(input);
                    if (machNumber.Count > 0)
                    {
                        barcodeGroup = string.Empty;
                        foreach (var ch in machNumber)
                        {
                            barcodeGroup += ch;
                        }
                    }
                    Console.WriteLine($"Product group: {barcodeGroup}");
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
