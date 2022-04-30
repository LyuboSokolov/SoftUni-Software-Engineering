using System;

namespace _03.Telephony
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[] webSites = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            StationaryPhone stationaryPhone = new StationaryPhone();
            Smartphone smartphone = new Smartphone();

            foreach (var phoneNumber in phoneNumbers)
            {
                if (phoneNumber.Length == 7)
                {
                    stationaryPhone.CallOtherPhones(phoneNumber);
                }
                else
                {
                    smartphone.CallOtherPhones(phoneNumber);
                }
            }

            foreach (var webSite in webSites)
            {
                smartphone.BrowseWebSite(webSite);
            }
        }
    }
}
