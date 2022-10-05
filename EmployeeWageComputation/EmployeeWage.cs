using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EmployeeWageComputation;
public class EmployeeWage
{
    private const int IS_FULL_TIME = 1;
    private const int IS_PART_TIME = 0;
    private readonly int RATE_PER_HOUR = 20;
    private readonly int WORKING_DAYS_PER_MONTH = 20;
    private readonly int HOURS_PER_MONTH = 100;
    private int totalDaysWorked;
    private int monthlyWage;
    private int dailyWage;
    private int totalHoursWorked;
    private readonly string company;
    private static readonly Random random = new();
    public string Company
    {
        get { return company; }
    }
    public int DailWage
    {
        get { return dailyWage; }
    }
    public int TotalWage
    {
        get { return monthlyWage; }
    }
    public EmployeeWage(string company)
    {
        totalDaysWorked = 0;
        monthlyWage = 0;
        totalHoursWorked = 0;
        this.company = company;
    }
    public EmployeeWage(string companyName, int ratePerHour, int maxWorkingDays, int maxHoursPerMonth)
    {
        RATE_PER_HOUR = ratePerHour;
        WORKING_DAYS_PER_MONTH = maxWorkingDays;
        HOURS_PER_MONTH = maxHoursPerMonth;
        company = companyName;
    }

    public EmployeeWage()
    {
    }

    private void Reset()
    {
        totalDaysWorked = 0;
        monthlyWage = 0;
        totalHoursWorked = 0;
        dailyWage = 0;
    }
    private static int GetAttendance()
    {
        return random.Next(0, 2);
    }
    private int GetDailyWage()
    {
        int empCheck = random.Next(0, 2);
        int dailyHours = empCheck switch
        {
            IS_FULL_TIME => 8,
            IS_PART_TIME => 4,
            _ => 0,
        };
        totalHoursWorked += dailyHours;
        dailyWage = dailyHours * RATE_PER_HOUR;
        return dailyWage;
    }
    private void CalculateMonthlyWage()
    {
        for (int i = 0; i < WORKING_DAYS_PER_MONTH; i++)
            totalDaysWorked += GetAttendance();
        for (int j = 0; j < totalDaysWorked; j++)
            monthlyWage += GetDailyWage();
    }
    public void MeetWageCondition()
    {
        while (totalDaysWorked != WORKING_DAYS_PER_MONTH && totalHoursWorked < HOURS_PER_MONTH)
        {
            Reset();
            CalculateMonthlyWage();
        }
    }
    public void Display()
    {
        Console.WriteLine("Total Hours worked: " + totalHoursWorked);
        Console.WriteLine("Total Days worked: " + totalDaysWorked);
        Console.WriteLine("Daily Wage: " + dailyWage);
        Console.WriteLine("Monthly Wage: " + monthlyWage);
    }
    public override string ToString()
    {
        return $"Total Wage: {TotalWage}; Daily Wage: {DailWage}";
    }
}
