using System;
using Payslip_Kata.models;
using Xunit;

namespace Payslip_Kata.Tests
{
    public class CalculatorShould
    {
        public CalculatorShould()
        {
            _startDate = new DateTime(2020, 03, 01);
            _endDate = new DateTime(2020, 03, 31);
            _annualSalary = new AnnualSalary(9, 60050 );
            _sut = new PayCalculator();
        }
        private readonly PayCalculator _sut;
        private readonly DateTime _startDate;
        private readonly DateTime _endDate;
        private readonly AnnualSalary _annualSalary;

        [Fact]
        public void CalculateGrossIncome()
        {
            const int expected = 5004;
            var actual = _sut.CalculateGrossIncome(_annualSalary, _startDate, _endDate);
            
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void CalculateIncomeTax()
        {
            const int expected = 922;
            var actual = _sut.CalculateIncomeTax(_annualSalary, _startDate, _endDate);
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculateNetIncome()
        {
            const int expected = 4082;
            var actual = _sut.CalculateNetIncome(_annualSalary, _startDate, _endDate);
            
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void CalculateSuperAmount()
        {
            const int expected = 450;
            var actual = _sut.CalculateSuper(_annualSalary, _startDate, _endDate);
            
            Assert.Equal(expected, actual);
        }
        
    }
}