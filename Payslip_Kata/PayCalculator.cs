using System;
using System.Collections.Generic;
using System.Linq;
using Payslip_Kata.models;

namespace Payslip_Kata
{
    public class PayCalculator
    {
        public PayCalculator()
        {
            _taxBrackets = TaxData.GetTaxBrackets();
        }
        
        public decimal CalculateIncomeTax(AnnualSalary annualSalary, DateTime startDate, DateTime endDate)
        {
            var payPeriodInMonths = CalculateMonths(startDate, endDate);
            var annualIncomeTax = CalculateAnnualIncomeTax(annualSalary);
            var incomeTax = (annualIncomeTax / 12) * Convert.ToDecimal(payPeriodInMonths);
            return Math.Round(incomeTax, 0, MidpointRounding.AwayFromZero);
        }
        
        public decimal CalculateGrossIncome(AnnualSalary annualSalary, DateTime startDate, DateTime endDate)
        {
            var payPeriodInMonths = CalculateMonths(startDate, endDate);
            var grossIncome = annualSalary.Amount / 12 * Convert.ToDecimal(payPeriodInMonths);
            return Math.Round(grossIncome, 0, MidpointRounding.ToZero);
        }
        
        public decimal CalculateNetIncome(AnnualSalary annualSalary, DateTime startDate, DateTime endDate)
        {
            var grossIncome = CalculateGrossIncome(annualSalary, startDate, endDate);
            var incomeTax = CalculateIncomeTax(annualSalary, startDate, endDate);
            return grossIncome - incomeTax;
        }
        
        public decimal CalculateSuper(AnnualSalary annualSalary, DateTime startDate, DateTime endDate)
        {
            var grossIncome = CalculateGrossIncome(annualSalary, startDate, endDate);
            var super = grossIncome * Convert.ToDecimal(annualSalary.SuperRate / 100);
            return Math.Round(super, 0, MidpointRounding.ToZero);
        }
        
        private static double CalculateMonths(DateTime startDate, DateTime endDate)
        {
            return (endDate - startDate).TotalDays / (365 / 12);
        }

        private decimal CalculateAnnualIncomeTax(AnnualSalary annualSalary)
        {
            var taxBracket = GetTaxBracket(annualSalary);
            var additionalAmount = (annualSalary.Amount - taxBracket.Threshold) * (Convert.ToDecimal(taxBracket.RateInCents) / 100);
            return taxBracket.BaseAmount + additionalAmount;
        }
        
        private TaxBracket GetTaxBracket(AnnualSalary annualSalary)
        {
            return _taxBrackets.FirstOrDefault(taxBracket =>
                annualSalary.Amount >= taxBracket.LowerLimit && annualSalary.Amount <= taxBracket.UpperLimit);
        }

        private readonly List<TaxBracket> _taxBrackets;
        
    }
}