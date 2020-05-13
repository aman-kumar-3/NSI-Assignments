using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieLease.Models
{
  public  class Record
    {
        [Key]
        public int RecordId { get; set; }
        [Required]
        [Display(Name ="User Name")]
        public User User { get; set; }
        [Required]
        [Display(Name ="Movie Name")]
        public Movie Movie { get; set; }
        [Required]
        public DateTime LendDate { get; set; }
        [Required]
        public  DateTime ReturnDate { get; set; }
        [Required]
        public DateTime ActualReturnDate { get; set; }
        public int Fine { get; set; }
        public string Status { get; set; }

        public int Count()
        {
            throw new NotImplementedException();
        }
    }
}
