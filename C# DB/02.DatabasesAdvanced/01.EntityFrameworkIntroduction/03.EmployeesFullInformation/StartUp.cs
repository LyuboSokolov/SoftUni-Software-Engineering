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
            
            Console.WriteLine(GetEmployeesFullInformation(db));
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            List<Employee> employees = context.Employees.ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
            }
            return sb.ToString();
        }
    }


    
}
