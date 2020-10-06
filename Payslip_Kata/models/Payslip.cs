using System;

namespace Payslip_Kata.models
{
    public class Payslip
    {
        public Payslip(DateTime startDate, Employee employee, AnnualSalary annualSalary, decimal grossIncome, decimal netIncome, decimal superAmount, decimal incomeTax, Guid paySlipNumber)
        {
            StartDate = startDate;
            Employee = employee;
            AnnualSalary = annualSalary;
            GrossIncome = grossIncome;
            NetIncome = netIncome;
            SuperAmount = superAmount;
            IncomeTax = incomeTax;
            PaySlipNumber = Guid.NewGuid();
        }
        public Guid PaySlipNumber { get; }
        public DateTime StartDate { get; }
        public Employee Employee { get; }
        public AnnualSalary AnnualSalary { get; }
        public decimal GrossIncome { get; }
        public decimal NetIncome { get; }
        public decimal SuperAmount { get; }
        public decimal IncomeTax { get; }
        
    }
}