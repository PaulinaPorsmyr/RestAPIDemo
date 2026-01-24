
using Microsoft.EntityFrameworkCore;
using RestAPIDemo.Data;
using RestAPIDemo.Models;
using Scalar.AspNetCore;

namespace RestAPIDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthorization();

            builder.Services.AddDbContext<RestAPIDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapGet("/api/persons", async (RestAPIDbContext db) =>
            {
                var persons = await db.Persons.ToListAsync();
                return Results.Ok(persons);
            });

            //Get all interests for a specific person
            app.MapGet("/api/persons/{personId}/interests",
                async (int personId, RestAPIDbContext db) =>
                {
                    var interests = await db.PersonInterests
                        .Where(pi => pi.PersonId == personId)
                        .Select(pi => pi.Interest)
                        .ToListAsync();

                    return Results.Ok(interests);
                });

            //Get all links for a specific person
            app.MapGet("/api/persons/{personId}/links",
                async (int personId, RestAPIDbContext db) =>
                {
                    var links = await db.PersonInterests
                        .Where(pi => pi.PersonId == personId)
                        .Join(
                            db.Links,
                            pi => pi.PersonInterestId,
                            l => l.PersonInterestId,
                            (pi, l) => l
                        )
                        .ToListAsync();

                    return Results.Ok(links);
                });

           //Connect a person to a new interest
            app.MapPost("/api/persons/{personId}/interests/{interestId}",
                async (int personId, int interestId, RestAPIDbContext db) =>
                {
                    var exists = await db.PersonInterests
                        .AnyAsync(pi =>
                            pi.PersonId == personId &&
                            pi.InterestId == interestId);

                    if (exists)
                        return Results.BadRequest("Person already has this interest.");

                    var personInterest = new PersonInterest
                    {
                        PersonId = personId,
                        InterestId = interestId
                    };

                    await db.PersonInterests.AddAsync(personInterest);
                    await db.SaveChangesAsync();

                    return Results.Ok(personInterest);
                });

           //Add new link for a specific person and interest
            app.MapPost("/api/persons/{personId}/interests/{interestId}/links",
                async (
                    int personId,
                    int interestId,
                    string Url,
                    RestAPIDbContext db) =>
                {
                    var personInterest = await db.PersonInterests
                        .FirstOrDefaultAsync(pi =>
                            pi.PersonId == personId &&
                            pi.InterestId == interestId);

                    if (personInterest == null)
                        return Results.NotFound("PersonInterest not found.");

                    var link = new Link
                    {
                        Url = Url,
                        PersonInterestId = personInterest.PersonInterestId
                    };

                    await db.Links.AddAsync(link);
                    await db.SaveChangesAsync();

                    return Results.Ok(link);
                });



            app.Run();
        }
    }
}
