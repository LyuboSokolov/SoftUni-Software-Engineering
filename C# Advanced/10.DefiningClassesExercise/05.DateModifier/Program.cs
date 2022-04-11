using System;

namespace DateModifier
{
    public class Program
    {
       public static void Main(string[] args)
        {
            string startData = Console.ReadLine();
            string endData = Console.ReadLine();

            DateModifier differenceBetweenTwoDate = new DateModifier();

            string result = differenceBetweenTwoDate.CalculateDiferensBetweenTwoData(startData, endData);
            Console.WriteLine(result);
        }
    }
}
