using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Play")]
    public class ImportPlayDto
    {
        [Required]
        [StringLength(50,MinimumLength =4)]
        [XmlElement("Title")]
        public string Title { get; set; }

        [Required]
        [XmlElement("Duration")]
        public string Duration { get; set; }

        [Range(0.00, 10.00)]
        [XmlElement("Rating")]
        public double Rating { get; set; }

        [Required]
        [XmlElement("Genre")]
        public string Genre { get; set; }

        [Required]
        [StringLength(700)]
        [XmlElement("Description")]
        public string Description { get; set; }

        [Required]
        [StringLength(30,MinimumLength =4)]
        [XmlElement("Screenwriter")]
        public string Screenwriter { get; set; }



        //•	Title – text with length[4, 50] (required)
        //•	Duration – TimeSpan in format {hours:minutes:seconds
        //    }, with a minimum length of 1 hour. (required)
        //•	Rating – float in the range[0.00….10.00] (required)
        //•	Genre – enumeration of type Genre, with possible values(Drama, Comedy, Romance, Musical) (required)
        //•	Description – text with length up to 700 characters(required)
        //•	Screenwriter – text with length[4, 30] (required)
        //•	Casts - a collection of type Cast
        //•	Tickets - a collection of type Ticket
    }
}
