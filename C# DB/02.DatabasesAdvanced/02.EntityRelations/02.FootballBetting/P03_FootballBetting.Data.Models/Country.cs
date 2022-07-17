using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class Country
    {
        public Country()
        {
            Towns = new HashSet<Town>();
        }
        [Key]
        public int CountryId { get; set; }

        [StringLength(75)]
        [Required]
        public string Name { get; set; }

        public  virtual ICollection<Town> Towns { get; set; }
    }
}
