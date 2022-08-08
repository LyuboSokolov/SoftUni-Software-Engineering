using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TeisterMask.Data.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [StringLength(40,MinimumLength =3)]
        [Required]
        [RegularExpression(@"\w||\d")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        public ICollection<EmployeeTask> EmployeesTasks { get; set; }

        public Employee()
        {
            EmployeesTasks = new List<EmployeeTask>();
        }

        // •Id - integer, Primary Key
        //•	Username - text with length[3, 40]. Should contain only lower or upper case letters and/or digits. (required)
        //•	Email – text(required). Validate it! There is attribute for this job.
        //•	Phone - text.Consists only of three groups(separated by '-'), the first two consist of three digits and the last one - of 4 digits. (required)
        //•	EmployeesTasks - collection of type EmployeeTask

    }
}
