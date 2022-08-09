using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ImportDto
{
    [XmlType("Project")]
     public class ImportProjectDto
    {
        [XmlElement("Name")]
        [Required]
        [StringLength(40,MinimumLength = 2)]
        public string Name { get; set; }

        [XmlElement("OpenDate")]
        [Required]
        public string OpenDate { get; set; }

        [XmlElement("DueDate")]
        
        public string DueDate { get; set; }

        [XmlArray("Tasks")]
        public ImportTaskDto[] Tasks { get; set; }

        //•	Id - integer, Primary Key
        //•	Name - text with length[2, 40] (required)
        //•	OpenDate - date and time(required)
        //•	DueDate - date and time(can be null)
        //•	Tasks - collection of type Task
    }
}
