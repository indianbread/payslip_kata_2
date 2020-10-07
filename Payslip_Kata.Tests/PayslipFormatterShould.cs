using System;
using Payslip_Kata.models;
using Xunit;

namespace Payslip_Kata.Tests
{
    public class PayslipFormatterShould
    {
        [Fact]
        public void FormatPayslipToString()
        {
            var employee = new Employee("John", "Doe");
            var startDate = new DateTime(202, 03, 01);
            var endDate = new DateTime(2020, 03, 31);
            var payslip = new Payslip(employee, startDate ,endDate , 5004, 922, 4082, 450 );
            var sut = new PayslipFormatter();

            var expected = "Name: John Doe" + Environment.NewLine +
                           "Pay Period: 01 March - 31 March" + Environment.NewLine +
                           "Gross Income: 5004" + Environment.NewLine +
                           "Income Tax: 922" + Environment.NewLine +
                           "Net Income: 4082" + Environment.NewLine +
                           "Super: 450";
            var actual = sut.FormatPayslipString(payslip);
            
            Assert.Equal(expected, actual);
        }
        

    }
}