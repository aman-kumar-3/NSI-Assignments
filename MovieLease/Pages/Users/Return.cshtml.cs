using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieLease.Models;
using MovieLease.Services;

namespace MovieLease.Pages.Users
{
    public class ReturnModel : PageModel
    {
        private readonly IMovieRepository movieRepository;
        public ReturnModel(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;

        }
        public Record LendRecord { get; set; }
        public void OnGet(int ID)
        {
           LendRecord= movieRepository.GetRecordById(ID);
        }

        public IActionResult OnPost(int ID)
        {
             LendRecord = movieRepository.UpdateRecordById(ID);
            return RedirectToPage("/Users/Index");


        }
    }
}