using System.Collections.Generic;
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
            _formatter = new PayslipFormatter();
            _taxBrackets = TaxData.GetTaxBrackets();
        }
        
        
        private readonly IInput _input;
        private readonly IOutput _output;
        private List<TaxBracket> _taxBrackets;
        private PayslipFormatter _formatter;
    }
}