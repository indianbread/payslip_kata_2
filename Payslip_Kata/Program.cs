using System;
using Payslip_Kata.InputOutput;

namespace Payslip_Kata
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new ConsoleInput();
            var output = new ConsoleOutput();
            
            output.WriteLine("Welcome to the payslip generator!" + Environment.NewLine);
            var payCalculator = new PayCalculator();
            var payslipGenerator = new PayslipGenerator(input, output, payCalculator);

            var employee = payslipGenerator.GetEmployee();
            var annualSalary = payslipGenerator.GetAnnualSalary();
            var (startDate, endDate) = payslipGenerator.GetPayPeriod();
            var payslip = payslipGenerator.GeneratePayslip(employee, annualSalary, startDate, endDate);
            
            var payslipFormatter = new PayslipFormatter();
            output.WriteLine(Environment.NewLine + "Your payslip has been generated:" + Environment.NewLine);
            output.WriteLine(payslipFormatter.FormatPayslipString(payslip));
            output.WriteLine("Thank you for using MYOB!" + Environment.NewLine);
        }
    }
}