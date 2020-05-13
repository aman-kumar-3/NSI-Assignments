using Microsoft.EntityFrameworkCore;
using MovieLease.Models;
using System;
using System.Diagnostics;

namespace MovieLease.Services
{
    public class MovieLeaseContext:DbContext
    {
        public MovieLeaseContext(DbContextOptions<MovieLeaseContext>options):base(options)
        {

        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Record> Records { get; set; }
    }
}
