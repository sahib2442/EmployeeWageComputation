using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWageApp;

internal class EmployeeWage
{ 
    const int IS_FULL_TIME = 1, IS_PART_TIME = 0,IS_PRESENT = 1,IS_ABSENT = 0,RATE_PER_HOUR = 20,WORKING_DAYS_PER_MONTH = 20;
    int totalDaysWorked;
    int monthlyWage;
    int totalHoursWorked;
    static Random random = new Random();
    public EmployeeWage()
    {
        totalDaysWorked = 0;
        monthlyWage = 0;
        totalHoursWorked = 0;
    }
    public void Reset()
    {
        totalDaysWorked = 0;
        monthlyWage = 0;
        totalHoursWorked = 0;
    }
    private int GetAttendance()
    {
        int checkAttendance = random.Next(0, 2);
        if (checkAttendance == IS_PRESENT)
            return IS_PRESENT;
        else
            return IS_ABSENT;
    }
    private int GetDailyWage()
    {
        int dailyWage = 0;
        int dailyHours = 0;
        int empCheck = random.Next(0, 2);
        switch (empCheck)
        {
            case IS_FULL_TIME:
                dailyHours = 8;
                break;
            case IS_PART_TIME:
                dailyHours = 4;
                break;
            default:
                dailyHours = 0;
                break;
        }
        totalHoursWorked += dailyHours;
        dailyWage = dailyHours * RATE_PER_HOUR;
        return dailyWage;
    }
    public void MonthlyWage()
    {
        for (int i = 0; i < WORKING_DAYS_PER_MONTH; i++)
            totalDaysWorked += GetAttendance();
        for (int j = 0; j < totalDaysWorked; j++)
            monthlyWage += GetDailyWage();
    }
    public void MeetWageCondition()
    {
        while (totalDaysWorked != 20 && totalHoursWorked < 100)
        {
            Reset();
            MonthlyWage();
        }
    }
    public void Display()
    {
        Console.WriteLine("Total Hours worked: " + totalHoursWorked);
        Console.WriteLine("Total Days worked: " + totalDaysWorked);
        Console.WriteLine("Monthly Wage: " + monthlyWage);
    }
}

