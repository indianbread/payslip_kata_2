using System;

namespace Payslip_Kata.models
{
    public class AnnualSalary
    {
        public AnnualSalary(double superRate, int amount)
        {
            SuperRate = superRate;
            Amount = amount;
        }
        public double SuperRate { get; }
        public int Amount { get; }
    }
}