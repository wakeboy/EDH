using System;
using System.IO;

namespace GiftAidCalculator.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            // Calc Gift Aid Based on Previous
            Console.WriteLine("Please Enter donation amount:");
            Console.WriteLine(GiftAidAmount(decimal.Parse(Console.ReadLine())));
            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }

        static decimal GiftAidAmount(decimal donationAmount)
        {
            var calculator = new GaCalculator();
            return calculator.GiftAidAmount(donationAmount);
        }
    }
}
