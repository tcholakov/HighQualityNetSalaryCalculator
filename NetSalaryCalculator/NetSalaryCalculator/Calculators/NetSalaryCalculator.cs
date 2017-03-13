namespace NetSalaryCalculator.Calculators
{
    using System;

    using Contracts;
    using Common;

    public class NetSalaryCalculator : INetSalaryCalculator
    {
        private readonly IIncomeTaxCalculator incomeTaxCalculator;
        private readonly ISocialContributionsCalculator socialContributionsCalculator;

        public NetSalaryCalculator()
            : this(new IncomeTaxCalculator(), new SocialContributionsCalculator())
        { }

        public NetSalaryCalculator(IIncomeTaxCalculator incomeTaxCalculator, ISocialContributionsCalculator socialContributionsCalculator)
        {
            this.incomeTaxCalculator = incomeTaxCalculator;
            this.socialContributionsCalculator = socialContributionsCalculator;
        }

        public double CalculateNetSalary(double grossSalary)
        {
            if(grossSalary < 0)
            {
                throw new ArgumentException(GlobalConstants.NegativeGrossSalaryMessage);
            }

            double incomeTax = this.incomeTaxCalculator.CalculateIncomeTax(grossSalary);
            double socialContributions = this.socialContributionsCalculator.CalculateSocialContributions(grossSalary);

            double netSalary = grossSalary - incomeTax - socialContributions;

            return netSalary;
        }
    }
}
