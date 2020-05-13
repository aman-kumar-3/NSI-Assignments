using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieLease.Models;
using MovieLease.Services;

namespace MovieLease.Pages.Users
{
    public class SignInModel : PageModel
    {
        private readonly IMovieRepository movieRepository;
        public string Msg { get; set; }
        public SignInModel(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
            Login = new Login();

        }
        [BindProperty]
        public Login Login { get; set; }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Msg = movieRepository.UserExist(Login.UserName, Login.Password);
                if(Msg== "Successfull")
                {
                    HttpContext.Session.SetString("UserName",Login.UserName);
                        return RedirectToPage("/Movies/Index");
                }
            }
            return Page();
            

        }
       
    }
}