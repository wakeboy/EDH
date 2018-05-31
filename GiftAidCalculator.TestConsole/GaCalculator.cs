using GiftAidCalculator.TestConsole.EventSupplement;
using GiftAidCalculator.TestConsole.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace GiftAidCalculator.TestConsole
{
    public class GaCalculator
    {
        private IRepository<decimal> taxRateRepository;
        private readonly decimal taxRate;

        public GaCalculator(IRepository<decimal> taxRateRepository)
        {
            this.taxRateRepository = taxRateRepository;
            taxRate = taxRateRepository.Get();
        }

        public decimal GiftAidAmount(decimal donationAmount)
        {
            var gaRatio = taxRate / (100m - taxRate);
            decimal giftAidAmount = Round(donationAmount * gaRatio);
            return giftAidAmount;
        }

        public decimal Round(decimal donationAmount)
        {
            return Math.Round(donationAmount, 2, MidpointRounding.AwayFromZero) + 0.00M;
        }
        
        /// <summary>
        /// Calculate the supliment amount for an event type
        /// </summary>
        /// <param name="donationAmount"></param>
        /// <param name="eventType"></param>
        /// <returns></returns>
        public decimal SupplementAmount(decimal donationAmount, ISupplementEventType eventType = null) 
        {
            if (eventType == null)
            {
                return 0.00m;
            }

            return Round(donationAmount * (eventType.Percentage / 100));
        }
    }
}
