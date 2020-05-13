using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MovieLease.Models;
using MovieLease.Services;

namespace MovieLease.Pages.Admin.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly MovieLease.Services.MovieLeaseContext _context;

        public DetailsModel(MovieLease.Services.MovieLeaseContext context)
        {
            _context = context;
        }

        public Movie Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movies.FirstOrDefaultAsync(m => m.MovieId == id);

            if (Movie == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
