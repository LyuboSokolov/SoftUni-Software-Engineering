using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Theatre.Data.Models
{
     public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [Range(1,100)]
        public decimal Price { get; set; }

        [Required]
        [Range(1,10)]
        public sbyte RowNumber { get; set; }

        [ForeignKey(nameof(Play))]
        public int PlayId { get; set; }
        [Required]
        public virtual Play Play { get; set; }

        [ForeignKey(nameof(Theatre))]
        public int TheatreId { get; set; }
        [Required]
        public virtual Theatre Theatre { get; set; }

        //        •	Id – integer, Primary Key
        //•	Price – decimal in the range[1.00….100.00] (required)
        //•	RowNumber – sbyte in range[1….10] (required)
        //•	PlayId – integer, foreign key(required)
        //•	TheatreId – integer, foreign key(required)

    }
}
