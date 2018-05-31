using GiftAidCalculator.TestConsole.Repository;
using System;
using System.IO;

namespace GiftAidCalculator.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Calc Gift Aid Based on Previous
            Console.WriteLine("Please Enter donation amount:");
            Console.WriteLine(GiftAidAmount(decimal.Parse(Console.ReadLine())));
            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }

        static decimal GiftAidAmount(decimal donationAmount)
        {
            // TODO: Handle DI with an IoC container
            var taxRateRepository = new TaxRateRepository();
            var calculator = new GaCalculator(taxRateRepository);
            return calculator.GiftAidAmount(donationAmount);
        }
    }
}
