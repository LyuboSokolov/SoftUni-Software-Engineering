using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Telephony
{
    public class StationaryPhone : IStationaryPhone
    {
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
                Console.WriteLine($"Dialing... {phoneNumber}");
            }
        }
    }
}
