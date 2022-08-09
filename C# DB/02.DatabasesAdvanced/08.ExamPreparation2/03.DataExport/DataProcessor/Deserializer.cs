namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Projects");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportProjectDto[]), xmlRoot);

            ImportProjectDto[] importProjects;
            using (StringReader sr = new StringReader(xmlString))
            {
                importProjects = (ImportProjectDto[]) xmlSerializer.Deserialize(sr);
            }

            List<Project> dbProjects = new List<Project>();
           

            foreach (var projectDto in importProjects)
            {
                if (!IsValid(projectDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                if (!DateTime.TryParseExact(projectDto.OpenDate,
                    "dd/MM/yyyy",CultureInfo.InvariantCulture,DateTimeStyles.None,out DateTime openDateProject))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                DateTime? dueDate = null;
                if (!string.IsNullOrWhiteSpace(projectDto.DueDate))
                {
                    DateTime.TryParseExact(projectDto.DueDate,
                        "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dueDateProject
                        );
                    dueDate = dueDateProject;
                }
                Project dbProject = new Project()
                {
                    Name = projectDto.Name,
                    OpenDate = openDateProject,
                    DueDate = dueDate

                };

                List<Task> dbTasks = new List<Task>();

                foreach (var taskDto in projectDto.Tasks)
                {
                    if (!IsValid(taskDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (!DateTime
                    .TryParseExact(taskDto.OpenDate,"dd/MM/yyyy", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out DateTime openDateTask))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (!DateTime
                .TryParseExact(taskDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime dueDateTask))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (!Enum.TryParse(typeof(ExecutionType), taskDto.ExecutionType.ToString(), out object executionType))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (!Enum.TryParse(typeof(ExecutionType), taskDto.ExecutionType.ToString(), out object labelType))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    if (openDateTask < dbProject.OpenDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    if (dbProject.DueDate.HasValue && dbProject.DueDate < dueDateTask)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    Task dbTask = new Task()
                    {
                        Name = taskDto.Name,
                        OpenDate = openDateTask,
                        DueDate = dueDateTask,
                        ExecutionType = (ExecutionType)executionType,
                        LabelType = (LabelType)labelType,
                        //Project = dbProject
                        
                    };

                    dbTasks.Add(dbTask);
                }
                dbProject.Tasks = dbTasks;
                dbProjects.Add(dbProject);
                sb.AppendLine(string.Format(SuccessfullyImportedProject,dbProject.Name,dbTasks.Count));

            }

            context.Projects.AddRange(dbProjects);
            context.SaveChanges();


            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            ImportEmployeeDto[] employeesDtos = JsonConvert.DeserializeObject<ImportEmployeeDto[]>(jsonString);

            List<Employee> dbEmployees = new List<Employee>();

            StringBuilder sb = new StringBuilder();

            foreach (var employeeDto in employeesDtos)
            {
                if (!IsValid(employeeDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Employee dbEmployee = new Employee()
                {
                    Username = employeeDto.Username,
                    Email = employeeDto.Email,
                    Phone = employeeDto.Phone

                };

                List<EmployeeTask> dbTasks = new List<EmployeeTask>();

                foreach (var taskDto in employeeDto.Tasks.Distinct())
                {
                    if (context.Tasks.FirstOrDefault(x=> x.Id == taskDto)==null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    EmployeeTask employeeTask = new EmployeeTask()
                    {
                        Employee = dbEmployee,
                        TaskId = taskDto
                    };
                    dbTasks.Add(employeeTask);
                }

                dbEmployee.EmployeesTasks = dbTasks;
                sb.AppendLine(string.Format(SuccessfullyImportedEmployee, dbEmployee.Username, dbTasks.Count));
                dbEmployees.Add(dbEmployee);
            }

            context.Employees.AddRange(dbEmployees);
            context.SaveChanges();
            return sb.ToString().TrimEnd();

        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}