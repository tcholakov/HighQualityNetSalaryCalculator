namespace NetSalaryCalculator.Tests.SocialContributionsCalculatorTests
{
    using System;

    using NUnit.Framework;

    using Calculators;
    using Common;

    [TestFixture]
    public class SocialContributionsCalculator_Tests
    {
        [Test]
        public void CalculateSocialContributions_ShouldReturn0_IfGrossSalaryIsBelowMinGrossSalary()
        {
            //Arrange
            SocialContributionsCalculator socialContributionsCalculator = new SocialContributionsCalculator();

            double grossSalaryBelowMin = GlobalConstants.MinGrossSalary - 1;
            double expectedSocialContributions = 0;

            //Action
            double resultSocialContributions = socialContributionsCalculator.CalculateSocialContributions(grossSalaryBelowMin);

            //Assert
            Assert.AreEqual(expectedSocialContributions, resultSocialContributions, $"Result social contributions was not equal to {expectedSocialContributions}");
        }

        [Test]
        public void CalculateSocialContributions_ShouldThrowArgumentException_IfGrossSalaryIsNegative()
        {
            //Arrange
            SocialContributionsCalculator socialContributionsCalculator = new SocialContributionsCalculator();

            double grossSalaryNegative = -1;
            
            //Action
            var exception = Assert.Throws<ArgumentException>(() => socialContributionsCalculator.CalculateSocialContributions(grossSalaryNegative));

            //Assert
            Assert.That(exception.Message, Is.EqualTo(GlobalConstants.NegativeGrossSalaryMessage));
        }

        [Test]
        public void CalculateSocialContributions_ShouldReturnMaxGrossSalarySocialContributions_IfGrossSalaryIsAboveMaxGrossSalary()
        {
            //Arrange
            SocialContributionsCalculator socialContributionsCalculator = new SocialContributionsCalculator();

            double grossSalaryAboveMaxGrossSalary = GlobalConstants.MaxGrossSalaryForSocialContributions + 1;

            double expectedSocialContributions = (GlobalConstants.MaxGrossSalaryForSocialContributions - GlobalConstants.MinGrossSalary) * GlobalConstants.SocialContributionsPercent / 100;

            //Action
            double resultSocialContributions = socialContributionsCalculator.CalculateSocialContributions(grossSalaryAboveMaxGrossSalary);

            //Assert
            Assert.AreEqual(expectedSocialContributions, resultSocialContributions, $"Result social contributions was not equal to {expectedSocialContributions}");
        }

        [Test]
        public void CalculateSocialContributions_ShouldReturnValidSocialContributions_IfGrossSalaryIsAboveMinAndBelowMaxGrossSalary()
        {
            //Arrange
            SocialContributionsCalculator socialContributionsCalculator = new SocialContributionsCalculator();

            double grossSalaryAboveMinAndBelowMax = GlobalConstants.MinGrossSalary + 1;

            double expectedSocialContributions = (grossSalaryAboveMinAndBelowMax - GlobalConstants.MinGrossSalary) * GlobalConstants.SocialContributionsPercent / 100;

            //Action
            double resultSocialContributions = socialContributionsCalculator.CalculateSocialContributions(grossSalaryAboveMinAndBelowMax);

            //Assert
            Assert.AreEqual(expectedSocialContributions, resultSocialContributions, $"Result social contributions was not equal to {expectedSocialContributions}");
        }
    }
}
