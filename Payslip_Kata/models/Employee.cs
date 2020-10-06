using System;

namespace Payslip_Kata.models
{
    public class Employee
    {
        public Employee(string firstName, string lastName)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
        }
        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
    }
}