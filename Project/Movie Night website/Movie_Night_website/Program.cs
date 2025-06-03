//using Microsoft.EntityFrameworkCore; //you gotta go

using Movie_Night_website.Services;
using Movie_Night_Website.DataAccess.Data;
using Movie_Night_Website.Domain.Interfaces;
using Movie_Night_Website.Service;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(options => 
{
    options.Conventions.AddPageRoute("/Login", "");
});

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IMediaRepository, MediaRepository>();
builder.Services.AddScoped<IAuthentication, AuthenticationService>();





builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<MediaService>();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromDays(3);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddAuthentication("MyCookieAuth")
    .AddCookie("MyCookieAuth", options =>
    {
        options.LoginPath = "/Login";
        options.LogoutPath = "/Logout";
        options.Cookie.Name = "MovieNightAuth";
        options.ExpireTimeSpan = TimeSpan.FromDays(7); 
    });

builder.Services.AddAuthorization();



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

app.UseAuthorization();

app.UseSession();


app.MapStaticAssets();

app.MapRazorPages()
   .WithStaticAssets();

app.Run();
