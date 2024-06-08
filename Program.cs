using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using IMDbee.Pages.Models;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<DatabaseContext>();

var app = builder.Build();

// Seed data on application startup
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<DatabaseContext>();

    if (!dbContext.MovieRatings.Any())
    {
        dbContext.MovieRatings.AddRange(
            new Movie
            {
                Title = "Star Wars: Episode IV - A New Hope\r\n",
                Director = "George Lucas",
                Year = 2024,
                Rating = 8.6f
            },
            new Movie
            {
                Title = "Goodfellas",
                Director = "Martin Scorsese",
                Year = 1990,
                Rating = 8.9f
            },
            new Movie
            {
                Title = "Inception",
                Director = "Christopher Nolan",
                Year = 2010,
                Rating = 8.8f
            },
            new Movie
            {
                Title = "The Shawshank Redemption",
                Director = "Frank Darabont",
                Year = 1994,
                Rating = 9.3f
            },
            new Movie
            {
                Title = "The Godfather",
                Director = "Francis Ford Coppola",
                Year = 1972,
                Rating = 9.2f
            },
            new Movie
            {
                Title = "The Dark Knight",
                Director = "Christopher Nolan",
                Year = 2008,
                Rating = 9.0f
            },
            new Movie
            {
                Title = "Pulp Fiction",
                Director = "Quentin Tarantino",
                Year = 1994,
                Rating = 8.9f
            },
            new Movie
            {
                Title = "The Lord of the Rings: The Return of the King",
                Director = "Peter Jackson",
                Year = 2003,
                Rating = 8.9f
            },
            new Movie
            {
                Title = "Forrest Gump",
                Director = "Robert Zemeckis",
                Year = 1994,
                Rating = 8.8f
            },
            new Movie
            {
                Title = "Fight Club",
                Director = "David Fincher",
                Year = 1999,
                Rating = 8.8f
            }
        );

        dbContext.SaveChanges();
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();