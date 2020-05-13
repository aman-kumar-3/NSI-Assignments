using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MovieLease.Models;
using MovieLease.Services;

namespace MovieLease.Pages.Admin.Users
{
    public class IndexModel : PageModel
    {
        private readonly MovieLease.Services.MovieLeaseContext _context;

        public IndexModel(MovieLease.Services.MovieLeaseContext context)
        {
            _context = context;
        }

        public IList<User> User { get;set; }

        public async Task OnGetAsync()
        {
            User = await _context.Users.ToListAsync();
        }
    }
}
