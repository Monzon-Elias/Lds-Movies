using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                     new Movie
                     {
                         Title = "The RM",
                         ReleaseDate = DateTime.Parse("1989-1-11"),
                         Genre = "Religious",
                         Rating = "R",
                         Price = 7.99M
                     },

                     new Movie
                     {
                         Title = "Other Side of Heaven",
                         ReleaseDate = DateTime.Parse("1984-3-13"),
                         Genre = "Religious",
                         Rating = "R",
                         Price = 8.99M
                     },

                     new Movie
                     {
                         Title = "Meet the Mormons",
                         ReleaseDate = DateTime.Parse("2012-2-23"),
                         Genre = "Religious",
                         Rating = "R",
                         Price = 9.99M
                     },

                   new Movie
                   {
                       Title = "The best two years",
                       ReleaseDate = DateTime.Parse("1989-4-15"),
                       Genre = "Religious-Comedy",
                       Rating = "R",
                       Price = 3.99M
                   }
                );
                context.SaveChanges();
            }
        }
    }
}