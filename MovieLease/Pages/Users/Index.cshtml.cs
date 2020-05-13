using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;
using MovieLease.Models;
using MovieLease.Services;

namespace MovieLease.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly IMovieRepository movieRepository;
        public IEnumerable<Record> RecordsOfUser { get; set; }
        public string UserName { get; set; }
       
        public IndexModel(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;

        }
        [BindProperty]
        public User User { get; set; }
        
        public IActionResult OnGet()
        {
            
            var Userdata = HttpContext.Session.GetString("UserName");
            if(Userdata!=null)
            {
                User = movieRepository.GetUserByName(Userdata);
                UserName = Userdata;
                RecordsOfUser = movieRepository.GetRecordByUser(UserName);          

                return Page();
                
            }

            
            
            return RedirectToPage("/SignIn");

        }

        public IActionResult OnPost()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/SignIn");
        }



    }
}