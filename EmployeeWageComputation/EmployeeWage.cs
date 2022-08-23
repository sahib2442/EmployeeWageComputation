using System;
namespace EmployeeWageComputation
{
    public class EmployeeWage
    {
        const int IS_FULL_TIME = 0, IS_PART_TIME = 1, WAGE_PER_HR = 20, FULL_TIME_HR = 8, PART_TIME_HR = 4, WORKING_DAYS = 20;
        int totalEMPWage = 0, empHrs = 0;
        public void Attendance()
        {
            Random random = new Random();
            int empCheck = random.Next(0, 2);
            if (empCheck == IS_FULL_TIME)
                Console.WriteLine("Employee is persent");
            else
                Console.WriteLine("Employee is absent");
        }
        public void CalculateEmpWage()
        {
            Random random = new Random();
            for (int i = 0; i < WORKING_DAYS && empHrs < 100; i++)
            {
                int empCheck = random.Next(0, 3);
                switch (empCheck)

                {
                    case IS_FULL_TIME;
                        empHrs += FULL_TIME_HR;
                        break;
                    case IS_PART_TIME;
                        empHrs += FULL_PART_HR;
                        break;
                }

            }
            totalEMPWage = WAGE_PER_HR * empHrs;
            Console.WriteLine(totalEMPWage);
        }


    }
}


