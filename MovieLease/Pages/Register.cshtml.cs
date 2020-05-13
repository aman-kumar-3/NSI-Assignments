using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieLease.Models;
using MovieLease.Services;

namespace MovieLease.Pages.Users
{
    public class RegisterModel : PageModel
    {
        private readonly IMovieRepository movieRepository;
        public IEnumerable<User> Users { get; set; }

        public RegisterModel(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
            
        }
       [BindProperty]
        public  new User User { get; set; }
        
        public void OnGet()
        {

        }
        
        public IActionResult OnPost()
        {
                
                    User = movieRepository.Add(User);
                

                return Page();
         }
            

        
    }
}