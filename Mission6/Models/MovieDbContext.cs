using Microsoft.EntityFrameworkCore;

namespace Mission6.Models
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {

        }

        public DbSet<FormResponse> responses { get; set; }
    
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<FormResponse>().HasData(
                new FormResponse
                {
                    ApplicationId= 1,
                    Category="Action/Adventure",
                    Title= "Avengers: Civil War",
                    Year= 2016,
                    Director="Joe Russo",
                    Rating = "PG-13",
                },

                new FormResponse
                {
                    ApplicationId= 2,
                    Category= "Romance/Comedy",
                    Title="How to Lose a Guy in 10 Days",
                    Year = 2003,
                    Director="Donald Petrie",
                    Rating = "PG-13",
                },

                new FormResponse
                {
                    ApplicationId= 3,
                    Category="Action/Romance",
                    Title="The Lost City",
                    Year = 2022,
                    Director = "Aaron and Adam Nee",
                    Rating = "PG-13",
                }
                );
        }
    }

}
