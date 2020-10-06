using System;

namespace Payslip_Kata.models
{
    public class AnnualSalary
    {
        public AnnualSalary(Guid employeeId, double superRate, int amount)
        {
            EmployeeId = employeeId;
            SuperRate = superRate;
            Amount = amount;
        }
        public Guid EmployeeId { get; }
        public double SuperRate { get; }
        public int Amount { get; }
    }
}