using System;

namespace Payslip_Kata.models
{
    public class Payslip
    {
        public Payslip(Employee employee, DateTime startDate, DateTime endDate, decimal grossIncome, decimal incomeTax, decimal netIncome, decimal superAmount)
        {
            Employee = employee;
            StartDate = startDate;
            EndDate = endDate;
            GrossIncome = grossIncome;
            IncomeTax = incomeTax;
            NetIncome = netIncome;
            SuperAmount = superAmount;
            PaySlipNumber = Guid.NewGuid();
        }

        public Guid PaySlipNumber { get; }
        public Employee Employee { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        public decimal GrossIncome { get; }
        public decimal IncomeTax { get; }
        public decimal NetIncome { get; }
        public decimal SuperAmount { get; }
    }
}