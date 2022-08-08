using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TeisterMask.Data.Models.Enums;

namespace TeisterMask.Data.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }

        [StringLength(40,MinimumLength =2)]
        [Required]
        public string Name { get; set; }

        public DateTime OpenDate { get; set; }

        public DateTime DueDate { get; set; }

        public ExecutionType ExecutionType { get; set; }

        public LabelType LabelType { get; set; }

        [ForeignKey(nameof(Project))]
        [Required]
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public ICollection<EmployeeTask> EmployeesTasks { get; set; }

        public Task()
        {
            EmployeesTasks = new List<EmployeeTask>();
        }

        //•	Id - integer, Primary Key
        //•	Name - text with length[2, 40] (required)
        //•	OpenDate - date and time(required)
        //•	DueDate - date and time(required)
        //•	ExecutionType - enumeration of type ExecutionType, with possible values(ProductBacklog, SprintBacklog, InProgress, Finished) (required)
        //•	LabelType - enumeration of type LabelType, with possible values(Priority, CSharpAdvanced, JavaAdvanced, EntityFramework, Hibernate) (required)
        //•	ProjectId - integer, foreign key(required)
        //•	Project - Project 
        //•	EmployeesTasks - collection of type EmployeeTask

    }
}
