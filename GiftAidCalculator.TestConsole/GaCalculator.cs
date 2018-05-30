using System;
using System.Collections.Generic;
using System.Text;

namespace GiftAidCalculator.TestConsole
{
    public class GaCalculator
    {
        private readonly decimal taxRate = 20m;

        public decimal GiftAidAmount(decimal donationAmount)
        {
            var gaRatio = taxRate / (100 - taxRate);
            return Math.Round(donationAmount * gaRatio, 2);
        }

        public decimal Round(decimal donationAmount)
        {
            // Gift aid amount correctly rounded to 2 decimal places (1.316 should round to 1.32).
            return Math.Round(donationAmount, 2);
        }
    }
}
