using FluentAssertions;
using GiftAidCalculator.TestConsole;
using NUnit.Framework;
using System;

namespace GiftAidCalculator.Tests
{
    public class GiftAidCalculatorTests
    {
        [TestCase(100, 25)]
        [TestCase(0, 0)]
        [TestCase(17.50, 4.38)]
        [TestCase(1117.79, 279.45)]
        public void GiftAidIsCalculatedAt20Percent(decimal donationAmount, decimal expectedGiftAidAmount)
        {
            var calculator = new GaCalculator();

            var giftAidAmount = calculator.GiftAidAmount(donationAmount);

            giftAidAmount.Should().Be(expectedGiftAidAmount);
        }


        [TestCase(0)]
        [TestCase(17.50)]
        [TestCase(36.50)]
        public void GiftAidIsRoundedTo2DecimalPlaces(decimal donationAmount)
        {
            var calculator = new GaCalculator();

            var giftAidAmount = calculator.GiftAidAmount(donationAmount);
            var decimalPlaces = giftAidAmount.ToString().Split('.')[1];


            decimalPlaces.Length.Should().Be(2);
        }

        [Test]
        public void ShouldRoundDecimalTo()
        {
            //1.316
            var calculator = new GaCalculator();

            var giftAidAmount = calculator.Round(1.316m);

            giftAidAmount.Should().Be(1.32m);
        }
    }
}
