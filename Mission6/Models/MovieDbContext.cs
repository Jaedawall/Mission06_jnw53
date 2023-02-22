using Microsoft.EntityFrameworkCore;

namespace Mission6.Models
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {

        }

        public DbSet<FormResponse> responses { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder mb)
        {
            //Create Category names for the dropdown list on the MovieForm Page
            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Action/Adventure" },
                new Category { CategoryId = 2, CategoryName= "Comedy" },
                new Category { CategoryId = 3, CategoryName = "Drama" },
                new Category { CategoryId = 4, CategoryName = "Family" },
                new Category { CategoryId = 5, CategoryName = "Horror/Suspense" },
                new Category { CategoryId = 6, CategoryName = "Miscellaneous" },
                new Category { CategoryId = 7, CategoryName = "Television" },
                new Category { CategoryId = 8, CategoryName = "VHS" }
                );

            mb.Entity<FormResponse>().HasData(
                //Seed the database with your three favorite movies
                new FormResponse
                {
                    ApplicationId= 1,
                    CategoryId = 1,
                    Title = "Avengers: Civil War",
                    Year= 2016,
                    Director="Joe Russo",
                    Rating = "PG-13",
                },

                new FormResponse
                {
                    ApplicationId= 2,
                    CategoryId= 2,
                    Title="How to Lose a Guy in 10 Days",
                    Year = 2003,
                    Director="Donald Petrie",
                    Rating = "PG-13",
                },

                new FormResponse
                {
                    ApplicationId= 3,
                    CategoryId= 1,
                    Title="The Lost City",
                    Year = 2022,
                    Director = "Aaron and Adam Nee",
                    Rating = "PG-13",
                }
                );
        }
    }

}
