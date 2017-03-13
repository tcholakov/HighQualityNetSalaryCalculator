namespace NetSalaryCalculator.Contracts
{
    public interface IIncomeTaxCalculator
    {
        double CalculateIncomeTax(double grossSalary);
    }
}
