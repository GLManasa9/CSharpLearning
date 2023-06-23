using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankProject.SOLID
{

    public interface ISalaryCalculator
    {
        float CalculateSalary(int hoursWorked, float hourlyRate);
    }

    public interface IEarnedLeavesCalculator
    {
        int CalculateEarnedLeaves(int daysWorked);
    }

    internal class SalaryCalculator : ISalaryCalculator
    {
        public float CalculateSalary(int hoursWorked, float hourlyRate) => hoursWorked * hourlyRate;
    }

    internal class EarnedLeavesCalculator : IEarnedLeavesCalculator
    {
        public int CalculateEarnedLeaves(int daysWorked) => daysWorked / 4;
    }

    internal class EmployeeDetails
    {
        private readonly ISalaryCalculator _salaryCalculator;

        private readonly IEarnedLeavesCalculator _earnedLeavesCalculator;
        public int HoursWorked { get; set; }
        public float HourlyRate { get; set; }
        public int DaysWorked { get; set; }

        public EmployeeDetails(ISalaryCalculator salaryCalculator)
        {
            _salaryCalculator = salaryCalculator;
        }

        public EmployeeDetails(ISalaryCalculator salaryCalculator, IEarnedLeavesCalculator earnedLeavesCalculator)
        {
            _salaryCalculator = salaryCalculator;
            _earnedLeavesCalculator = earnedLeavesCalculator;
        }

        public float GetSalary()
        {
            return _salaryCalculator.CalculateSalary(HoursWorked, HourlyRate);
        }

        public float GetEarnedLeaves()
        {
            return _earnedLeavesCalculator.CalculateEarnedLeaves(DaysWorked);
        }

    }

    public class DIP
    {
        [Test]
        public void DIP_method()
        {
            EmployeeDetails employeeDetails = new EmployeeDetails(new SalaryCalculator())
            {
                HoursWorked = 1,
                HourlyRate = 150
            };
            Console.WriteLine($"Employee Salary={employeeDetails.GetSalary()}");
            EmployeeDetails employeeDetails1 = new EmployeeDetails(new SalaryCalculator(), new EarnedLeavesCalculator())
            {
                DaysWorked = 60
            };
            Console.WriteLine($"Earned Leaves={employeeDetails1.GetEarnedLeaves()}");
        }
    }


}
