namespace NetSalaryCalculator.Calculators
{
    using System;

    using Contracts;
    using Common;

    public class SocialContributionsCalculator : ISocialContributionsCalculator
    {
        public double CalculateSocialContributions(double grossSalary)
        {
            if (grossSalary < 0)
            {
                throw new ArgumentException(GlobalConstants.NegativeGrossSalaryMessage);
            }

            if (grossSalary <= GlobalConstants.MinGrossSalary)
            {
                return 0;
            }

            if (grossSalary > GlobalConstants.MaxGrossSalaryForSocialContributions)
            {
                grossSalary = GlobalConstants.MaxGrossSalaryForSocialContributions;
            }

            double socialContributions = (grossSalary - GlobalConstants.MinGrossSalary) * GlobalConstants.SocialContributionsPercent / 100;

            return socialContributions;
        }
    }
}
