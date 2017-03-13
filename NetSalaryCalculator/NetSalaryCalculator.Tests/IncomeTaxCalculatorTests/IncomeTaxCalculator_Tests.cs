namespace NetSalaryCalculator.Tests.IncomeTaxCalculatorTests
{
    using System;
    
    using NUnit.Framework;

    using Calculators;
    using Common;
    
    [TestFixture]
    public class IncomeTaxCalculator_Tests
    {
        [Test]
        public void CalculateIncomeTax_ShouldReturn0_IfGrossSalaryIsBelowOrMinGrossSalary()
        {
            //Arrange
            IncomeTaxCalculator incomeTaxCalculator = new IncomeTaxCalculator();

            double grossSalaryBelowOrMin = GlobalConstants.MinGrossSalary - 1;
            double expectedIncomeTax = 0;

            //Action
            double resultIncomeTax = incomeTaxCalculator.CalculateIncomeTax(grossSalaryBelowOrMin);

            //Assert
            Assert.AreEqual(expectedIncomeTax, resultIncomeTax, $"Result income tax was not equal to {expectedIncomeTax}");
        }

        [Test]
        public void CalculateIncomeTax_ShouldThrowArgumentException_IfGrossSalaryIsNegative()
        {
            //Arrange
            double grossSalaryNegative = -1;

            IncomeTaxCalculator incomeTaxCalculator = new IncomeTaxCalculator();

            //Action
            var exception = Assert.Throws<ArgumentException>(() => incomeTaxCalculator.CalculateIncomeTax(grossSalaryNegative));

            //Assert
            Assert.That(exception.Message, Is.EqualTo(GlobalConstants.NegativeGrossSalaryMessage));
        }

        [Test]
        public void CalculateIncomeTax_ShouldReturnValidIncomeTax_IfGrossSalaryIsAboveMinGrossSalary()
        {
            //Arrange
            IncomeTaxCalculator incomeTaxCalculator = new IncomeTaxCalculator();

            double grossSalaryAboveMinGrossSalary = GlobalConstants.MinGrossSalary + 1;
            double expectedIncomeTax = (grossSalaryAboveMinGrossSalary - GlobalConstants.MinGrossSalary) * GlobalConstants.IncomeTaxPercent / 100;

            //Action
            double resultIncomeTax = incomeTaxCalculator.CalculateIncomeTax(grossSalaryAboveMinGrossSalary);

            //Assert
            Assert.AreEqual(expectedIncomeTax, resultIncomeTax, $"Result income tax was not equal to {expectedIncomeTax}");
        }
    }
}
