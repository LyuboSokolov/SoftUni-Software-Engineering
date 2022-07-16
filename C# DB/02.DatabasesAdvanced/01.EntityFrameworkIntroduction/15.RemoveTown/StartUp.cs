using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext db = new SoftUniContext();

            Console.WriteLine(RemoveTown(db));
        }

        // Problem 7 - Employees and Projects
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
           .Where(p => p.EmployeesProjects
           .Any(d => d.Project.StartDate.Year >= 2001 && d.Project.StartDate.Year <= 2003))
           .Select(
            e => new
            {
                e.FirstName,
                e.LastName,
                Manager = e.Manager,
                EmployeesProjects = e.EmployeesProjects
                .Select(p => new
                {
                    ProjectName = p.Project.Name,
                    StartDate = p.Project.StartDate,
                    EndDate = p.Project.EndDate
                })

            }
            ).ToArray();

            foreach (var e in employees.Take(10))
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.Manager.FirstName} {e.Manager.LastName}");

                foreach (var project in e.EmployeesProjects)
                {
                    sb.AppendLine($"--{project.ProjectName} -" +
                                       $" {project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - " +
                                       $"{(project.EndDate == null ? "not finished" : project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture))}");
                }
            }
            return sb.ToString().TrimEnd();
        }

        // Problem 8 - Addresses by Town
        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var addresses = context.Addresses
                                   .Select(x => new
                                   {
                                       EmployeesCount = x.Employees.Count,
                                       x.AddressText,
                                       TownName = x.Town.Name
                                   })
                                   .OrderByDescending(x => x.EmployeesCount)
                                   .ThenBy(x => x.TownName)
                                   .ThenBy(x => x.AddressText)
                                   .Take(10)
                                   .ToList();

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.TownName} - {address.EmployeesCount} employees");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 9 - Employee 147
        public static string GetEmployee147(SoftUniContext context)
        {
            var employee147 = context.Employees
                .Where(x => x.EmployeeId == 147)

                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.JobTitle,
                    projects = x.EmployeesProjects.Select(p => p.Project)
                })
                .First();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}");

            foreach (var project in employee147.projects.OrderBy(x => x.Name))
            {
                sb.AppendLine($"{ project.Name}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 10 - Departments with More Than 5 Employees
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var results = context.Departments.Where(x => x.Employees.Count > 5)
                                .OrderBy(x => x.Employees.Count)
                                .ThenBy(x => x.Name)
                               .Select(x => new
                               {
                                   departmentName = x.Name,
                                   managerFirstName = x.Manager.FirstName,
                                   managerLastName = x.Manager.LastName,
                                   employees = x.Employees.Select(e => new
                                   {
                                       employeeFirstName = e.FirstName,
                                       employeeLastName = e.LastName,
                                       employeeJobTitle = e.JobTitle,

                                   })
                               })
                              .ToList();
            StringBuilder sb = new StringBuilder();

            foreach (var row in results)
            {
                sb.AppendLine($"{row.departmentName} - {row.managerFirstName}  {row.managerLastName}");

                foreach (var employee in row.employees.OrderBy(x => x.employeeFirstName).ThenBy(x => x.employeeLastName))
                {
                    sb.AppendLine($"{employee.employeeFirstName} {employee.employeeLastName} - {employee.employeeJobTitle}");
                }
            }


            return sb.ToString().TrimEnd();
        }

        //Problem 11 - Find Latest 10 Projects
        public static string GetLatestProjects(SoftUniContext context)
        {

            var last10LatestProjects = context.Projects.OrderByDescending(p => p.StartDate).Take(10).ToList();
            var sortedProjects = last10LatestProjects.OrderBy(p => p.Name).ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var project in sortedProjects)
            {
                sb.AppendLine($"{project.Name}");
                sb.AppendLine($"{project.Description}");
                sb.AppendLine($"{project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)}");

            }
            return sb.ToString().TrimEnd();
        }

        //Problem 12 - Increase Salaries
        public static string IncreaseSalaries(SoftUniContext context)
        {
            var employeesIncreaseSalary = context.Employees.Where(d => d.Department.Name == "Engineering" ||
                                                                       d.Department.Name == "Tool Design" ||
                                                                       d.Department.Name == "Marketing" ||
                                                                       d.Department.Name == "Information Services");


            foreach (var employee in employeesIncreaseSalary)
            {
                employee.Salary *= 1.12M;
            }

            context.SaveChanges();

            var employeesDisplay = employeesIncreaseSalary.Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.Salary
            })
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employeesDisplay)
            {

                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 13 - Find Employees by First Name Starting with "Sa"
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees.Where(e => e.FirstName.ToLower().StartsWith("sa"))
                                             .Select(e => new
                                             {
                                                 e.FirstName,
                                                 e.LastName,
                                                 e.JobTitle,
                                                 e.Salary
                                             })
                                             .OrderBy(e => e.FirstName)
                                             .ThenBy(e => e.LastName)
                                             .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 14 - Delete Project by Id
        public static string DeleteProjectById(SoftUniContext context)
        {
           
            var employees = context.EmployeesProjects.Where(x => x.ProjectId == 2);
            context.EmployeesProjects.RemoveRange(employees);

            var projectsDeleted = context.Projects.Where(p => p.ProjectId == 2);

            context.Projects.RemoveRange(projectsDeleted);

            context.SaveChanges();

            var project10 = context.Projects.Take(10).ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var project in project10)
            {
                sb.AppendLine(project.Name);
            }
            return sb.ToString().TrimEnd();
        }

        //Problem 15 - Remove Town
        public static string RemoveTown(SoftUniContext context)
        {
            var addressesSeattle = context.Addresses.Where(x => x.Town.Name == "Seattle").ToList();

            var employeesWithAddressInSeattle = context.Employees.ToList()
                                                                 .Where(e=> addressesSeattle.Any(a=>a.AddressId ==e.AddressId))
                                                                 .ToList();
            foreach (var em in employeesWithAddressInSeattle)
            {
                em.AddressId = null;
            }

            context.Addresses.RemoveRange(addressesSeattle);
            var seattle = context.Towns.First(x => x.Name == "Seattle");
            context.Towns.Remove(seattle);

            context.SaveChanges();
            return $"{addressesSeattle.Count} addresses in Seattle were deleted";
        }
    }



}
