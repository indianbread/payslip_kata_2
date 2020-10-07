using System;
using Payslip_Kata.models;

namespace Payslip_Kata
{
    public class PayslipFormatter
    {
        public string FormatPayslipString(Payslip payslip)
        {
            var payslipOutput = "";
            payslipOutput += "Name: " + payslip.Employee.FirstName + " " + payslip.Employee.LastName + Environment.NewLine;
            payslipOutput += "Pay Period: " + payslip.StartDate.ToString("dd MMMM") + " - " +
                             payslip.EndDate.ToString("dd MMMM") + Environment.NewLine;
            payslipOutput += "Gross Income: " + payslip.GrossIncome + Environment.NewLine;
            payslipOutput += "Income Tax: " + payslip.IncomeTax + Environment.NewLine;
            payslipOutput += "Net Income: " + payslip.NetIncome + Environment.NewLine;
            payslipOutput += "Super: " + payslip.SuperAmount;
            return payslipOutput;
        }
        
        
        
    }
}