using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Movie_Night_website.Models;

namespace Movie_Night_website.Pages
{
    [Authorize]
    public class LibraryModel : PageModel
    {
        public List<Media> AllMedia {  get; set; }
        public List<MovieNight> PastEvents { get; set; }

        public void OnGet()
        {
            //get all media and display unwatched movies and already watched movies 
            //check if movies have a datetime set on movienight and display accordingly
        }
    }
}
