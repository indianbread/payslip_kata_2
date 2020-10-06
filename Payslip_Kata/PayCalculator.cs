using System;
using System.Collections.Generic;
using System.Linq;
using Payslip_Kata.models;

namespace Payslip_Kata
{
    public class PayCalculator
    {
        public PayCalculator(AnnualSalary annualSalary, DateTime startDate, DateTime endDate)
        {
            _annualSalary = annualSalary;
            _startDate = startDate;
            _endDate = endDate;
            _payPeriodInMonths = CalculateMonths(_startDate, _endDate);
            _taxBrackets = TaxData.GetTaxBrackets();
        }
        
        public decimal CalculateIncomeTax()
        {
            var annualIncomeTax = CalculateAnnualIncomeTax();
            var incomeTax = (annualIncomeTax / 12) * Convert.ToDecimal(_payPeriodInMonths);
            return Math.Round(incomeTax, 0, MidpointRounding.AwayFromZero);
        }
        
        public decimal CalculateGrossIncome()
        {
            var grossIncome = _annualSalary.Amount / 12 * Convert.ToDecimal(_payPeriodInMonths);
            return Math.Round(grossIncome, 0, MidpointRounding.ToZero);
        }
        
        public decimal CalculateNetIncome()
        {
            var grossIncome = CalculateGrossIncome();
            var incomeTax = CalculateIncomeTax();

            return grossIncome - incomeTax;
        }
        
        public decimal CalculateSuper()
        {
            var grossIncome = CalculateGrossIncome();
            var super = grossIncome * Convert.ToDecimal(_annualSalary.SuperRate / 100);
            return Math.Round(super, 0, MidpointRounding.ToZero);
        }
        
        private static double CalculateMonths(DateTime startDate, DateTime endDate)
        {
            return (endDate - startDate).TotalDays / (365 / 12);
        }

        private decimal CalculateAnnualIncomeTax()
        {
            var taxBracket = GetTaxBracket(_annualSalary.Amount);
            var additionalAmount = (_annualSalary.Amount - taxBracket.Threshold) * (Convert.ToDecimal(taxBracket.RateInCents) / 100);
            return taxBracket.BaseAmount + additionalAmount;
        }
        
        private TaxBracket GetTaxBracket(int annualSalary)
        {
            return _taxBrackets.FirstOrDefault(taxBracket =>
                annualSalary >= taxBracket.LowerLimit && annualSalary <= taxBracket.UpperLimit);
        }

        private readonly List<TaxBracket> _taxBrackets;
        private readonly AnnualSalary _annualSalary;
        private readonly DateTime _startDate;
        private readonly DateTime _endDate;
        private readonly double _payPeriodInMonths;
        
    }
}