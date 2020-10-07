using System;
using Moq;
using Payslip_Kata.InputOutput;
using Payslip_Kata.models;
using Xunit;

namespace Payslip_Kata.Tests
{
    public class PayslipGeneratorShould
    {
        public PayslipGeneratorShould()
        {
            _mockInput = new Mock<IInput>();
            _mockOutput = new Mock<IOutput>();
            _sut = new PayslipGenerator(_mockInput.Object, _mockOutput.Object);
        }
        
        private Mock<IInput> _mockInput;
        private Mock<IOutput> _mockOutput;
        private PayslipGenerator _sut;

        [Fact]
        public void CreateAnEmployeeFromGivenInput()
        {
            _mockInput.SetupSequence(input => input.ReadLine())
                .Returns("John")
                .Returns("Doe");

            var actual = _sut.GetEmployee();
            
            Assert.Equal("John", actual.FirstName);
            Assert.Equal("Doe", actual.LastName);
        }

        [Fact]
        public void CreateAnnualSalaryFromGivenInput()
        {
            _mockInput.SetupSequence(input => input.ReadLine())
                .Returns("60050")
                .Returns("9");

            var actual = _sut.GetAnnualSalary();
            
            Assert.Equal(60050, actual.Amount);
            Assert.Equal(9, actual.SuperRate);

        }

        [Fact]
        public void ParseStringToDateFromInput()
        {
            _mockInput.SetupSequence(input => input.ReadLine())
                .Returns("1 March")
                .Returns("31 March");

            var actual = _sut.GetPayPeriod();
            
            Assert.Equal(new DateTime(2020, 03, 01).Month, actual.Item1.Month );
            Assert.Equal(new DateTime(2020, 03, 01).Day, actual.Item1.Day );
            Assert.Equal(new DateTime(2020, 03, 31).Month, actual.Item2.Month );
            Assert.Equal(new DateTime(2020, 03, 31).Day, actual.Item2.Day );
        }

        [Fact]
        public void GeneratePayslip()
        {
            var employee = new Employee("John", "Doe");
            var annualSalary = new AnnualSalary(9, 60050);
            var startDate = new DateTime(2020, 03, 01);
            var endDate = new DateTime(2020, 03, 31);

            var actual = _sut.GeneratePayslip(employee, annualSalary, startDate, endDate);
            
            Assert.Equal("John", actual.Employee.FirstName);
            Assert.Equal("Doe", actual.Employee.LastName);
            Assert.Equal(startDate, actual.StartDate);
            Assert.Equal(endDate, actual.EndDate);
            Assert.Equal(5004, actual.GrossIncome);
            Assert.Equal(922, actual.IncomeTax);
            Assert.Equal(4082, actual.NetIncome);
            Assert.Equal(450, actual.SuperAmount);
            
        }
    }
}