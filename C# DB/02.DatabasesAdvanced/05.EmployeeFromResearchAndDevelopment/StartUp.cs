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

            Console.WriteLine(GetEmployeesFromResearchAndDevelopment(db));
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var employee in context.Employees
                                            .Select(x => new
                                            {
                                                firstName = x.FirstName,
                                                lastName = x.LastName,
                                                departmentName = x.Department.Name,
                                                salary = x.Salary
                                            })
                                            .Where(x => x.departmentName == "Research and Development")
                                            .OrderBy(x=> x.salary)
                                            .ThenByDescending(x=> x.firstName))
            {
                sb.AppendLine($"{employee.firstName} {employee.lastName} from {employee.departmentName} - ${employee.salary:f2}");
            }
            return sb.ToString();
        }

    }



}
