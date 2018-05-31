using FluentAssertions;
using GiftAidCalculator.TestConsole;
using NUnit.Framework;
using Moq;
using System;
using GiftAidCalculator.TestConsole.Repository;
using GiftAidCalculator.TestConsole.EventSupplement;

namespace GiftAidCalculator.Tests
{
    public class GiftAidCalculatorTests
    {
        private GaCalculator CreateCalculator(decimal taxRate)
        {
            Mock<IRepository<decimal>> mockTaxRateRepository = new Mock<IRepository<decimal>>();
            mockTaxRateRepository.Setup(repo => repo.Get()).Returns(taxRate);
            return new GaCalculator(mockTaxRateRepository.Object);
        }

        [TestCase(0, ExpectedResult = 0)]
        [TestCase(17.50, ExpectedResult = 1.94)]
        [TestCase(100, ExpectedResult = 11.11)]
        [TestCase(1117.79, ExpectedResult = 124.20)]
        public decimal GiftAidIsCalculatedAt10Percent(decimal donationAmount)
        {
            var calculator = CreateCalculator(10m);

            return calculator.GiftAidAmount(donationAmount);
        }

        [TestCase(100, ExpectedResult = 25)]
        [TestCase(0, ExpectedResult = 0)]
        [TestCase(17.50, ExpectedResult = 4.38)]
        [TestCase(1117.79, ExpectedResult = 279.45)]
        public decimal GiftAidIsCalculatedAt20Percent(decimal donationAmount)
        {
            var calculator = CreateCalculator(20m);

            return calculator.GiftAidAmount(donationAmount);
        }
        
        [TestCase(0)]
        [TestCase(17.50)]
        [TestCase(36.50)]
        public void GiftAidIsRoundedTo2DecimalPlaces(decimal donationAmount)
        {
            var calculator = CreateCalculator(20m);

            var giftAidAmount = calculator.GiftAidAmount(donationAmount);
            var decimalPlaces = giftAidAmount.ToString().Split('.')[1];

            decimalPlaces.Length.Should().Be(2);
        }

        [TestCase(0, ExpectedResult = 0)]
        [TestCase(1.316, ExpectedResult = 1.32)]
        [TestCase(1.315, ExpectedResult = 1.32)]
        [TestCase(1.314, ExpectedResult = 1.31)]
        [TestCase(1.313, ExpectedResult = 1.31)]
        public decimal RoundAmountToValidUpperOrLower(decimal amount)
        {
            var calculator = CreateCalculator(20m);

            return calculator.Round(amount);
        }

        [TestCase(25, ExpectedResult = 1.25)]
        [TestCase(100, ExpectedResult = 5)]
        [TestCase(199, ExpectedResult = 9.95)]
        public decimal CalculateSuplimentForRunningEvents(decimal donationAmount)
        {
            var calculator = CreateCalculator(20m);

            return calculator.SupplementAmount(donationAmount, new Running());
        }

        [TestCase(25, ExpectedResult = 0.75)]
        [TestCase(100, ExpectedResult = 3)]
        [TestCase(199, ExpectedResult = 5.97)]
        public decimal CalculateSuplimentForSwimmingEvents(decimal donationAmount)
        {
            var calculator = CreateCalculator(20m);

            return calculator.SupplementAmount(donationAmount, new Swimming());
        }

        public void CalculateSuplimentForNonSupplementedEvents(decimal donationAmount)
        {
            var calculator = CreateCalculator(20m);

            var supplement = calculator.SupplementAmount(donationAmount);

            supplement.Should().Be(0);
        }
    }
}
