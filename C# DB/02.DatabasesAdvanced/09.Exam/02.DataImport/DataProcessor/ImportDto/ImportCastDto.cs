using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Cast")]
     public class ImportCastDto
    {
        [Required]
        [StringLength(30,MinimumLength =4)]
        [XmlElement("FullName")]
        public string FullName { get; set; }

        [Required]
        [XmlElement("IsMainCharacter")]
        public bool IsMainCharacter { get; set; }

        [Required]
        [XmlElement("PhoneNumber")]
        [RegularExpression(@"\+44\-\d{2}\-\d{3}\-\d{4}")]
        public string PhoneNumber { get; set; }

        [XmlElement("PlayId")]
        public int PlayId { get; set; }


        //•	FullName – text with length[4, 30] (required)
        //•	IsMainCharacter – Boolean represents if the actor plays the main character in a play(required)
        //•	PhoneNumber  - text in the following format: "+44-{2 numbers}-{3 numbers}-{4 numbers}". Valid phone numbers are: +44-53-468-3479, +44-91-842-6054, +44-59-742-3119 (required)
        //•	PlayId - integer, foreign key(required)
    }
}
