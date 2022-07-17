using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
   public  class User
    {
        public User()
        {
            Bets = new HashSet<Bet>(); 
        }
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(75)]
        public string Username { get; set; }

        [Required]
        [StringLength(255)]
        public int Password { get; set; }

        [Required]
        [StringLength(75)]
        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public decimal Balance { get; set; }

        public virtual ICollection<Bet> Bets { get; set; }
    }
}
