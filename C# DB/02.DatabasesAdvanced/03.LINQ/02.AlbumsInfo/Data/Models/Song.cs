﻿using MusicHub.Data.Models.Enumeration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MusicHub.Data.Models
{
   public class Song
    {
        public Song()
        {
            SongPerformers = new HashSet<SongPerformer>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public Genre Genre { get; set; }

        [ForeignKey(nameof(Album))]
    
        public int? AlbumId { get; set; }

        public virtual Album Album { get; set; }

        [ForeignKey(nameof(Writer))]
        [Required]
        public int WriterId { get; set; }

        public Writer Writer { get; set; }

        [Required]
        public decimal Price { get; set; }

        
       public ICollection<SongPerformer> SongPerformers  { get; set; }
    }
}
