using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MovieLease.Models
{
   public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(15, MinimumLength =3, ErrorMessage = "Name should have max length of 15 and min lenth be 3")]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        [RegularExpression("^[0-9]+@[a-z0-9.-]+.[a-z]{2,}$",ErrorMessage ="Email address should be like example@example.com")]
        public string Email { get; set; }
        [Required]
        [StringLength(20,MinimumLength =6,ErrorMessage ="min length be=6 and max length should be=20")]
        public string Password { get; set; }
        [Required]
        [NotMapped]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        

    }
}
