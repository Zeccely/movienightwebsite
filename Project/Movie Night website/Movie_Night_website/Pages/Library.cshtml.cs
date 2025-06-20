using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Movie_Night_website.Models;
using Movie_Night_website.Services;

namespace Movie_Night_website.Pages
{
    [Authorize(Roles ="Regular")]
    public class LibraryModel : PageModel
    {
        private readonly MediaService _mediaService;
        public List<Media> AllMedia {  get; set; }
        public List<MovieNight> PastEvents { get; set; } // can create this with that construckter

        public void OnGet()
        {
            //get watched and unwatched media and display 
            //inner join tables and such
        }
    }
}
