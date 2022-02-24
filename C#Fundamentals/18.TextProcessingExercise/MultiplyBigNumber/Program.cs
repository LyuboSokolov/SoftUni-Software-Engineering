using System;
using System.Linq;
using System.Text;

namespace MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstNumber = Console.ReadLine().TrimStart('0');
            int secondNumber = int.Parse(Console.ReadLine());

            StringBuilder results = new StringBuilder();
            int temp = 0;

            if (secondNumber == 0 || firstNumber == string.Empty)
            {
                Console.WriteLine(0);
                return;
            }

            foreach (char ch in firstNumber.Reverse())
            {
                int digit = int.Parse(ch.ToString());
                int result = digit * secondNumber + temp;

                int restDigit = result % 10;
                temp = result / 10;

                results.Insert(0, restDigit);
            }

            if (temp > 0)
            {
                results.Insert(0, temp);
            }
            Console.WriteLine(results.ToString());
        }
    }
}
