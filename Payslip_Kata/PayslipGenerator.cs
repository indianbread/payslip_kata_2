using System;
using System.Collections.Generic;
using System.Globalization;
using Payslip_Kata.InputOutput;
using Payslip_Kata.models;

namespace Payslip_Kata
{
    public class PayslipGenerator
    {
        public PayslipGenerator(IInput input, IOutput output)
        {
            _input = input;
            _output = output;
        }
        
        private readonly IInput _input;
        private readonly IOutput _output;

        public Employee GetEmployee()
        {
            _output.WriteLine("Please input your first name: ");
            var firstName = _input.ReadLine();
            _output.WriteLine("Please input your surname: ");
            var lastName = _input.ReadLine();
            return new Employee(firstName, lastName);
        }

        public AnnualSalary GetAnnualSalary()
        {

            var amount = TryGetAnnualSalaryAmount();
            var super = TryGetSuperRate();
            
            return new AnnualSalary(super, amount);
        }
        
        public (DateTime, DateTime) GetPayPeriod()
        {
            _output.WriteLine("Please enter your payment start date: ");
            var startDate = TryParseDate(_input.ReadLine());
            _output.WriteLine("Please enter your payment end date: ");
            var endDate = TryParseDate(_input.ReadLine());
            return(startDate, endDate);
        }

        private DateTime TryParseDate(string input)
        {
            var isDateValid = DateTime.TryParse(input, new CultureInfo("en-AU"), DateTimeStyles.None, out var date);
            if (isDateValid) return date;
            _output.WriteLine("Please enter a valid date");
            input = _input.ReadLine();
            return TryParseDate(input);
        }

        private int TryGetAnnualSalaryAmount()
        {
            _output.WriteLine("Please enter your annual salary: ");
            var isAmountValid = int.TryParse(_input.ReadLine(), out var amount);
            if (isAmountValid && amount >= 0) return amount;
            _output.WriteLine("Please enter a valid whole number greater than or equal to 0");
            return TryGetAnnualSalaryAmount();
        }
        
        private double TryGetSuperRate()
        {
            _output.WriteLine("Please enter your super rate: ");
            var isSuperValid = double.TryParse(_input.ReadLine(), out var super);
            if (isSuperValid && super >= 0) return super;
            _output.WriteLine("Please enter a valid number greater than or equal to 0");
            return TryGetSuperRate();
        }


        public Payslip GeneratePayslip(Employee employee, AnnualSalary annualSalary, DateTime startDate, DateTime endDate)
        {
            var payCalculator = new PayCalculator(annualSalary, startDate, endDate);
            var grossIncome = payCalculator.CalculateGrossIncome();
            var incomeTax = payCalculator.CalculateIncomeTax();
            var netIncome = payCalculator.CalculateNetIncome();
            var superAmount = payCalculator.CalculateSuper();
            
            return new Payslip(employee, startDate, endDate, grossIncome, incomeTax, netIncome, superAmount);
        }
    }
}