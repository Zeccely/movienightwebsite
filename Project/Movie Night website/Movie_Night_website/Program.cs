//using Microsoft.EntityFrameworkCore; //you gotta go

using Movie_Night_website;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(options => 
{
    options.Conventions.AddPageRoute("/Login", "");
});
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
//builder.Services.AddScoped<MovieNightDatabase>();
var app = builder.Build();









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
