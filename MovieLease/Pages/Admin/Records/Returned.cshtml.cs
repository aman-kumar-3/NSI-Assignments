using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieLease.Models;
using MovieLease.Services;

namespace MovieLease.Pages.Admin.Records
{
    public class ReturnedModel : PageModel
    {
        private readonly IMovieRepository movieRepository;
        public IEnumerable<Record> Records { get; set; }
        public ReturnedModel(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;

        }
        public void OnGet()
        {
            Records = movieRepository.GetReturnedRecords().ToList();
        }
    }
}