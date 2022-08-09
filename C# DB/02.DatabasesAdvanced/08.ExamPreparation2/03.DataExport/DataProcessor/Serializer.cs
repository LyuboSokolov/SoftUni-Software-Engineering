namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var projects = context.Projects
            .Where(x => x.Tasks.Count >= 1)
            .ToArray()
            .Select(x => new
            {
                TaskCount = x.Tasks.Count,
                ProjectName = x.Name,
                HasEndDate = x.DueDate.HasValue,
                Tasks = x.Tasks.Select(t => new
                {
                    t.Name,
                    t.LabelType
                })
                .OrderBy(x => x.Name)
                .ToArray()
            })
            .OrderByDescending(x=> x.TaskCount)
            .ThenBy(x=> x.ProjectName)
            .ToArray();

            List<ExportProjectDto> exportProjectDtos = new List<ExportProjectDto>();

            foreach (var project in projects)
            {
                string hasEndDate = "No";
                if (project.HasEndDate)
                {
                    hasEndDate = "Yes";
                }
                ExportProjectDto projectDto = new ExportProjectDto()
                {
                    TaskCount = project.TaskCount,
                    ProjectName = project.ProjectName,
                    HasEndDate = hasEndDate

                };

                List<ExportProjectTaskDto> taskDtos = new List<ExportProjectTaskDto>();

                foreach (var task in project.Tasks)
                {
                    ExportProjectTaskDto taskDto = new ExportProjectTaskDto()
                    {
                        Name = task.Name,
                        Label = task.LabelType.ToString()
                    };
                    taskDtos.Add(taskDto);
                }
                projectDto.Tasks = taskDtos.ToArray();
                exportProjectDtos.Add(projectDto);
            }

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Projects");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportProjectDto[]), xmlRoot);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);
            StringBuilder sb = new StringBuilder();

           xmlSerializer.Serialize(new StringWriter(sb), exportProjectDtos.ToArray(), namespaces);


            return sb.ToString().TrimEnd();
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context.Employees
                .Where(x => x.EmployeesTasks.Any(t => t.Task.OpenDate >= date))
                .AsQueryable()
                .Include(x => x.EmployeesTasks)
                .ThenInclude(y => y.Task)
                .ToList()
                .Select(x => new
                {
                    x.Username,
                    Tasks = x.EmployeesTasks
                    .Where(t => t.Task.OpenDate >= date)
                    .Select(x => x.Task)
                    .OrderByDescending(x => x.DueDate)
                    .ThenBy(x => x.Name)
                    .Select(t => new
                    {
                        TaskName = t.Name,
                        OpenDate = t.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                        DueDate = t.DueDate.ToString("d", CultureInfo.InvariantCulture),
                        LabelType = t.LabelType.ToString(),
                        ExecutionType = t.ExecutionType.ToString()
                    })
                    .ToList()

                })

                .OrderByDescending(x => x.Tasks.Count)
                .ThenBy(x => x.Username)
                .Take(10)
                .ToList();




            string serializedEmployees = JsonConvert.SerializeObject(employees, Formatting.Indented);





            return serializedEmployees;
        }
    }
}