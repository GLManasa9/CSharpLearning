using NUnit.Framework;
using System;

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

    public interface IEarnedLeavesSalaryCalculator
    {
        float CalculateEarnedLeavesSalary(int daysWorked, float hourlyRate);
    }

    internal class SalaryCalculator : ISalaryCalculator
    {
        public float CalculateSalary(int hoursWorked, float hourlyRate) => hoursWorked * hourlyRate;
    }

    internal class EarnedLeavesCalculator : IEarnedLeavesCalculator
    {
        public int CalculateEarnedLeaves(int daysWorked) => daysWorked / 4;
    }

    internal class EarnedLeavesSalaryCalculator : IEarnedLeavesSalaryCalculator
    {
        public float CalculateEarnedLeavesSalary(int daysWorked, float hourlyRate) => (daysWorked * hourlyRate)/8;
    }


    internal class EmployeeDetails
    {
        private readonly ISalaryCalculator _salaryCalculator;

        private readonly IEarnedLeavesCalculator _earnedLeavesCalculator;

        private readonly IEarnedLeavesSalaryCalculator _earnedLeavesSalaryCalculator;
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

        public EmployeeDetails(ISalaryCalculator salaryCalculator, IEarnedLeavesCalculator earnedLeavesCalculator, IEarnedLeavesSalaryCalculator earnedLeavesSalaryCalculator)
        {
            _salaryCalculator = salaryCalculator;
            _earnedLeavesCalculator = earnedLeavesCalculator;
            _earnedLeavesSalaryCalculator = earnedLeavesSalaryCalculator;
        }

        public float GetSalary()
        {
            return _salaryCalculator.CalculateSalary(HoursWorked, HourlyRate);
        }

        public float GetEarnedLeaves()
        {
            return _earnedLeavesCalculator.CalculateEarnedLeaves(DaysWorked);
        }

        public float GetEarnedLeavesSalary()
        {
            return _earnedLeavesSalaryCalculator.CalculateEarnedLeavesSalary(DaysWorked, HourlyRate);
        }
    }

    public class DIP
    {
        [Test]
        public void DIP_method()
        {
            EmployeeDetails employeeDetails = new EmployeeDetails(new SalaryCalculator());
            employeeDetails.HoursWorked = 1;
            employeeDetails.HourlyRate = 150;
            Console.WriteLine($"Employee Salary={employeeDetails.GetSalary()}");
            EmployeeDetails employeeDetails1 = new EmployeeDetails(new SalaryCalculator(), new EarnedLeavesCalculator(), new EarnedLeavesSalaryCalculator())
            {
                DaysWorked = 60,
                HourlyRate = 150
            };
            Console.WriteLine($"Earned Leaves={employeeDetails1.GetEarnedLeaves()}");
            Console.WriteLine($"Earned Leaves Salary=₹{employeeDetails1.GetEarnedLeavesSalary()}/-");
        }
    }
}
