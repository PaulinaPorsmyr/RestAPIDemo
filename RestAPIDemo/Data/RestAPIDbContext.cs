using Microsoft.EntityFrameworkCore;
using RestAPIDemo.Models;

namespace RestAPIDemo.Data
{
    public class RestAPIDbContext : DbContext
    {
        public RestAPIDbContext(DbContextOptions<RestAPIDbContext> options) : base(options)
        {
        }

        public DbSet<Person>Persons { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<PersonInterest> PersonInterests { get; set; }
        public DbSet<Link> Links { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ------------------------------
            // Seed Persons
            // ------------------------------
            modelBuilder.Entity<Person>().HasData(
              new Person { Id = 1, FirstName = "Alice", LastName = "Andersson", PhoneNumber = "0701000001" },
              new Person { Id = 2, FirstName = "Bob", LastName = "Berg", PhoneNumber = "0701000002" },
              new Person { Id = 3, FirstName = "Charlie", LastName = "Carlsson", PhoneNumber = "0701000003" },
              new Person { Id = 4, FirstName = "Diana", LastName = "Dahl", PhoneNumber = "0701000004" },
              new Person { Id = 5, FirstName = "Erik", LastName = "Eklund", PhoneNumber = "0701000005" },
              new Person { Id = 6, FirstName = "Fiona", LastName = "Fredriksson", PhoneNumber = "0701000006" },
              new Person { Id = 7, FirstName = "Gustav", LastName = "Gustafsson", PhoneNumber = "0701000007" },
              new Person { Id = 8, FirstName = "Hanna", LastName = "Hansson", PhoneNumber = "0701000008" },
              new Person { Id = 9, FirstName = "Isak", LastName = "Ivarsson", PhoneNumber = "0701000009" },
              new Person { Id = 10, FirstName = "Julia", LastName = "Johansson", PhoneNumber = "0701000010" }
    
            );

            // ------------------------------
            // Seed Interests
            // ------------------------------
            modelBuilder.Entity<Interest>().HasData(
                new Interest { Id = 1, Title = "Football", Description = "Playing football on weekends" },
                new Interest { Id = 2, Title = "Cooking", Description = "Trying out new recipes" },
                new Interest { Id = 3, Title = "Photography", Description = "Landscape photography" },
                new Interest { Id = 4, Title = "Reading", Description = "Reading novels and articles" },
                new Interest { Id = 5, Title = "Gaming", Description = "Video games and board games" },
                new Interest { Id = 6, Title = "Music", Description = "Playing instruments or singing" },
                new Interest { Id = 7, Title = "Hiking", Description = "Exploring nature trails" },
                new Interest { Id = 8, Title = "Painting", Description = "Creating artwork" },
                new Interest { Id = 9, Title = "Traveling", Description = "Visiting new countries and cities" },
                new Interest { Id = 10, Title = "Swimming", Description = "Swimming in pools and lakes" }
            );

            // ------------------------------
            // Seed PersonInterests
            // ------------------------------
            modelBuilder.Entity<PersonInterest>().HasData(
                new PersonInterest { PersonInterestId = 1, PersonId = 1, InterestId = 1 },
                new PersonInterest { PersonInterestId = 2, PersonId = 1, InterestId = 2 },
                new PersonInterest { PersonInterestId = 3, PersonId = 2, InterestId = 2 },
                new PersonInterest { PersonInterestId = 4, PersonId = 2, InterestId = 3 },
                new PersonInterest { PersonInterestId = 5, PersonId = 3, InterestId = 4 },
                new PersonInterest { PersonInterestId = 6, PersonId = 3, InterestId = 5 },
                new PersonInterest { PersonInterestId = 7, PersonId = 4, InterestId = 6 },
                new PersonInterest { PersonInterestId = 8, PersonId = 5, InterestId = 7 },
                new PersonInterest { PersonInterestId = 9, PersonId = 6, InterestId = 8 },
                new PersonInterest { PersonInterestId = 10, PersonId = 7, InterestId = 9 },
                new PersonInterest { PersonInterestId = 11, PersonId = 8, InterestId = 10 },
                new PersonInterest { PersonInterestId = 12, PersonId = 9, InterestId = 1 },
                new PersonInterest { PersonInterestId = 13, PersonId = 10, InterestId = 2 }
            );

            // ------------------------------
            // Seed Links
            // ------------------------------
            modelBuilder.Entity<Link>().HasData(
                new Link { Id = 1, Url = "https://www.football.com", PersonInterestId = 1 },
                new Link { Id = 2, Url = "https://www.recipes.com", PersonInterestId = 2 },
                new Link { Id = 3, Url = "https://www.cookingblog.com", PersonInterestId = 3 },
                new Link { Id = 4, Url = "https://www.photography.com", PersonInterestId = 4 },
                new Link { Id = 5, Url = "https://www.reading.com", PersonInterestId = 5 },
                new Link { Id = 6, Url = "https://www.gaming.com", PersonInterestId = 6 },
                new Link { Id = 7, Url = "https://www.music.com", PersonInterestId = 7 },
                new Link { Id = 8, Url = "https://www.hiking.com", PersonInterestId = 8 },
                new Link { Id = 9, Url = "https://www.painting.com", PersonInterestId = 9 },
                new Link { Id = 10, Url = "https://www.traveling.com", PersonInterestId = 10 },
                new Link { Id = 11, Url = "https://www.swimming.com", PersonInterestId = 11 },
                new Link { Id = 12, Url = "https://www.footballnews.com", PersonInterestId = 12 },
                new Link { Id = 13, Url = "https://www.cookingfun.com", PersonInterestId = 13 }
            );
        }



    }
}
