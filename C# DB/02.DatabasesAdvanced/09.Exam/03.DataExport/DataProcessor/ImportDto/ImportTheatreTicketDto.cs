using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Theatre.DataProcessor.ImportDto
{
    public class ImportTheatreTicketDto
    {
        [Range(1, 100)]
        public decimal Price { get; set; }

        [Required]
        [Range(1, 10)]
        public sbyte RowNumber { get; set; }

        public int PlayId { get; set; }

        
        //•	Price – decimal in the range[1.00….100.00] (required)
        //•	RowNumber – sbyte in range[1….10] (required)
        //•	PlayId – integer, foreign key(required)
     
    }
}
