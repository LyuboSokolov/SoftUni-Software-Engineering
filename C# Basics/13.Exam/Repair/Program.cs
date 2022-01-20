using System;

namespace Repair
{
    class Program
    {
        static void Main(string[] args)
        {
            int boxPaint = int.Parse(Console.ReadLine());
            int pscTapeti = int.Parse(Console.ReadLine());
            double moneyForOneGloves = double.Parse(Console.ReadLine());
            double moneyForOneBrush = double.Parse(Console.ReadLine());

            double allPricePaint = boxPaint * 21.50;
            double allPriceTapeti = pscTapeti * 5.20;
            double pscGloves = Math.Ceiling(0.35 * pscTapeti);
            double allPriceGloves = pscGloves * moneyForOneGloves;
            double pscBrush = Math.Floor(0.48 * boxPaint);
            double allPriceBrush = pscBrush * moneyForOneBrush;
            double allPrice = allPriceBrush + allPriceGloves + allPricePaint + allPriceTapeti;
            double priceDelivery = allPrice / 15.00;

            Console.WriteLine($"This delivery will cost {priceDelivery:f2} lv.");
        }
    }
}
