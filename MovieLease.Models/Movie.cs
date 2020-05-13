using System;
using System.ComponentModel.DataAnnotations;

namespace MovieLease.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        [Required, MinLength(3, ErrorMessage = "")]
        public string MovieName { get; set; }
        public string Language { get; set; }
        public string Director { get; set; }
        public string Description { get; set; }
        [Required]
        public int Price { get; set; }
        
    }
}
