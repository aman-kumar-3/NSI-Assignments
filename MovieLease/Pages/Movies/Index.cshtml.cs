using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MovieLease.Models;
using MovieLease.Services;

namespace MovieLease.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly IMovieRepository movieRepository;
        public IEnumerable<Movie> Movies { get; set; }
        public IndexModel(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }
        [BindProperty]
        Movie Movie { get; set; }
        public void OnGet()
        {
            Movies = movieRepository.GetAllMovies().ToList();


        }
       
    }
}