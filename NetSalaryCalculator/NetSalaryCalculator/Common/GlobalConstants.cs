namespace NetSalaryCalculator.Common
{
    public static class GlobalConstants
    {
        public const double IncomeTaxPercent = 10;
        public const double SocialContributionsPercent = 15;

        public const double MinGrossSalary = 1000;
        public const double MaxGrossSalaryForSocialContributions = 3000;

        public const string NegativeGrossSalaryMessage = "Gross salary should not be negative.";
    }
}
