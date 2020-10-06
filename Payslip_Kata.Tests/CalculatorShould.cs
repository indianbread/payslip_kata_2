using System;
using Xunit;

namespace Payslip_Kata.Tests
{
    public class CalculatorShould
    {
        public CalculatorShould()
        {
            var startDate = new DateTime(2020, 03, 01);
            var endDate = new DateTime(2020, 03, 31);
            _sut = new PayCalculator(60050, startDate, endDate);
        }
        private readonly PayCalculator _sut;
        
        [Fact]
        public void CalculateGrossIncome()
        {
            const int expected = 5004;
            var actual = _sut.CalculateGrossIncome();
            
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void CalculateIncomeTax()
        {
            const int expected = 922;
            var actual = _sut.CalculateIncomeTax();
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculateNetIncome()
        {
            const int expected = 4082;
            var actual = _sut.CalculateNetIncome();
            
            Assert.Equal(expected, actual);

        }
        
    }
}