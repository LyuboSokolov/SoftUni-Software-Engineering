﻿using Microsoft.EntityFrameworkCore;
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

            Console.WriteLine(IncreaseSalaries(db));
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

    }



}
