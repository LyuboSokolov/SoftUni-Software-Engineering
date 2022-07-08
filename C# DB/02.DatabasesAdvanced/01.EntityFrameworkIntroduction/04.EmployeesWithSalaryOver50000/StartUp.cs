using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext db = new SoftUniContext();

            Console.WriteLine(GetEmployeesWithSalaryOver50000(db));
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            List<Employee> employees = context.Employees.ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees.OrderBy(x => x.EmployeeId))
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName}" +
                              $" {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
            }
            return sb.ToString();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var employee in context.Employees.Where(x=> x.Salary > 50000).OrderBy(x=> x.FirstName).ToList())
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
            }

            return sb.ToString();
        }

    }



}
