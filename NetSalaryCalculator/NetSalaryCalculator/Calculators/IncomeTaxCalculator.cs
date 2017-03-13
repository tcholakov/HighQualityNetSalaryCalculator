namespace NetSalaryCalculator.Calculators
{
    using System;

    using Common;
    using Contracts;

    public class IncomeTaxCalculator : IIncomeTaxCalculator
    {
        public double CalculateIncomeTax(double grossSalary)
        {
            if (grossSalary < 0)
            {
                throw new ArgumentException(GlobalConstants.NegativeGrossSalaryMessage);
            }

            if (grossSalary <= GlobalConstants.MinGrossSalary)
            {
                return 0;
            }

            double incomeTax = (grossSalary - GlobalConstants.MinGrossSalary) * GlobalConstants.IncomeTaxPercent / 100;

            return incomeTax;
        }
    }
}
