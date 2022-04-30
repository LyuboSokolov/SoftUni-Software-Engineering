using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Telephony
{
    public class Smartphone : ISmartphone
    {
        public void BrowseWebSite(string webSite)
        {
            bool isInvalidURL = false;
            foreach (var ch in webSite)
            {
                if (char.IsDigit(ch))
                {
                    isInvalidURL = true;
                    break;
                }
            }

            if (isInvalidURL)
            {
                Console.WriteLine("Invalid URL!");
            }
            else
            {
                Console.WriteLine($"Browsing: {webSite}!");
            }
        }

        public void CallOtherPhones(string phoneNumber)
        {
            bool isInvalidNumber = false;

            foreach (var ch in phoneNumber)
            {
                if (!char.IsDigit(ch))
                {
                    isInvalidNumber = true;
                    break;
                }
            }

            if (isInvalidNumber)
            {
                Console.WriteLine("Invalid number!");
            }
            else
            {
                Console.WriteLine($"Calling... {phoneNumber}");
            }
        }
    }
}
