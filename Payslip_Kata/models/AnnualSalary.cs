using System;

namespace Payslip_Kata.models
{
    public class AnnualSalary
    {
        public AnnualSalary(Guid employeeId, int superRate, int annualAmount)
        {
            EmployeeId = employeeId;
            SuperRate = superRate;
            AnnualAmount = annualAmount;
        }
        public Guid EmployeeId { get; }
        public int SuperRate { get; }
        public int AnnualAmount { get; }
    }
}