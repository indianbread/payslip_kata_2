using System.Collections.Generic;
using Payslip_Kata.models;

namespace Payslip_Kata
{
    public static class TaxData
    {
        public static List<TaxBracket> GetTaxBrackets()
        {
            return new List<TaxBracket>
            {
                new TaxBracket(0, 18200, 0,0,0),
                new TaxBracket(18201, 37000, 0, 19, 18200),
                new TaxBracket(37001, 87000, 3572, 32.5, 37000),
                new TaxBracket(87001, 180000, 19822, 37, 87000),
                new TaxBracket(180001, int.MaxValue, 54232, 45, 180000)
            };
        }
    }
}