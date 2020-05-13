using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieLease.Models;
using MovieLease.Services;

namespace MovieLease.Pages.Movies
{
    public class OrderRecordModel : PageModel
    {
        private readonly IMovieRepository movieRepository;

        public OrderRecordModel(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }
        [BindProperty]
        public Movie MovieRecord { get; set; }
        public void OnGet(int ID)
        {
            MovieRecord = movieRepository.GetMovieById(ID);
        }
        public IActionResult OnPost(int ID)
        {

            var UserName = HttpContext.Session.GetString("UserName");
            var MovieRecord = movieRepository.GetMovieById(ID);
            if (string.IsNullOrEmpty(UserName))
            {
                return RedirectToPage("/SignIn");
            }
            var newRecord = new Record()
            {
                User = movieRepository.GetUserByName(UserName),
                Movie = MovieRecord,
                LendDate = DateTime.Now,
                ReturnDate = DateTime.Now.AddDays(7),
                Status="Not Returned"
            };
            movieRepository.AddRecord(newRecord);
            movieRepository.Commit();
            return RedirectToPage("/Movies/Index");


        }
    }
}