using Microsoft.EntityFrameworkCore;
using Movie_Night_website;
using Movie_Night_website.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<MovieNightDatabase>(options => options.UseInMemoryDatabase("MovieNightDatabase")); //initialize the database

var app = builder.Build();
using var scope = app.Services.CreateScope(); //make service scope
using var context = scope.ServiceProvider.GetRequiredService<MovieNightDatabase>(); //get db connextion
context.Database.EnsureDeleted();
context.Database.EnsureCreated(); //make sure database is created
List<Movie> movies = new List<Movie>();
movies.Add(new Movie() { MovieID = 1, Title = "Thriller", TrailerURL = "" });
movies.Add(new Movie() { MovieID = 2, Title = "Blabla", TrailerURL = "" });
movies.Add(new Movie() { MovieID = 3, Title = "BliBli", TrailerURL = "" });

context.Movies.AddRange(movies);
context.SaveChanges();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();


app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
