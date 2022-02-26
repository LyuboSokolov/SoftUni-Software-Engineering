﻿using System;
using System.Text.RegularExpressions;

namespace MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string phoneNumber = Console.ReadLine();
            string pattern = @"\+[359]+([ \-])[2]\1[0-9]{3}\1[0-9]{4}\b";

            Regex regex = new Regex(pattern);

            var matches = regex.Matches(phoneNumber);

            Console.WriteLine(string.Join(", ", matches));
        }
    }
}
