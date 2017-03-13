namespace NetSalaryCalculator.Tests.NetSalaryCalculatorTests
{
    using System;
    
    using NUnit.Framework;
    using Moq;
    
    using Calculators;
    using Contracts;
    using Common;

    [TestFixture]
    public class NetSalaryCalculator_Tests
    {
        [Test]
        public void CalculateNetSalary_ShouldReturnGrossSalary_IfIncomeTaxIs0AndSocialContributionsIs0()
        {
            //Arrange
            double grossSalaryBelowMin = GlobalConstants.MinGrossSalary - 1;

            var mockedIncomeTaxCalculator = new Mock<IIncomeTaxCalculator>();
            mockedIncomeTaxCalculator.Setup(x => x.CalculateIncomeTax(grossSalaryBelowMin)).Returns(0);

            var mockedSocialContributionsCalculator = new Mock<ISocialContributionsCalculator>();
            mockedSocialContributionsCalculator.Setup(x => x.CalculateSocialContributions(grossSalaryBelowMin)).Returns(0);

            NetSalaryCalculator netSalaryCalculator = new NetSalaryCalculator(mockedIncomeTaxCalculator.Object, mockedSocialContributionsCalculator.Object);

            //Action
            double resultNetSalary = netSalaryCalculator.CalculateNetSalary(grossSalaryBelowMin);

            //Assert
            Assert.AreEqual(grossSalaryBelowMin, resultNetSalary, $"Result net salary is not equal to {grossSalaryBelowMin}");
        }

        [Test]
        public void CalculateNetSalary_ShouldThrowArgumentException_IfGrossSalaryIsNegative()
        {
            //Arrange
            double grossSalaryNegative = -1;

            var mockedIncomeTaxCalculator = new Mock<IIncomeTaxCalculator>();
            var mockedSocialContributionsCalculator = new Mock<ISocialContributionsCalculator>();

            NetSalaryCalculator netSalaryCalculator = new NetSalaryCalculator(mockedIncomeTaxCalculator.Object, mockedSocialContributionsCalculator.Object);
            
            //Action
            var exception = Assert.Throws<ArgumentException>(() => netSalaryCalculator.CalculateNetSalary(grossSalaryNegative));

            //Assert
            Assert.That(exception.Message, Is.EqualTo(GlobalConstants.NegativeGrossSalaryMessage));
        }

        [Test]
        public void CalculateNetSalary_ShouldReturnNetSalaryWithIncomeTaxAndSocialContributionsTax_IfGrossSalaryIsAboveMinAndBelowMaxGrossSalary()
        {
            //Arrange
            double grossSalaryAboveMinAndBelowMax = GlobalConstants.MinGrossSalary + 1;

            double incomeTax = (grossSalaryAboveMinAndBelowMax - GlobalConstants.MinGrossSalary) * GlobalConstants.IncomeTaxPercent / 100;
            var mockedIncomeTaxCalculator = new Mock<IIncomeTaxCalculator>();
            mockedIncomeTaxCalculator.Setup(x => x.CalculateIncomeTax(grossSalaryAboveMinAndBelowMax)).Returns(incomeTax);

            double socialContributions = (grossSalaryAboveMinAndBelowMax - GlobalConstants.MinGrossSalary) * GlobalConstants.SocialContributionsPercent / 100;
            var mockedSocialContributionsCalculator = new Mock<ISocialContributionsCalculator>();
            mockedSocialContributionsCalculator.Setup(x => x.CalculateSocialContributions(grossSalaryAboveMinAndBelowMax)).Returns(socialContributions);

            NetSalaryCalculator netSalaryCalculator = new NetSalaryCalculator(mockedIncomeTaxCalculator.Object, mockedSocialContributionsCalculator.Object);

            double expectedNetSalary = grossSalaryAboveMinAndBelowMax - incomeTax - socialContributions;

            //Action
            double resultNetSalary = netSalaryCalculator.CalculateNetSalary(grossSalaryAboveMinAndBelowMax);

            //Assert
            Assert.AreEqual(expectedNetSalary, resultNetSalary, $"Result net salary is not equal to {expectedNetSalary}");
        }

        [Test]
        public void CalculateNetSalary_ShouldReturnNetSalaryWithIncomeTaxAndMaxSocialContributionsTax_IfGrossSalaryIsAboveMaxGrossSalary()
        {
            //Arrange
            double grossSalaryAboveMax = GlobalConstants.MaxGrossSalaryForSocialContributions + 1;

            double incomeTax = (grossSalaryAboveMax - GlobalConstants.MinGrossSalary) * GlobalConstants.IncomeTaxPercent / 100;
            var mockedIncomeTaxCalculator = new Mock<IIncomeTaxCalculator>();
            mockedIncomeTaxCalculator.Setup(x => x.CalculateIncomeTax(grossSalaryAboveMax)).Returns(incomeTax);

            double socialContributions = (GlobalConstants.MaxGrossSalaryForSocialContributions - GlobalConstants.MinGrossSalary) * GlobalConstants.SocialContributionsPercent / 100;
            var mockedSocialContributionsCalculator = new Mock<ISocialContributionsCalculator>();
            mockedSocialContributionsCalculator.Setup(x => x.CalculateSocialContributions(grossSalaryAboveMax)).Returns(socialContributions);

            NetSalaryCalculator netSalaryCalculator = new NetSalaryCalculator(mockedIncomeTaxCalculator.Object, mockedSocialContributionsCalculator.Object);

            double expectedNetSalary = grossSalaryAboveMax - incomeTax - socialContributions;

            //Action
            double resultNetSalary = netSalaryCalculator.CalculateNetSalary(grossSalaryAboveMax);

            //Assert
            Assert.AreEqual(expectedNetSalary, resultNetSalary, $"Result net salary is not equal to {expectedNetSalary}");
        }
    }
}
