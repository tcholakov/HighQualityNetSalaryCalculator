namespace NetSalaryCalculator
{
    using System;

    using Calculators;
    using Contracts;

    public class StartUp
    {
        static void Main(string[] args)
        {
            INetSalaryCalculator netSalaryCalculator = new NetSalaryCalculator();

            Console.Write("Input gross salary: ");
            double grossSalary = double.Parse(Console.ReadLine());
            
            double netSalary = netSalaryCalculator.CalculateNetSalary(grossSalary);

            Console.WriteLine($"Net salary: {netSalary}");
        }
    }
}
