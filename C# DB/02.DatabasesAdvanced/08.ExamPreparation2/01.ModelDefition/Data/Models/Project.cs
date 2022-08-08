using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TeisterMask.Data.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [StringLength(40,MinimumLength =2)]
        [Required]
        public string Name { get; set; }

        public DateTime OpenDate { get; set; }

        public DateTime? DueDate { get; set; }

        public ICollection<Task> Tasks { get; set; }

        public Project()
        {
            Tasks = new List<Task>();
        }
        //•	Id - integer, Primary Key
        //•	Name - text with length[2, 40] (required)
        //•	OpenDate - date and time(required)
        //•	DueDate - date and time(can be null)
        //•	Tasks - collection of type Task

    }
}
