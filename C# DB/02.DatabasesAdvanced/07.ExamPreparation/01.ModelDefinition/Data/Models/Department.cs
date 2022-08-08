﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SoftJail.Data.Models
{
    public class Department
    {
        public Department()
        {
            Cells = new List<Cell>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(25)]
        public string Name { get; set; }

        public ICollection<Cell> Cells { get; set; }

        //•	Id – integer, Primary Key
        //•	Name – text with min length 3 and max length 25 (required)
        //•	Cells - collection of type Cell

    }
}
