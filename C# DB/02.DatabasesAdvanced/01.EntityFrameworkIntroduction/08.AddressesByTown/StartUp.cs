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

            Console.WriteLine(GetAddressesByTown(db));
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


        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var addresses = context.Addresses
                .OrderByDescending(x => x.Employees.Count)
                .ThenBy(x => x.Town.Name)
                .ThenBy(x => x.AddressText)
                .Take(10)
                .Select(x => new
            {
                EmployeesCount = x.Employees.Count,
                x.AddressText,
                TownName = x.Town.Name
            })
               
                .ToList();

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.TownName} - {address.EmployeesCount} employees");
            }
    


            return sb.ToString().TrimEnd();
        }
    }



}
